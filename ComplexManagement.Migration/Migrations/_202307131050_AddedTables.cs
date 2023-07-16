using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement.Migration.Migrations
{
    [FluentMigrator.Migration(202307131050)]
    public class _202307131050_AddedTables : FluentMigrator.Migration
    {
        public override void Up()
        {
            CreateComplexTable();
            CreateBlockTable();
            CreateUnitTable();
            CreateUsageTypeTable();
            CreateComplexUsageTypeTable();
        }

        public override void Down()
        {
            Delete.Table("ComplexUsageTypes");
            Delete.Table("UsageTypes");
            Delete.Table("Units");
            Delete.Table("Blocks");
            Delete.Table("Complexes");
        }

        private void CreateComplexUsageTypeTable()
        {
            Create.Table("ComplexUsageTypes")
                .WithColumn("UsageTypeId").AsInt32().PrimaryKey()
                .WithColumn("ComplexId").AsInt32().PrimaryKey();
        }
        private void CreateUsageTypeTable()
        {
            Create.Table("UsageTypes")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Title").AsString(50).NotNullable();
        }
        private void CreateUnitTable()
        {
            Create.Table("Units")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Resident").AsInt32().NotNullable()
                .WithColumn("BlockId").AsInt32().NotNullable()
                .ForeignKey("FK_Units_Blocks", "Blocks", "Id");
        }
        private void CreateBlockTable()
        {
            Create.Table("Blocks")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("UnitCount").AsInt32().NotNullable()
                .WithColumn("ComplexId").AsInt32().NotNullable()
                .ForeignKey("FK_Blocks_Complexes", "Complexes", "Id");
        }
        private void CreateComplexTable()
        {
            Create.Table("Complexes")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("UnitCount").AsInt32().NotNullable();
        }
    }
}
