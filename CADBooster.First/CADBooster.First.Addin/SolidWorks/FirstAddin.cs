using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using AngelSix.SolidDna;
using CADBooster.First.Logging;
using Dna;

namespace CADBooster.First.Addin.SolidWorks
{
    /// <summary>
    /// Register as a SolidWorks addin
    /// </summary>
    [Guid("3bda5a63-5b57-4b2a-8733-23e2f443b2ae"), ComVisible(true)]
    public class FirstAddin : AddInIntegration
    {
        private static readonly Logger Log = Logger.GetLogger(nameof(FirstAddin));

        /// <summary>
        /// Directory path to Drew.dll assembly. Used for loading/resolving missing assemblies.
        /// </summary>
        private static string _addinDirectory;

        /// <summary>
        /// Specific application startup code
        /// </summary>
        public override void ApplicationStartup()
        {
            string version = ProcessHelpers.GetAssemblyVersion(Assembly.GetExecutingAssembly());
            Loggers.StartLogging(new LogFilePath(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "First-log.txt")));
        }

        /// <summary>
        /// Runs before PreConnectToSolidWorks
        /// </summary>
        /// <param name="construction"></param>
        public override void ConfigureServices(FrameworkConstruction construction)
        {
            
        }

        /// <summary>
        /// Before connecting to SolidWorks.
        /// </summary>
        public override void PreConnectToSolidWorks()
        {
            ResolveMissingAssemblies();
        }

        /// <summary>
        /// Here you can load other plugins before the add-in is loaded
        /// </summary>
        public override void PreLoadPlugIns()
        {
        }

        /// <summary>
        /// Resolve assemblies (the dll kind) that can't be found normally.
        /// Not necessary right because because we don't run inside the SolidWorks AppDomain. 
        /// </summary>
        private static void ResolveMissingAssemblies()
        {
            if (PlugInIntegration.UseDetachedAppDomain) return;

            _addinDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (_addinDirectory == null)
                return;
            AppDomain.CurrentDomain.AssemblyResolve += ResolveMissingAssembly;
        }

        /// <summary>
        /// Called when the missing assembly event is fired.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private static Assembly ResolveMissingAssembly(object sender, ResolveEventArgs args)
        {
            var assemblyName = new AssemblyName(args.Name);
            if (assemblyName.Name.EndsWith("resources"))
            {
                // This happens 1600 times when starting up, for each possible locale
                // Our translations work even when we return null
                return null;
            }

            var assemblyPath = Path.Combine(_addinDirectory, assemblyName.Name + ".dll");
            return File.Exists(assemblyPath) ? Assembly.LoadFrom(assemblyPath) : null;
        }
    }
}