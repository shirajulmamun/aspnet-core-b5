using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceApp.Migrations
{
    public partial class Product_Deleteable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeleteRemarks",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedById",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Products",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleteRemarks",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Products");
        }
    }
}
