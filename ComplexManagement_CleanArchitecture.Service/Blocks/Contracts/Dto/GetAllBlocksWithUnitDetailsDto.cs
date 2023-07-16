using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement_CleanArchitecture.Service.Blocks.Contracts.Dto
{
    public class GetAllBlocksWithUnitDetailsDto
    {
        public string Name { get; set; }
        public int UnitCount { get; set; }
        public int RegisteredUnitsCount { get; set; }
        public int RemainingUnitsCount { get; set; }
    }
}
