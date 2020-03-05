using System.ComponentModel;

namespace CADBooster.First.Addin.Windows.TaskPane
{
    internal class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
}
