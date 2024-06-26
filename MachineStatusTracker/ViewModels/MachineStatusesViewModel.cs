﻿using MachineStatusTracker.Commands;
using MachineStatusTracker.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MachineStatusTracker.ViewModels
{
    public class MachineStatusesViewModel : ViewModelBase
    {
        public MachineStautsContainerViewModel MachineStautsContainerViewModel { get; }
       

        public ICommand? AddMachineCommand { get; }

        public MachineStatusesViewModel(ModalNavigationStore modalNavigationStore, MachineStore machineStore)
        {
            MachineStautsContainerViewModel = MachineStautsContainerViewModel.LoadViewModel(machineStore, modalNavigationStore);
            AddMachineCommand = new OpenAddMachineStatusCommand(machineStore, modalNavigationStore);

        }
    }
}
