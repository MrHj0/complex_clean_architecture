using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement_CleanArchitecture.Service.Blocks.Contracts.Dto
{
    public class AddBlockDto
    {
        [Required,MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int UnitCount { get; set; }
        [Required]
        public int ComplexId { get; set; }

    }
}
