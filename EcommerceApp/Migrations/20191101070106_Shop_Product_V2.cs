using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceApp.Migrations
{
    public partial class Shop_Product_V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Shops_ShopId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ShopId",
                table: "Products",
                newName: "DokanId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ShopId",
                table: "Products",
                newName: "IX_Products_DokanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Shops_DokanId",
                table: "Products",
                column: "DokanId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Shops_DokanId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "DokanId",
                table: "Products",
                newName: "ShopId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_DokanId",
                table: "Products",
                newName: "IX_Products_ShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Shops_ShopId",
                table: "Products",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
