using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineStatusTracker.EntityFramework.DTO
{
    public class StatusDto
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
