using ComplexManagement_CleanArchitecture.Entities;
using ComplexManagement_CleanArchitecture.Service.Blocks.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement_CleanArchitecture.Service.Blocks.Contracts
{
    public interface BlockRepository
    {
        void Add(Block block);
        void UpdateBlocksUnitCount(List<Block> blocks);
        int GetComplexUnitCountByBlockId(int blockId);
        int GetBlockRegisteredUnitCountByBlockId(int blockId);
        bool isDuplicatedUnitNameInBlock(string name);
        bool IsBlockExsistByBlockId(int blockId);
        void EditBlock(Block block);
        Block? GetBlockByBlockId(int blockId);
        GetBlockWithUnitDetailsDto GetBlockWithUnitDetailsByBlockId(int blockId);
        List<GetAllBlocksWithUnitDetailsDto> GetAllBlocksWithUnitsDetail();
        List<Block> GetComplexBlocksByComplexId(int complexId);
    }
}
