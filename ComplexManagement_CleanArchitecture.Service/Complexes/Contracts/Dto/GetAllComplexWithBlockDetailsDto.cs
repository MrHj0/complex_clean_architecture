using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement_CleanArchitecture.Service.Complexes.Contracts.Dto
{
    public class GetAllComplexWithBlockDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BlockDetailsDto> Blocks { get; set; }
    }

    public class BlockDetailsDto
    {
        public int BlockNumber { get; set; }
        public int UnitCount { get; set; }
    }
}
