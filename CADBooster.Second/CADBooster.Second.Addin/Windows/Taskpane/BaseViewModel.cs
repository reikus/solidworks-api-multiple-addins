using System.ComponentModel;

namespace CADBooster.Second.Addin.Windows.TaskPane
{
    internal class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
}
