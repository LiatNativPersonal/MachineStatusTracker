using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MachineStatusTracker.ViewModels
{
    public class MachineStatusViewModel:ViewModelBase
    {
        public string MachineName { get;}

        public string MachineDescription { get; set; }

        public string MachineStatus { get; set; }

        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public MachineStatusViewModel(string machineName, string machineDescription, string machineStatus)
        {
            MachineName = machineName;
            MachineDescription = machineDescription;
            MachineStatus = machineStatus;
        }


    }
}
