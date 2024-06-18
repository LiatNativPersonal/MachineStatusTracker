using MachineStatusTracker.Models;
using MachineStatusTracker.Stores;
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

        private readonly ModalNavigationStore _modalNavigationStore;       

        public App()
        {
            _modalNavigationStore = new ModalNavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_modalNavigationStore, new MachineStatusesViewModel(_modalNavigationStore))

            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }

}
