using Microsoft.EntityFrameworkCore.Migrations;

namespace WebWinkelIdentity.Data.Migrations
{
    public partial class SeedDataTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1c2b4740-5699-438c-97c3-9d4c5856c28c", 0, "b2a04f90-e0cf-41ca-85fd-96549c3bc6f7", "Jaap@gmail.com", false, false, null, null, null, null, null, false, "29ea0e19-ad67-4d17-bde7-8380af97bad1", false, "Jaap123" },
                    { "d1ed4579-9b47-4578-bae1-92400e83555b", 0, "932a9b8a-0ce8-499e-a977-d591bfe25abd", "GroothandelDeBos@gmail.com", false, false, null, null, null, null, "01012346543", false, "61941ef6-af90-447d-aee4-f069d892873a", false, "Groothandeldebos" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Broek met wijde pijpen", "Broek" },
                    { 2, "T-shirt met korte mouwen", "T-shirt" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name" },
                values: new object[] { "1c2b4740-5699-438c-97c3-9d4c5856c28c", "Jaap" });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { "d1ed4579-9b47-4578-bae1-92400e83555b", "groothandel merkkleding", "Kleding Groothandel de Bos" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "CustomerId", "HouseNumber", "PostalCode", "Streetname", "SupplierId" },
                values: new object[,]
                {
                    { 2, "Rotterdam", "Netherlands", "1c2b4740-5699-438c-97c3-9d4c5856c28c", 5, "7431 GG", "Sesamstraat", null },
                    { 1, "Amsterdam", "Netherlands", null, 15, "1264 KJ", "Polderweg", "d1ed4579-9b47-4578-bae1-92400e83555b" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Description", "Name", "SupplierId" },
                values: new object[,]
                {
                    { 1, "Veel te duur", "Gucci", "d1ed4579-9b47-4578-bae1-92400e83555b" },
                    { 2, "Veel te duur", "Versace", "d1ed4579-9b47-4578-bae1-92400e83555b" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AmountInStock", "BrandId", "CategoryId", "Description", "Name", "Price", "SupplierId" },
                values: new object[,]
                {
                    { 1, 4, 1, 2, "Witte kleur met gucci logo", "Gucci T-shirt", 39.95m, "d1ed4579-9b47-4578-bae1-92400e83555b" },
                    { 2, 3, 1, 1, "Lichte broek met gucci logo", "Gucci Broek", 59.95m, "d1ed4579-9b47-4578-bae1-92400e83555b" },
                    { 3, 6, 2, 2, "Licht shirt met versace logo", "Versace T-shirt", 45.95m, "d1ed4579-9b47-4578-bae1-92400e83555b" },
                    { 4, 2, 2, 1, "Donkere broek met versace logo", "Versace Broek", 69.95m, "d1ed4579-9b47-4578-bae1-92400e83555b" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "1c2b4740-5699-438c-97c3-9d4c5856c28c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1c2b4740-5699-438c-97c3-9d4c5856c28c");

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: "d1ed4579-9b47-4578-bae1-92400e83555b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d1ed4579-9b47-4578-bae1-92400e83555b");
        }
    }
}
