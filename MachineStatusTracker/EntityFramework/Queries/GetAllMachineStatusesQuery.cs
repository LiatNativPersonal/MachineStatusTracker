using MachineStatusTracker.EntityFramework.DTO;
using MachineStatusTracker.Models;
using MachineStatusTracker.Models.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineStatusTracker.EntityFramework.Queries
{
    public class GetAllMachineStatusesQuery : IGetAllMachineStatuses
    {
        private readonly MachineStatusTrackerDBContextFactory _dbContextFactory;

        public GetAllMachineStatusesQuery(MachineStatusTrackerDBContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Status>> Execute()
        {
            using (MachineStatusTrackerDBContext context = _dbContextFactory.Create())
            {
                IEnumerable<StatusDto> statusDtos = await context.Statuses.ToListAsync();
                return statusDtos.Select(d => new Status(d.Id, d.Name));
            }
        }
    }
}
