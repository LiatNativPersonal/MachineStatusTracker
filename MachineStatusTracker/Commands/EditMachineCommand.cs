using MachineStatusTracker.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineStatusTracker.Commands
{
    public class EditMachineCommand : AsyncCommandBase
    {

        private readonly ModalNavigationStore _modalNavigationStore;

        public EditMachineCommand(ModalNavigationStore modalNavigationStore)
        {
            _modalNavigationStore = modalNavigationStore;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            _modalNavigationStore.Close();
        }
    }
}
