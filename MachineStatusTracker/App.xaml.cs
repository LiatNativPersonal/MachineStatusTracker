using MachineStatusTracker.Models;
using System.Configuration;
using System.Data;
using System.Windows;

namespace MachineStatusTracker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Machine machine = new Machine("M1", "Test machine");
            base.OnStartup(e);
        }
    }

}
