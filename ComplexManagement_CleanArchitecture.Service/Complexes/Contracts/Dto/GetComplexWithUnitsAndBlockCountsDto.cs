using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement_CleanArchitecture.Service.Complexes.Contracts.Dto
{
    public class GetComplexWithUnitsAndBlockCountsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RegisteredUnits { get; set; }
        public int RemainingUnits { get; set; }
        public int BlocksCount { get; set; }

    }
}
