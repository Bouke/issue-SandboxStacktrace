using System;
using System.Security.Policy;

namespace SandboxStacktrace
{
    public class Worker : MarshalByRefObject
    {
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
            var ad = AppDomain.CurrentDomain;
            Console.WriteLine("\r\nApplication domain '{0}': IsFullyTrusted = {1}",
                ad.FriendlyName, ad.IsFullyTrusted);

            Console.WriteLine("   IsFullyTrusted = {0} for the current assembly",
                typeof(Worker).Assembly.IsFullyTrusted);

            Console.WriteLine("   IsFullyTrusted = {0} for mscorlib",
                typeof(int).Assembly.IsFullyTrusted);

            try
            {
                throw new Exception("Some exception");
            }
            catch (Exception e)
            {
                var trace = e.StackTrace;
                Console.Write("Stack trace contains {0}line numbers:\r\n{1}\r\n",
                    trace.Contains("line") ? "" : "no ", trace);
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
