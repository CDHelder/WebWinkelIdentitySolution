using Microsoft.EntityFrameworkCore.Migrations;

namespace WebWinkelIdentity.Data.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_Stores_StoreId",
                table: "ProductDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProductDetails_StoreId",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "ProductDetails");

            migrationBuilder.CreateTable(
                name: "StoreProducts",
                columns: table => new
                {
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreProducts", x => new { x.ProductId, x.StoreId });
                    table.ForeignKey(
                        name: "FK_StoreProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreProducts_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52a5d716-a649-4476-b316-108d96c56112",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c84c3bd8-361e-4dda-8b69-9493fc7111d1", "f267ed7d-2a42-4a22-94c2-cc3b3e1f2267" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7036d951-7cc8-488f-b95b-10c2e96c31c9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ad5131cf-7ced-4434-aa11-5de7c87e23cd", "c12ce2fd-34cb-4ff1-855f-7183f7b8fe29" });

            migrationBuilder.InsertData(
                table: "StoreProducts",
                columns: new[] { "ProductId", "StoreId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StoreProducts_StoreId",
                table: "StoreProducts",
                column: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoreProducts");

            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "ProductDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52a5d716-a649-4476-b316-108d96c56112",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3f9af281-baa5-47f2-b9fc-be3c8acc7fd5", "27aedd85-bb9f-4e42-86a9-727ee58e0677" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7036d951-7cc8-488f-b95b-10c2e96c31c9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5a588f05-5846-4074-bd37-157067e8b38c", "e944a957-6e08-45db-9b1d-c7781fb6d37f" });

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "StoreId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 2,
                column: "StoreId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 3,
                column: "StoreId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 4,
                column: "StoreId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 5,
                column: "StoreId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 6,
                column: "StoreId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 7,
                column: "StoreId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 8,
                column: "StoreId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 9,
                column: "StoreId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 10,
                column: "StoreId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 11,
                column: "StoreId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 12,
                column: "StoreId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 13,
                column: "StoreId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 14,
                column: "StoreId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 15,
                column: "StoreId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 16,
                column: "StoreId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_StoreId",
                table: "ProductDetails",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_Stores_StoreId",
                table: "ProductDetails",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
