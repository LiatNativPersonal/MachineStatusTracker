using MachineStatusTracker.Models;
using MachineStatusTracker.ViewModels;
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
            MainWindow = new MainWindow()
            {
                DataContext = new MachineStatusesViewModel()
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }

}
