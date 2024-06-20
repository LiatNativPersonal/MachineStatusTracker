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

        private readonly List<Machine> _machines;
        private readonly List<Status> _statuses;
        public IEnumerable<Machine> Machines => _machines;
        public IEnumerable<Status> Statuses => _statuses;

        public event Action MachinesLoaded;
        public event Action StatusesLoaded;
        public event Action<Machine> MachineAdded;
        public event Action<Machine> MachineUpdated;
        public event Action<Guid> MachineDeleted;

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
            _machines = new List<Machine>();
            _statuses = new List<Status>();
        }


        public async Task Add(Machine machine)
        {
            await _createMachineCommand.Execute(machine);
            _machines.Add(machine);
            MachineAdded?.Invoke(machine);
        }

        public async Task Delete(Guid id)
        {
            await _deleteMachineCommand.Execute(id);

            _machines.RemoveAll(y => y.Id == id);
            
            MachineDeleted?.Invoke(id);
        }

        public async Task Update(Machine machine)
        {
            
            await _updateMachineCommand.Execute(machine);
            int currentIndex =_machines.FindIndex(y => y.Id == machine.Id);
            if (currentIndex == -1)
            {
                _machines[currentIndex] = machine;
            }
            else
            {
                _machines.Add(machine);
            }

            MachineUpdated?.Invoke(machine);
        }

        public async Task LoadMachines()
        {
            IEnumerable<Machine> machines = await _findAllMachineQuery.Execute();  
            _machines.Clear();
            _machines.AddRange(machines);

            MachinesLoaded?.Invoke();
        }

        public async Task LoadStauses()
        {
            IEnumerable<Status> statuses = await _getAllMachineStatusesQuery.Execute();
            _statuses.Clear();
            _statuses.AddRange(statuses);

            StatusesLoaded?.Invoke();
        }
    }
}
