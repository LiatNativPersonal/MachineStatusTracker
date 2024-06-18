using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineStatusTracker.Models.Queries
{
    public interface IGetAllMachines
    {
        Task<IEnumerable<Machine>> Execute();
    }
}
