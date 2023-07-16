using ComplexManagement_CleanArchitecture.Service.Units.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement_CleanArchitecture.Service.Units.Contracts
{
    public interface UnitService
    {
        void Add(AddUnitDto dto);
    }
}
