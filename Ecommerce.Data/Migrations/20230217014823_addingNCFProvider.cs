using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Data.Migrations
{
    public partial class addingNCFProvider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NcfSequences",
                schema: "dbo",
                columns: table => new
                {
                    SequenceId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Serie = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    VoucherType = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    StartSequence = table.Column<int>(type: "int", nullable: false),
                    EndSequence = table.Column<int>(type: "int", nullable: false),
                    LastUsedSequence = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 2, 16, 21, 48, 22, 845, DateTimeKind.Local).AddTicks(6037)),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NcfSequences", x => x.SequenceId);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "NcfSequences",
                columns: new[] { "SequenceId", "EndSequence", "IsActive", "LastUpdateDate", "LastUsedSequence", "Serie", "StartSequence", "VoucherType" },
                values: new object[] { 1L, 30000, true, null, null, "B", 1, "01" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NcfSequences",
                schema: "dbo");
        }
    }
}
