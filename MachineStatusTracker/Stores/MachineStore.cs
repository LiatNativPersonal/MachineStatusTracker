using MachineStatusTracker.EntityFramework.Queries;
using MachineStatusTracker.Models;
using MachineStatusTracker.Models.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineStatusTracker.Stores
{
    public class MachineStore
    {

        private readonly ICreateMachineCommand _createMachineCommand;
        private readonly IUpdateMachineCommand _updateMachineCommand;
        private readonly IDeleteMachineCommand _deleteMachineCommand;
        private readonly GetAllMachineQuery _findAllMachineQuery;
        private readonly GetAllMachineStatusesQuery _getAllMachineStatusesQuery;

        public MachineStore(ICreateMachineCommand createMachineCommand, 
            IUpdateMachineCommand updateMachineCommand, 
            IDeleteMachineCommand deleteMachineCommand, 
            GetAllMachineQuery findAllMachineQuery,
            GetAllMachineStatusesQuery getAllMachineStatusesQuery)
        {
            _createMachineCommand = createMachineCommand;
            _updateMachineCommand = updateMachineCommand;
            _deleteMachineCommand = deleteMachineCommand;
            _findAllMachineQuery = findAllMachineQuery;
            _getAllMachineStatusesQuery = getAllMachineStatusesQuery;
        }

        public event Action<Machine> MachineAdded;
        public event Action<Machine> MachineUpdated;
        public async Task Add(Machine machine)
        {
            await _createMachineCommand.Execute(machine);
            MachineAdded?.Invoke(machine);
        }

        public async Task Update(Machine machine)
        {
            await _updateMachineCommand.Execute(machine);
            MachineUpdated?.Invoke(machine);
        }
    }
}
