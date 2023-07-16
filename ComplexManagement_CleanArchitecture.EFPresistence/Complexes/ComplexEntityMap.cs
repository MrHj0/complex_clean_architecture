using ComplexManagement_CleanArchitecture.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement_CleanArchitecture.EFPresistence.Complexes
{
    public class ComplexEntityMap : IEntityTypeConfiguration<Complex>
    {
        public void Configure(EntityTypeBuilder<Complex> complex)
        {
            complex.ToTable("Complexes");

            complex.HasKey(_ => _.Id);
            complex.Property(_ => _.Id).ValueGeneratedOnAdd();
            complex.Property(_ => _.Name).IsRequired();
            complex.Property(_ => _.UnitCount).IsRequired();
        }
    }
}
