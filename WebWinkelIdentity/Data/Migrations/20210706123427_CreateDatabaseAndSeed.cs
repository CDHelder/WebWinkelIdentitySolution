using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebWinkelIdentity.Data.Migrations
{
    public partial class CreateDatabaseAndSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductCategorySizesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeekOpeningTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekOpeningTimes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brands_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DayOpeningTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeekOpeningTimesId = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpeningTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    ClosingTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    IsClosed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayOpeningTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DayOpeningTimes_WeekOpeningTimes_WeekOpeningTimesId",
                        column: x => x.WeekOpeningTimesId,
                        principalTable: "WeekOpeningTimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fabric = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    IsDelivered = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    WeekOpeningTimesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stores_WeekOpeningTimes_WeekOpeningTimesId",
                        column: x => x.WeekOpeningTimesId,
                        principalTable: "WeekOpeningTimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    IBAN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentlyEmployed = table.Column<bool>(type: "bit", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreProducts", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SupplierId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Streetname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseNumber = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreProductDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreProductId = table.Column<int>(type: "int", nullable: false),
                    InternationalSizingType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountInStock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreProductDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreProductDetails_StoreProducts_StoreProductId",
                        column: x => x.StoreProductId,
                        principalTable: "StoreProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "CustomerId", "EmployeeId", "HouseNumber", "PostalCode", "Streetname", "SupplierId" },
                values: new object[,]
                {
                    { 3, "Den Haag", "Netherlands", null, null, 26, "8137 YA", "Korte poten", null },
                    { 4, "Rotterdam", "Netherlands", null, null, 12, "6573 IK", "Lijnbaan", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "789934cd-1e93-49a0-aa36-9baa9be02701", 0, "90018819-233a-4479-98c5-68fed61c0a4e", "Jaap@gmail.com", false, false, null, null, null, null, null, false, "7330972f-9dac-4750-b058-3926a69ff149", false, "Jaap123" },
                    { "b7d556f6-a67b-4400-9f8b-2c4caf9122e3", 0, "0e5c033a-60f4-4185-97d9-61cc3ca339b2", "GroothandelDeBos@gmail.com", false, false, null, null, null, null, "01012346543", false, "2a5f71ce-4bd0-492e-8201-dc1c53befb03", false, "Groothandeldebos" },
                    { "b7d770ce-4f5e-4337-926e-442375b14c70", 0, "0378988d-105c-4558-93f4-01d344cdc7e0", null, false, false, null, null, null, null, null, false, "3ba2219e-a34f-4989-830f-7e5aa15321b9", false, null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "ProductCategorySizesId" },
                values: new object[,]
                {
                    { 1, "Broek met wijde pijpen", "Broek", 0 },
                    { 2, "T-shirt met korte mouwen", "T-shirt", 0 }
                });

            migrationBuilder.InsertData(
                table: "WeekOpeningTimes",
                column: "Id",
                value: 1);

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name" },
                values: new object[] { "789934cd-1e93-49a0-aa36-9baa9be02701", "Jaap" });

            migrationBuilder.InsertData(
                table: "DayOpeningTimes",
                columns: new[] { "Id", "ClosingTime", "Day", "IsClosed", "OpeningTime", "WeekOpeningTimesId" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 17, 0, 0, 0), "Monday", false, new TimeSpan(0, 9, 0, 0, 0), 1 },
                    { 2, new TimeSpan(0, 17, 0, 0, 0), "Tuesday", false, new TimeSpan(0, 9, 0, 0, 0), 1 },
                    { 3, new TimeSpan(0, 17, 0, 0, 0), "Wednesday", false, new TimeSpan(0, 9, 0, 0, 0), 1 },
                    { 4, new TimeSpan(0, 17, 0, 0, 0), "Thursday", false, new TimeSpan(0, 9, 0, 0, 0), 1 },
                    { 5, new TimeSpan(0, 17, 0, 0, 0), "Friday", false, new TimeSpan(0, 9, 0, 0, 0), 1 },
                    { 6, new TimeSpan(0, 17, 0, 0, 0), "Saterday", false, new TimeSpan(0, 9, 0, 0, 0), 1 },
                    { 7, null, "Sunday", true, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "AddressId", "WeekOpeningTimesId" },
                values: new object[] { 1, 4, 1 });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { "b7d556f6-a67b-4400-9f8b-2c4caf9122e3", "groothandel merkkleding", "Kleding Groothandel de Bos" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "CustomerId", "EmployeeId", "HouseNumber", "PostalCode", "Streetname", "SupplierId" },
                values: new object[,]
                {
                    { 2, "Rotterdam", "Netherlands", "789934cd-1e93-49a0-aa36-9baa9be02701", null, 5, "7431 GG", "Sesamstraat", null },
                    { 1, "Amsterdam", "Netherlands", null, null, 15, "1264 KJ", "Polderweg", "b7d556f6-a67b-4400-9f8b-2c4caf9122e3" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Description", "Name", "SupplierId" },
                values: new object[,]
                {
                    { 1, "Veel te duur", "Gucci", "b7d556f6-a67b-4400-9f8b-2c4caf9122e3" },
                    { 2, "Veel te duur", "Versace", "b7d556f6-a67b-4400-9f8b-2c4caf9122e3" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "AddressId", "CurrentlyEmployed", "IBAN", "Name", "StoreId" },
                values: new object[] { "b7d770ce-4f5e-4337-926e-442375b14c70", 3, false, "NL76 INGB 007 4201 6969", "Samantha", 1 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "AddressId", "CustomerId", "IsDelivered" },
                values: new object[] { 1, 2, "789934cd-1e93-49a0-aa36-9baa9be02701", false });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "Color", "Description", "Fabric", "Name", "Price", "SupplierId" },
                values: new object[,]
                {
                    { 1, 1, 2, null, "Witte kleur met gucci logo", null, "Gucci T-shirt", 39.95m, "b7d556f6-a67b-4400-9f8b-2c4caf9122e3" },
                    { 2, 1, 1, null, "Lichte broek met gucci logo", null, "Gucci Broek", 59.95m, "b7d556f6-a67b-4400-9f8b-2c4caf9122e3" },
                    { 3, 2, 2, null, "Licht shirt met versace logo", null, "Versace T-shirt", 45.95m, "b7d556f6-a67b-4400-9f8b-2c4caf9122e3" },
                    { 4, 2, 1, null, "Donkere broek met versace logo", null, "Versace Broek", 69.95m, "b7d556f6-a67b-4400-9f8b-2c4caf9122e3" }
                });

            migrationBuilder.InsertData(
                table: "OrderProducts",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity", "TotalPrice" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 0m },
                    { 2, 1, 2, 1, 0m },
                    { 3, 1, 3, 1, 0m },
                    { 4, 1, 4, 1, 0m }
                });

            migrationBuilder.InsertData(
                table: "StoreProducts",
                columns: new[] { "Id", "ProductId", "StoreId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "StoreProductDetails",
                columns: new[] { "Id", "AmountInStock", "InternationalSizingType", "Size", "StoreProductId" },
                values: new object[,]
                {
                    { 1, 2, "EU", "S", 1 },
                    { 2, 2, "EU", "M", 1 },
                    { 3, 2, "EU", "L", 1 },
                    { 4, 1, "EU", "XL", 1 },
                    { 5, 2, "EU", "S", 2 },
                    { 6, 2, "EU", "M", 2 },
                    { 7, 2, "EU", "L", 2 },
                    { 8, 1, "EU", "XL", 2 },
                    { 9, 2, "EU", "S", 3 },
                    { 10, 2, "EU", "M", 3 },
                    { 11, 2, "EU", "L", 3 },
                    { 12, 1, "EU", "XL", 3 },
                    { 13, 2, "EU", "S", 4 },
                    { 14, 2, "EU", "M", 4 },
                    { 15, 2, "EU", "L", 4 },
                    { 16, 1, "EU", "XL", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_EmployeeId",
                table: "Addresses",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_SupplierId",
                table: "Addresses",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_SupplierId",
                table: "Brands",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_DayOpeningTimes_WeekOpeningTimesId",
                table: "DayOpeningTimes",
                column: "WeekOpeningTimesId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_StoreId",
                table: "Employees",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderId",
                table: "OrderProducts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductId",
                table: "OrderProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AddressId",
                table: "Orders",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierId",
                table: "Products",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreProductDetails_StoreProductId",
                table: "StoreProductDetails",
                column: "StoreProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreProducts_ProductId",
                table: "StoreProducts",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoreProducts_StoreId",
                table: "StoreProducts",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_AddressId",
                table: "Stores",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stores_WeekOpeningTimesId",
                table: "Stores",
                column: "WeekOpeningTimesId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_AddressId",
                table: "Orders",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Addresses_AddressId",
                table: "Stores",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Customers_CustomerId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Employees_EmployeeId",
                table: "Addresses");

            migrationBuilder.DropTable(
                name: "DayOpeningTimes");

            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "StoreProductDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "StoreProducts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "WeekOpeningTimes");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b7d770ce-4f5e-4337-926e-442375b14c70");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "789934cd-1e93-49a0-aa36-9baa9be02701");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b7d556f6-a67b-4400-9f8b-2c4caf9122e3");
        }
    }
}
