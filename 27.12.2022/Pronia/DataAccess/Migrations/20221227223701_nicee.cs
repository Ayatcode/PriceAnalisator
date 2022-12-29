using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class nicee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShippingItem",
                table: "ShippingItem");

            migrationBuilder.RenameTable(
                name: "ShippingItem",
                newName: "ShippingItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShippingItems",
                table: "ShippingItems",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShippingItems",
                table: "ShippingItems");

            migrationBuilder.RenameTable(
                name: "ShippingItems",
                newName: "ShippingItem");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShippingItem",
                table: "ShippingItem",
                column: "Id");
        }
    }
}
