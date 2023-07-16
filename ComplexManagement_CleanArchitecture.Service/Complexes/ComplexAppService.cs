using ComplexManagement_CleanArchitecture.Entities;
using ComplexManagement_CleanArchitecture.Service.Blocks.Contracts;
using ComplexManagement_CleanArchitecture.Service.Complexes.Contracts;
using ComplexManagement_CleanArchitecture.Service.Complexes.Contracts.Dto;
using ComplexManagement_CleanArchitecture.Service.Complexes.Exceptions;
using ComplexManagement_CleanArchitecture.Service.Contracts;
using ComplexManagement_CleanArchitecture.Service.Units.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement_CleanArchitecture.Service.Complexes
{
    public class ComplexAppService : ComplexService
    {
        private readonly ComplexRepository _complexRepository;
        private readonly UnitRepository _unitRepository;
        private readonly BlockRepository _blockRepository;
        private readonly UnitOfWork _unitOfWork;
        public ComplexAppService(ComplexRepository complexRepository,
                                 UnitRepository unitRepository,
                                 BlockRepository blockRepository,
                                 UnitOfWork unitOfWork)
        {
            _complexRepository = complexRepository;
            _unitRepository = unitRepository;
            _blockRepository = blockRepository;
            _unitOfWork = unitOfWork;
        }
        public void Add(AddComplexDto dto)
        {
            var complex = new Complex
            {
                Name = dto.Name,
                UnitCount = dto.UnitCount
            };

            _complexRepository.Add(complex);
            _unitOfWork.Complete();
        }

        public void EditComplexUnitCount(int complexId, int unitCount)
        {
            var complex = _complexRepository.GetComplexById(complexId);
            if(complex == null)
            {
                throw new ComplexNotFoundException();
            }
            if(unitCount > 1000 || unitCount < 4)
            {
                throw new ComplexUnitCountOutOfRangeException();
            }

            var complexHasUnit = _unitRepository
                .CheckComplexHasUnitByComplexId(complexId);
            if (complexHasUnit)
            {
                throw new ComplexHasUnitException();
            }

            if(complex.UnitCount > unitCount)
            {
                var blocks = _blockRepository
                    .GetComplexBlocksByComplexId(complexId);
                foreach(var item in blocks)
                {
                    item.UnitCount = 0;
                }
                _blockRepository.UpdateBlocksUnitCount(blocks);
            }

            complex.UnitCount = unitCount;

            _complexRepository.UpdateComplexUnitCount(complex);
            _unitOfWork.Complete();
        }

        public List<GetAllComplexesWithUnitCount>
            GetAllComplexesWithUnitCount(ComplexSearchDto dto)
        {
            return _complexRepository.GetAllComplexesWithUnitCount(dto);
        }

        public List<GetAllComplexWithBlockDetailsDto>
            GetAllComplexWithBlockDetails(string? name)
        {
            return _complexRepository.GetAllComplexesWithBlockDetails(name);
        }

        public GetComplexWithUnitsAndBlockCountsDto
            GetComplexBlockCountAndUnitsByComplexId(int complexId)
        {
            var complex = _complexRepository.GetComplexWithBlocksById(complexId);

            if(complex == null)
            {
                throw new ComplexNotFoundException();
            }
            var result = new GetComplexWithUnitsAndBlockCountsDto
            {
                Id = complex.Id,
                Name = complex.Name,
                RegisteredUnits = complex.Blocks.SelectMany(_ => _.Units).Count(),
                RemainingUnits = complex.UnitCount
                - complex.Blocks.SelectMany(_ => _.Units).Count(),
                BlocksCount = complex.Blocks.Count()
            };

            return result;
        }
    }
}
