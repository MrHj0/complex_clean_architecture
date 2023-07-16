using ComplexManagement_CleanArchitecture.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement_CleanArchitecture.Service.Blocks.Contracts.Dto
{
    public class GetBlockWithUnitDetailsDto
    {
        public string Name { get; set; }
        public List<UnitDetailDto> Units { get; set; }
    }

    public class UnitDetailDto
    {
        public int UnitNumber { get; set; }
        public UnitType Resident { get; set; }
    }
}
