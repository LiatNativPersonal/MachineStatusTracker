using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineStatusTracker.Models
{
    public class Machine
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; }
        public Machine(Guid id, string name, string description, Status status)
        {
            Id = id;
            Name = name;
            Status = status;
            Description = description;
        }

    }
}
