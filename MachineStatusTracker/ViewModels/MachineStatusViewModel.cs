using MachineStatusTracker.Commands;
using MachineStatusTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MachineStatusTracker.ViewModels
{
    public class MachineStatusViewModel : ViewModelBase
    {
        public string MachineName { get; }

        public string MachineDescription { get; set; }

        public MachineStatus MachineStatus { get; set; }

        
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public MachineStatusViewModel(Machine machine, ICommand editCommand)
        {
            MachineName = machine.Name;
            MachineDescription = machine.Description;
            MachineStatus = new MachineStatus(machine.Status.Name, machine.Status.Id);
            EditCommand = editCommand;
            
        }


    }

    public class MachineStatus
    {
        public Guid MachineId { get; set; }
        public string MachineName { get; set; }
        public MachineStatus(string Name, Guid machineID)
        {
            MachineName = Name;
            MachineId = machineID;
            
        }

        public override string ToString()
        {
            return MachineName;
        }
    }
        


}
