using System.ComponentModel;
using System.Reflection;
using System.Windows;

namespace CADBooster.Second.Addin
{
    internal static class ProcessHelpers
    {
        /// <summary>
        /// Check if we are in Design Mode by checking if the current process is Visual Studio.
        /// </summary>
        public static bool InDesignMode => DesignerProperties.GetIsInDesignMode(new DependencyObject());

        /// <summary>
        /// Get the version of an assembly.
        /// </summary>
        public static string GetAssemblyVersion(Assembly executingAssembly)
        {
            return executingAssembly.GetName().Version.ToString();
        }
    }
}
