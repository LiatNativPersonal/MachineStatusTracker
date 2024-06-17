using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineStatusTracker.ViewModels
{
    public class AddMachineViewModel:ViewModelBase
    {
        public MachineDetailsFormViewModel MachineDetailsFormViewModel { get;  }

        public AddMachineViewModel()
        {
            MachineDetailsFormViewModel = new MachineDetailsFormViewModel();
        }
    }
}
