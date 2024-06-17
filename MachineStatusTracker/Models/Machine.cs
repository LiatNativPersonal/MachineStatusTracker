using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineStatusTracker.Models
{
    public class Machine
    {
        private readonly Guid Id;
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; }
        public Machine(string name, string description)
        {
            Id = Guid.NewGuid();
            Name = name;
            Status = new Status();
            Description = description;
        }

    }
}
