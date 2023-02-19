using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Data.Migrations
{
    public partial class ChangeNCFToNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "dbo",
                table: "NcfSequences",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 19, 14, 41, 7, 5, DateTimeKind.Local).AddTicks(1850),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 16, 22, 45, 27, 786, DateTimeKind.Local).AddTicks(6247));

            migrationBuilder.AlterColumn<string>(
                name: "Ncf",
                schema: "dbo",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "dbo",
                table: "NcfSequences",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 16, 22, 45, 27, 786, DateTimeKind.Local).AddTicks(6247),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 19, 14, 41, 7, 5, DateTimeKind.Local).AddTicks(1850));

            migrationBuilder.AlterColumn<string>(
                name: "Ncf",
                schema: "dbo",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
