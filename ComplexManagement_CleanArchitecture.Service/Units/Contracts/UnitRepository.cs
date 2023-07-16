using ComplexManagement_CleanArchitecture.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement_CleanArchitecture.Service.Units.Contracts
{
    public interface UnitRepository
    {
        void Add(Unit unit);
        bool CheckComplexHasUnitByComplexId(int complexId);
        bool CheckBlockHasUnitByBlockId(int blockId);
    }
}
