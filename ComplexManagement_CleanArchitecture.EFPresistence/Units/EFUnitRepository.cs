using ComplexManagement_CleanArchitecture.Entities;
using ComplexManagement_CleanArchitecture.Service.Units.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement_CleanArchitecture.EFPresistence.Units
{
    public class EFUnitRepository : UnitRepository
    {
        private readonly DbSet<Unit> _units;
        public EFUnitRepository(EFDataContext units)
        {
            _units = units.Set<Unit>();
        }

        public void Add(Unit unit)
        {
            _units.Add(unit);
        }

        public bool CheckBlockHasUnitByBlockId(int blockId)
        {
            return _units.Any(_ => _.BlockId == blockId);
        }

        public bool CheckComplexHasUnitByComplexId(int complexId)
        {
            return _units.Any(_ => _.Block.ComplexId == complexId);

        }
    }
}
