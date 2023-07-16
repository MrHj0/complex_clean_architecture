using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement_CleanArchitecture.Entities
{
    public class Block
    {
        public Block()
        {
            Units = new();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int UnitCount { get; set; }
        public int ComplexId { get; set; }
        public Complex Complex { get; set; }

        public HashSet<Unit> Units { get; set; }
    }
}
