using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceApp.Migrations
{
    public partial class Customer_Name_Changed_CustomerNameColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "clients",
                newName: "CustomerName");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerName",
                table: "clients",
                type: "varchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerName",
                table: "clients",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "clients",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldNullable: true);
        }
    }
}
