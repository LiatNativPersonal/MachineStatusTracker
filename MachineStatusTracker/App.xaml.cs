using MachineStatusTracker.EntityFramework;
using MachineStatusTracker.EntityFramework.Commands;
using MachineStatusTracker.EntityFramework.Queries;
using MachineStatusTracker.Models;
using MachineStatusTracker.Models.Commands;
using MachineStatusTracker.Stores;
using MachineStatusTracker.ViewModels;
using Microsoft.EntityFrameworkCore;
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
        private readonly MachineStore _machineStore;
        private readonly MachineStatusTrackerDBContextFactory _dbContextFactory;
        private readonly ICreateMachineCommand _createMachineCommand;
        private readonly IUpdateMachineCommand _updateMachineCommand;
        private readonly IDeleteMachineCommand _deleteMachineCommand;
        private readonly GetAllMachineQuery _findAllMachineQuery;
        private readonly GetAllMachineStatusesQuery _getAllMachineStatusesQuery;


        public App()
        {
            string connectionString = "Data Source = MachineStausTracker.db";
            _dbContextFactory = new MachineStatusTrackerDBContextFactory(
                new DbContextOptionsBuilder().UseSqlite(connectionString).Options);
            
            _createMachineCommand = new CreateMachineCommand(_dbContextFactory);
            _updateMachineCommand = new UpdateMachineCommand(_dbContextFactory);
            _deleteMachineCommand = new DeleteMachineCommand(_dbContextFactory);
            _findAllMachineQuery = new GetAllMachineQuery(_dbContextFactory);
            _getAllMachineStatusesQuery = new GetAllMachineStatusesQuery(_dbContextFactory);
            
            _modalNavigationStore = new ModalNavigationStore();
            _machineStore = new MachineStore(_createMachineCommand, _updateMachineCommand,
                _deleteMachineCommand, _findAllMachineQuery, _getAllMachineStatusesQuery);
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            
            using (MachineStatusTrackerDBContext context = _dbContextFactory.Create())
            {
               
                context.Database.Migrate();
            }

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_modalNavigationStore,
                new MachineStatusesViewModel(_modalNavigationStore, _machineStore))

            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }

}
