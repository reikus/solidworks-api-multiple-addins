using System;
using System.Windows;
using AngelSix.SolidDna;
using CADBooster.Second.Addin.Windows.TaskPane;
using CADBooster.Second.Logging;

namespace CADBooster.Second.Addin.Windows
{
    internal class ShowWindow
    {
        private static readonly Logger Log = Logger.GetLogger(nameof(ShowWindow)); 
        
        public static void TaskPane()
        {
            try
            {
                var taskPane = new TaskpaneIntegration<TaskPaneHost>
                {
                    WpfControl = new TaskPaneWindow()
                };

                taskPane.AddToTaskpaneAsync();
            }
            catch (Exception e)
            {
                Log.Error("Unhandled error within task pane: " + e.Message, nameof(TaskPane));
                MessageBox.Show("Error initializing task pane");
            }

            Log.Info("Initialized task pane", nameof(TaskPane));
        }
    }
}
