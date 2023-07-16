using ComplexManagement_CleanArchitecture.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement_CleanArchitecture.EFPresistence.Units
{
    public class UnitEntityMap : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> unit)
        {
            unit.ToTable("Units");

            unit.HasKey(_ => _.Id);
            unit.Property(_ => _.Id)
                .ValueGeneratedOnAdd();

            unit.Property(_ => _.Name).IsRequired();
            unit.Property(_=>_.BlockId).IsRequired();
            unit.Property(_ => _.Resident).IsRequired();

            unit.HasOne(_ => _.Block)
                .WithMany(_ => _.Units)
                .HasForeignKey(_ => _.BlockId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
