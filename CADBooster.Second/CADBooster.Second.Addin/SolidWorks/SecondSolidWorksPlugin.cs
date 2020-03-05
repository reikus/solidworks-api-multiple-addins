using AngelSix.SolidDna;
using CADBooster.Second.Addin.Windows;
using CADBooster.Second.Logging;

namespace CADBooster.Second.Addin.SolidWorks
{
    public class SecondSolidWorksPlugin : SolidPlugIn
    {
        private static readonly Logger Log = Logger.GetLogger(nameof(SecondSolidWorksPlugin));

        public override string AddInTitle => "Second add-in";

        public override string AddInDescription => "The very second add-in";
        
        public override void ConnectedToSolidWorks()
        {
            Log.Info("Second add-in connected to SOLIDWORKS", nameof(ConnectedToSolidWorks));
          
            ShowWindow.TaskPane();
        }
        
        public override void DisconnectedFromSolidWorks()
        {
            Log.Info("Second add-in closing down", nameof(DisconnectedFromSolidWorks));
        }
    }
}

