using MachineStatusTracker.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineStatusTracker.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;

        public ViewModelBase CurrentModalViewModel => _modalNavigationStore.CurrentViewModel;
        public MachineStatusesViewModel MachineStatusesViewModel { get; }
        public bool IsModalOpen => _modalNavigationStore.IsOpen;

        public MainViewModel(ModalNavigationStore modalNavigationStore, MachineStatusesViewModel machineStatusesViewModel)
        {
            _modalNavigationStore = modalNavigationStore;
            MachineStatusesViewModel = machineStatusesViewModel;

            _modalNavigationStore.CurrentViewModelChanged += ModalNavigationStore_CurrentViewModelChanged;
            _modalNavigationStore.CurrentViewModel = new AddMachineViewModel();
        }

        


        private void ModalNavigationStore_CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentModalViewModel));
            OnPropertyChanged(nameof(IsModalOpen));

        }
    }
}
