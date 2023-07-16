using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement_CleanArchitecture.Entities
{
    public class Complex
    {
        public Complex()
        {
            Blocks = new();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int UnitCount { get; set; }

        public HashSet<Block> Blocks { get; set; }

    }
}
