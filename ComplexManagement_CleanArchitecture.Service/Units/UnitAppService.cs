using ComplexManagement_CleanArchitecture.Entities;
using ComplexManagement_CleanArchitecture.Service.Blocks.Contracts;
using ComplexManagement_CleanArchitecture.Service.Contracts;
using ComplexManagement_CleanArchitecture.Service.Units.Contracts;
using ComplexManagement_CleanArchitecture.Service.Units.Contracts.Dto;
using ComplexManagement_CleanArchitecture.Service.Units.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement_CleanArchitecture.Service.Units
{
    public class UnitAppService : UnitService
    {
        private readonly UnitRepository _unitRepository;
        private readonly BlockRepository _blockRepository;
        private readonly UnitOfWork _unitOfWork;

        public UnitAppService(UnitRepository unitRepository,
                              BlockRepository blockRepository,
                              UnitOfWork unitOfWork)
        {
            _blockRepository = blockRepository;
            _unitRepository = unitRepository;
            _unitOfWork = unitOfWork;
        }
        public void Add(AddUnitDto dto)
        {
            var isDuplicatedName = _blockRepository
                .isDuplicatedUnitNameInBlock(dto.Name);
            if(isDuplicatedName)
            {
                throw new DuplicatedUnitNameException();
            }

            var unit = new Unit
            {
                Name = dto.Name,
                BlockId = dto.BlockId,
                Resident = dto.Resident,
            };

            _unitRepository.Add(unit);
            _unitOfWork.Complete();
        }
    }
}
