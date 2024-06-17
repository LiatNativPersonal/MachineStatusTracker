using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineStatusTracker.ViewModels
{
    public class MachineStautsContainerViewModel:ViewModelBase
    {
        private readonly ObservableCollection<MachineStatusViewModel> _machineStatusViewModels;
        public IEnumerable<MachineStatusViewModel> MachineStatusViewModels => _machineStatusViewModels;

        public MachineStautsContainerViewModel()
        {
            _machineStatusViewModels = new ObservableCollection<MachineStatusViewModel>();

            _machineStatusViewModels.Add(new MachineStatusViewModel("Machine1", "Some information", "idle"));
            _machineStatusViewModels.Add(new MachineStatusViewModel("Machine2", "Some information", "active"));
            _machineStatusViewModels.Add(new MachineStatusViewModel("Machine3", "Some information", "offline"));
        }
    }
}
