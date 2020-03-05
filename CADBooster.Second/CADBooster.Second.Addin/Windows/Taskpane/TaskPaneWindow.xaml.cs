using System.Windows;
using CADBooster.Second.Addin.Windows.TaskPane.ViewModels;

namespace CADBooster.Second.Addin.Windows.TaskPane
{
    /// <summary>
    /// Interaction logic for TaskPaneWindow.xaml
    /// </summary>
    public partial class TaskPaneWindow
    {
        public TaskPaneWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Set the data context. Best practice for windows is to set it in OnLoaded event, but that doesn't exist for user controls.
        /// Loading the data context in code is 50-100ms faster.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TaskPaneWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            DataContext = new TaskPaneWindowViewModel();
        }
    }
}
