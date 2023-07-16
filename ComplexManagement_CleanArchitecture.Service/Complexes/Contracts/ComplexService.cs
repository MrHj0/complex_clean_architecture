using ComplexManagement_CleanArchitecture.Service.Complexes.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement_CleanArchitecture.Service.Complexes.Contracts
{
    public interface ComplexService
    {
        void Add(AddComplexDto dto);
        void EditComplexUnitCount(int complexId, int unitCount);
        GetComplexWithUnitsAndBlockCountsDto GetComplexBlockCountAndUnitsByComplexId(int complexId);
        List<GetAllComplexesWithUnitCount> GetAllComplexesWithUnitCount(ComplexSearchDto dto);
        List<GetAllComplexWithBlockDetailsDto> GetAllComplexWithBlockDetails(string? name);
    }
}
