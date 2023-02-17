using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Data.Migrations
{
    public partial class addingInvoiceDateToInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                oldDefaultValue: new DateTime(2023, 2, 16, 21, 48, 22, 845, DateTimeKind.Local).AddTicks(6037));

            migrationBuilder.AddColumn<DateTime>(
                name: "InvoiceDate",
                schema: "dbo",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceDate",
                schema: "dbo",
                table: "Invoices");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "dbo",
                table: "NcfSequences",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 16, 21, 48, 22, 845, DateTimeKind.Local).AddTicks(6037),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 16, 22, 45, 27, 786, DateTimeKind.Local).AddTicks(6247));
        }
    }
}
