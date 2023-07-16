using ComplexManagement_CleanArchitecture.Entities;
using ComplexManagement_CleanArchitecture.Service.Complexes.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement_CleanArchitecture.Service.Complexes.Contracts
{
    public interface ComplexRepository
    {
        void Add(Complex complex);
        void UpdateComplexUnitCount(Complex complex);
        bool FindComplexById(int complexId);
        bool BlockDuplicateNameByComplexId(int complexId,string name);
        bool IsDuplicatedBlockNameForEditName(int blockId, string name);
        int GetComplexBlocksUnitCountByComplexId(int complexId);
        int GetComplexUnitCountById(int complexId);
        Complex? GetComplexById(int complexId);
        Complex? GetComplexWithBlocksById(int complexId);
        List<GetAllComplexWithBlockDetailsDto> GetAllComplexesWithBlockDetails(string? name);
        List<GetAllComplexesWithUnitCount> GetAllComplexesWithUnitCount(ComplexSearchDto dto);
    }
}
