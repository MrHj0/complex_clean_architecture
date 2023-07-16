using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement_CleanArchitecture.Entities
{
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BlockId { get; set; }
        public UnitType Resident { get; set; }

        public Block Block { get; set; }
    }
    public enum UnitType
    {
        Owner = 1,
        Tenat = 2,
        Unkhown = 3
    }
}

