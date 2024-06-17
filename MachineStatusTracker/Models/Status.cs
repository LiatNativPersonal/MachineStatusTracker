using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineStatusTracker.Models
{
    public class Status
    {
        private readonly Guid Id;
        public string Name { get; }

        public Status(string name = "")
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
