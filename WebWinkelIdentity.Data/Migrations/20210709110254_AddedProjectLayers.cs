using Microsoft.EntityFrameworkCore.Migrations;

namespace WebWinkelIdentity.Data.Migrations
{
    public partial class AddedProjectLayers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AmountInStock",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52a5d716-a649-4476-b316-108d96c56112",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f1c06b6d-1e3b-49bc-90ae-ebeeb20ac404", "ac3ec3db-31d5-43a6-b7fa-f26841154c59" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7036d951-7cc8-488f-b95b-10c2e96c31c9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "eab7147d-e62e-49f0-b65c-837c2638f385", "dbb134ac-44eb-44d0-a0d3-b6431d590482" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AmountInStock", "Size" },
                values: new object[] { 2, "S" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AmountInStock", "CategoryId", "Color", "Description", "Name", "Price", "Size" },
                values: new object[] { 2, 2, "White", "Witte kleur met gucci logo", "Gucci T-shirt", 39.95m, "M" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AmountInStock", "BrandId", "Color", "Description", "Name", "Price", "Size" },
                values: new object[] { 2, 1, "White", "Witte kleur met gucci logo", "Gucci T-shirt", 39.95m, "L" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AmountInStock", "BrandId", "CategoryId", "Color", "Description", "Name", "Price", "Size" },
                values: new object[] { 1, 1, 2, "White", "Witte kleur met gucci logo", "Gucci T-shirt", 39.95m, "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AmountInStock", "BrandId", "CategoryId", "Color", "Description", "Fabric", "Name", "Price", "Size" },
                values: new object[,]
                {
                    { 5, 0, 1, 1, "Light-Blue", "Lichte broek met gucci logo", "100% Cotton", "Gucci Broek", 59.95m, null },
                    { 9, 0, 2, 2, "Light-Yellow", "Licht shirt met versace logo", "100% Cotton", "Versace T-shirt", 45.95m, null },
                    { 13, 0, 2, 1, "Dark-Blue", "Donkere broek met versace logo", "100% Cotton", "Versace Broek", 69.95m, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DropColumn(
                name: "AmountInStock",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Products");

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
                keyValue: 2,
                columns: new[] { "CategoryId", "Color", "Description", "Name", "Price" },
                values: new object[] { 1, "Light-Blue", "Lichte broek met gucci logo", "Gucci Broek", 59.95m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BrandId", "Color", "Description", "Name", "Price" },
                values: new object[] { 2, "Light-Yellow", "Licht shirt met versace logo", "Versace T-shirt", 45.95m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BrandId", "CategoryId", "Color", "Description", "Name", "Price" },
                values: new object[] { 2, 1, "Dark-Blue", "Donkere broek met versace logo", "Versace Broek", 69.95m });
        }
    }
}
