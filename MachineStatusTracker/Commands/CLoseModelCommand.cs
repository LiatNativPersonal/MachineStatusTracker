using MachineStatusTracker.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineStatusTracker.Commands
{
    public class CLoseModelCommand : CommandBase
    {

        private readonly ModalNavigationStore _modalNavigationStore;

        public CLoseModelCommand(ModalNavigationStore modalNavigationStore)
        {
            _modalNavigationStore = modalNavigationStore;
        }
        public override void Execute(object? parameter)
        {
            _modalNavigationStore.Close();
        }
    }
}
