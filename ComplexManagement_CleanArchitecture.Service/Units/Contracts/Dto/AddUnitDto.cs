using ComplexManagement_CleanArchitecture.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement_CleanArchitecture.Service.Units.Contracts.Dto
{
    public class AddUnitDto
    {
        [Required,MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int BlockId { get; set; }
        [Required]
        public UnitType Resident { get; set; }
    }
}
