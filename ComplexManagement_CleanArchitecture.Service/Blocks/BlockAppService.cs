using ComplexManagement_CleanArchitecture.Entities;
using ComplexManagement_CleanArchitecture.Service.Blocks.Contracts;
using ComplexManagement_CleanArchitecture.Service.Blocks.Contracts.Dto;
using ComplexManagement_CleanArchitecture.Service.Blocks.Exceptions;
using ComplexManagement_CleanArchitecture.Service.Complexes.Contracts;
using ComplexManagement_CleanArchitecture.Service.Complexes.Exceptions;
using ComplexManagement_CleanArchitecture.Service.Contracts;
using ComplexManagement_CleanArchitecture.Service.Units.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement_CleanArchitecture.Service.Blocks
{
    public class BlockAppService : BlockService
    {
        private readonly BlockRepository _blockRepository;
        private readonly ComplexRepository _complexRepository;
        private readonly UnitRepository _unitRepository;
        private readonly UnitOfWork _unitOfWork;
        public BlockAppService(BlockRepository blockRepository,
                               UnitOfWork unitOfWork,
                               ComplexRepository  complexRepository,
                               UnitRepository unitRepository)
        {
            _blockRepository = blockRepository;
            _unitOfWork = unitOfWork;
            _complexRepository = complexRepository;
            _unitRepository = unitRepository;
        }

        public void Add(AddBlockDto dto)
        {
            var complexIsExsist = _complexRepository
                .FindComplexById(dto.ComplexId);

            var isDuplicatedName = _complexRepository
                .BlockDuplicateNameByComplexId(dto.ComplexId,dto.Name);

            var totalComplexBlocksUnitcount = _complexRepository
                .GetComplexBlocksUnitCountByComplexId(dto.ComplexId);


            var complexUnitCount = _complexRepository
                .GetComplexUnitCountById(dto.ComplexId);

            if(totalComplexBlocksUnitcount + dto.UnitCount > complexUnitCount)
            {
                throw new BlockUnitCountIsOutOfCapacityException();
            }
            if (!complexIsExsist)
            {
                throw new ComplexNotFoundException();
            }
            if(isDuplicatedName)
            {
                throw new DuplicatedBlockNameException();
            }



            var block = new Block
            {
                Name = dto.Name,
                UnitCount = dto.UnitCount,
                ComplexId = dto.ComplexId,
            };

            _blockRepository.Add(block);
            _unitOfWork.Complete();
        }

        public void EditBlock(int blockId,EditBlockDto dto)
        {
            var block = _blockRepository
                .GetBlockByBlockId(blockId);
            if (block == null)
            {
                throw new BlockNotFoundException();
            }

            var isDuplicatedName = _complexRepository
                .IsDuplicatedBlockNameForEditName(blockId, dto.Name);
            if(isDuplicatedName)
            {
                throw new DuplicatedBlockNameException();
            }

            var blocksUnitCount = _complexRepository
                .GetComplexBlocksUnitCountByComplexId(block.ComplexId);

            var complexUnitCount = _complexRepository
                .GetComplexUnitCountById(block.ComplexId);
            if((blocksUnitCount - block.UnitCount + dto.UnitCount) > complexUnitCount)
            {
                throw new BlockUnitCountIsOutOfCapacityException();
            }
            
            var blockHasUnit = _unitRepository
                .CheckBlockHasUnitByBlockId(block.Id);
            if(blockHasUnit)
            {
                throw new BlockHasUnitException();
            }

            block.Name = dto.Name;
            block.UnitCount = dto.UnitCount;

            _blockRepository.EditBlock(block);
            _unitOfWork.Complete();
        }

        public List<GetAllBlocksWithUnitDetailsDto> GetAllBlocksWithUnits()
        {
            return _blockRepository.GetAllBlocksWithUnitsDetail();
        }

        public GetBlockWithUnitDetailsDto GetBlockWithUnitDetailsById(int blockId)
        {
            return _blockRepository.GetBlockWithUnitDetailsByBlockId(blockId);
        }

    }
}
