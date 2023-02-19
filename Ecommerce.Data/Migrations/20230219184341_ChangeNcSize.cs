using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Data.Migrations
{
    public partial class ChangeNcSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "dbo",
                table: "NcfSequences",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 19, 14, 43, 41, 222, DateTimeKind.Local).AddTicks(843),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 19, 14, 41, 7, 5, DateTimeKind.Local).AddTicks(1850));

            migrationBuilder.AlterColumn<string>(
                name: "Ncf",
                schema: "dbo",
                table: "Invoices",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InvoiceDate",
                schema: "dbo",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 19, 14, 43, 41, 222, DateTimeKind.Local).AddTicks(1040),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                oldDefaultValue: new DateTime(2023, 2, 19, 14, 43, 41, 222, DateTimeKind.Local).AddTicks(843));

            migrationBuilder.AlterColumn<string>(
                name: "Ncf",
                schema: "dbo",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InvoiceDate",
                schema: "dbo",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 19, 14, 43, 41, 222, DateTimeKind.Local).AddTicks(1040));
        }
    }
}
