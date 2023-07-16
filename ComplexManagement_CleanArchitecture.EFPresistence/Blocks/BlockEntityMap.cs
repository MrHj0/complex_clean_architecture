using ComplexManagement_CleanArchitecture.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement_CleanArchitecture.EFPresistence.Blocks
{
    internal class BlockEntityMap : IEntityTypeConfiguration<Block>
    {
        public void Configure(EntityTypeBuilder<Block> block)
        {
            block.ToTable("Blocks");

            block.HasKey(_=>_.Id);
            block.Property(_ => _.Id).ValueGeneratedOnAdd();
            block.Property(_ => _.Name).IsRequired();
            block.Property(_ => _.UnitCount).IsRequired();
            block.Property(_ => _.ComplexId).IsRequired();

            block.HasOne(_ => _.Complex)
                .WithMany(_ => _.Blocks)
                .HasForeignKey(_ => _.ComplexId);

        }
    }
}
