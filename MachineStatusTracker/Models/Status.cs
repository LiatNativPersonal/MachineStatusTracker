using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineStatusTracker.Models
{
    public class Status
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Status(string name = "")
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
