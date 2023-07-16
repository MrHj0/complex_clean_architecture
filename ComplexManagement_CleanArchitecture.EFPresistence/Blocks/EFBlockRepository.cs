using ComplexManagement_CleanArchitecture.Entities;
using ComplexManagement_CleanArchitecture.Service.Blocks.Contracts;
using ComplexManagement_CleanArchitecture.Service.Blocks.Contracts.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement_CleanArchitecture.EFPresistence.Blocks
{
    public class EFBlockRepository : BlockRepository
    {
        private readonly DbSet<Block> _blocks;

        public EFBlockRepository(EFDataContext blocks)
        {
            _blocks = blocks.Set<Block>();
        }

        public void Add(Block block)
        {
            _blocks.Add(block);
        }

        public void EditBlock(Block block)
        {
            _blocks.Update(block);
        }

        public List<GetAllBlocksWithUnitDetailsDto>
            GetAllBlocksWithUnitsDetail()
        {
            var result = _blocks.Select(_ => new
            GetAllBlocksWithUnitDetailsDto
            {
                Name = _.Name,
                UnitCount = _.UnitCount,
                RegisteredUnitsCount = _.Units.Count(),
                RemainingUnitsCount = _.UnitCount - _.Units.Count()
            });
            return result.ToList();
        }

        public Block? GetBlockByBlockId(int blockId)
        {
            return _blocks
                .Where(_ => _.Id == blockId)
                .FirstOrDefault();
        }

        public GetBlockWithUnitDetailsDto GetBlockWithUnitDetailsByBlockId(int blockId)
        {
            var block = _blocks
                .Where(_ => _.Id == blockId)
                .Include(_=>_.Units)
                .FirstOrDefault();

            List<UnitDetailDto> units = new();
            int counter = 1;
            foreach(var item in block.Units)
            {
                units.Add(new UnitDetailDto
                {
                    UnitNumber = counter++,
                    Resident = item.Resident
                });
            }

            return new GetBlockWithUnitDetailsDto
            {
                Name = block.Name,
                Units = units
            };
        }

        public List<Block> GetComplexBlocksByComplexId(int complexId)
        {
           return _blocks.Where(_ => _.ComplexId == complexId).ToList();
        }

        public int GetComplexUnitCountByBlockId(int blockId)
        {
            return _blocks
                .Where(_ => _.Id == blockId)
                .Select(_ => _.Complex.UnitCount)
                .FirstOrDefault();

        }

        public bool IsBlockExsistByBlockId(int blockId)
        {
            return _blocks.Any(_ => _.Id == blockId);
        }

        public bool isDuplicatedUnitNameInBlock(string name)
        {
            return _blocks.Where(_=>_.Units.Any(_=>_.Name == name)).Any();
        }

        public void UpdateBlocksUnitCount(List<Block> blocks)
        {
            _blocks.UpdateRange(blocks);
        }
    }
}
