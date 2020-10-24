using AngelSix.SolidDna;
using CADBooster.First.Addin.Windows;
using CADBooster.First.Logging;

namespace CADBooster.First.Addin.SolidWorks
{
    public class FirstSolidWorksPlugin : SolidPlugIn
    {
        private static readonly Logger Log = Logger.GetLogger(nameof(FirstSolidWorksPlugin));

        public override string AddInTitle => "First add-in";

        public override string AddInDescription => "The very first add-in";
        
        public override void ConnectedToSolidWorks()
        {
            Log.Info("First add-in connected to SOLIDWORKS", nameof(ConnectedToSolidWorks));
            ShowWindow.TaskPane();
        }
        
        public override void DisconnectedFromSolidWorks()
        {
            Log.Info("First add-in closing down", nameof(DisconnectedFromSolidWorks));
        }
    }
}

