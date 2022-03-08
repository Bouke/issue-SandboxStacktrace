using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Permissions;
using System.Security.Policy;

namespace Parent
{
    public class Worker : MarshalByRefObject
    {
        private static string childpath = Path.Combine(Path.GetDirectoryName(typeof(Worker).Assembly.Location), "Child.dll");

        private static void Main()
        {
            var w = new Worker();
            w.TestExceptionStacktrace();

            var adSandbox = GetInternetSandbox();
            var handle = Activator.CreateInstanceFrom(
                adSandbox,
                typeof(Worker).Assembly.ManifestModule.FullyQualifiedName,
                typeof(Worker).FullName);
            w = (Worker)handle.Unwrap();
            w.TestExceptionStacktrace();
        }

        public void TestExceptionStacktrace()
        {
            TestInner();
        }

        private void TestInner()
        {
            var ass = Assembly.LoadFile(childpath);

            var playMethod = ass.GetTypes()[0].GetMethod("Play");

            try
            {
                playMethod.Invoke(null, Array.Empty<object>());
            }
            catch (Exception e)
            {
                var s = e.ToString();
                Console.WriteLine("Stack trace contains {0}line numbers for Child assembly:",
                    s.Split(new[] { Environment.NewLine }, StringSplitOptions.None)
                        .SingleOrDefault(x => x.Contains("Play()"))?.Contains("line") == true
                        ? ""
                        : "no ");
                Console.WriteLine($"   {s}");
            }
        }

        // ------------ Helper method ---------------------------------------
        private static AppDomain GetInternetSandbox()
        {
            // Create the permission set to grant to all assemblies.
            var hostEvidence = new Evidence();
            hostEvidence.AddHostEvidence(new Zone(
                System.Security.SecurityZone.Internet));
            var pset =
                System.Security.SecurityManager.GetStandardSandbox(hostEvidence);

            // add this to the permission set
            pset.AddPermission(new FileIOPermission(
                FileIOPermissionAccess.PathDiscovery, typeof(Worker).Assembly.Location)
            );
            pset.AddPermission(new FileIOPermission(
                FileIOPermissionAccess.PathDiscovery | FileIOPermissionAccess.Read, Path.GetDirectoryName(childpath))
            );

            // Identify the folder to use for the sandbox.
            var ads = new AppDomainSetup();
            ads.ApplicationBase = System.IO.Directory.GetCurrentDirectory();

            var fullTrustAssemblies = new[]
            {
                typeof(Worker).Assembly.Evidence.GetHostEvidence<StrongName>(),
            };

            // Create the sandboxed application domain.
            return AppDomain.CreateDomain("Sandbox", hostEvidence, ads, pset, fullTrustAssemblies);
        }
    }
}
