using System;

namespace Child
{
    public class Child
    {
        public static void Play()
        {
            var ad = AppDomain.CurrentDomain;
            Console.WriteLine("\r\nApplication domain '{0}': IsFullyTrusted = {1}",
                ad.FriendlyName, ad.IsFullyTrusted);

            Console.WriteLine("   IsFullyTrusted = {0} for the current assembly {1}",
                typeof(Child).Assembly.IsFullyTrusted,
                typeof(Child).Assembly);

            Console.WriteLine("   IsFullyTrusted = {0} for mscorlib",
                typeof(int).Assembly.IsFullyTrusted);

            throw new Exception("Some exception");
        }
    }
}
