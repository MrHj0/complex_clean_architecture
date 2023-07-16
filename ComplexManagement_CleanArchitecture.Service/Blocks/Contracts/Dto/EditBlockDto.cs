using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement_CleanArchitecture.Service.Blocks.Contracts.Dto
{
    public class EditBlockDto
    {
        [MaxLength(50)]
        public string Name { get; set; }
        [Range(1,1000)]
        public int UnitCount { get; set; }
    }
}
