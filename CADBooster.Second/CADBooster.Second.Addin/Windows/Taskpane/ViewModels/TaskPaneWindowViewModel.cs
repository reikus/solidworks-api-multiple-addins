namespace CADBooster.Second.Addin.Windows.TaskPane.ViewModels
{
    internal class TaskPaneWindowViewModel : BaseViewModel
    {
        public TaskPaneWindowViewModel()
        {
            PanelViewModel = new NoFilePanelViewModel();
        }
        
        /// <summary>
        /// The active view model
        /// </summary>
        public TaskPanePanelViewModel PanelViewModel { get; }
    }
}
