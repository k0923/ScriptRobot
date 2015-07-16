using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AppDomainTest
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomainSetup setup = new AppDomainSetup();
            setup.ApplicationBase = AppDomain.CurrentDomain.BaseDirectory;
            setup.PrivateBinPath = "PrivatePath";

            AppDomain secondAD = AppDomain.CreateDomain(
              "SecondAD", AppDomain.CurrentDomain.Evidence, setup);

            InOtherAppDomain obj = (InOtherAppDomain)
              secondAD.CreateInstanceAndUnwrap(
                typeof(InOtherAppDomain).Assembly.FullName,
                typeof(InOtherAppDomain).FullName);
            

            obj.SomeMethod();
            
            Console.ReadLine();
        }
    }

    class InOtherAppDomain : MarshalByRefObject
    {
       
        public void SomeMethod()
        {
            AppDomain thisAD = AppDomain.CurrentDomain;

            Console.WriteLine(thisAD.BaseDirectory);
            Console.WriteLine(thisAD.RelativeSearchPath);

            string privateBinDirectory =
              thisAD.BaseDirectory + @"\\" + thisAD.RelativeSearchPath;
            Console.WriteLine(privateBinDirectory);

            Console.WriteLine(File.Exists(
              Path.Combine(privateBinDirectory, "SAPAutomation.dll")));

            try
            {
                Assembly.Load("SAPAutomation");
                foreach (var asm in thisAD.GetAssemblies())
                {
                    Console.WriteLine(asm.GetName().Name);
                }
                
                Console.WriteLine("Assembly loaded successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading assembly: " + ex.Message);
            }
        }
    }
}
