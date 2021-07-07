using Microsoft.EntityFrameworkCore.Migrations;

namespace WebWinkelIdentity.Data.Migrations
{
    public partial class AddColours : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52a5d716-a649-4476-b316-108d96c56112",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "64526f2f-96d9-49a6-8772-7fc526cf28e6", "5532a4d7-ec62-4cc5-b51f-620ee5937f8a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7036d951-7cc8-488f-b95b-10c2e96c31c9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "51b9d2f3-13ab-4fdc-9da3-8e9f965fb7cb", "2721a134-e95a-4114-a68c-bc4187f403ce" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Color", "Fabric" },
                values: new object[] { "White", "100% Cotton" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Color", "Fabric" },
                values: new object[] { "Light-Blue", "100% Cotton" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Color", "Fabric" },
                values: new object[] { "Light-Yellow", "100% Cotton" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Color", "Fabric" },
                values: new object[] { "Dark-Blue", "100% Cotton" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Color", "Fabric" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Color", "Fabric" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Color", "Fabric" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Color", "Fabric" },
                values: new object[] { null, null });
        }
    }
}
