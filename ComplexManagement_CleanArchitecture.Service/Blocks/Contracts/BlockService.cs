using ComplexManagement_CleanArchitecture.Service.Blocks.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement_CleanArchitecture.Service.Blocks.Contracts
{
    public interface BlockService
    {
        void Add(AddBlockDto dto);
        void EditBlock(int blockId,EditBlockDto dto);
        GetBlockWithUnitDetailsDto GetBlockWithUnitDetailsById(int blockId);
        List<GetAllBlocksWithUnitDetailsDto> GetAllBlocksWithUnits();
    }
}
