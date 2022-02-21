using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmirhanAvci.Project.DataAccessLayer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "VARBINARY(500)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Users_tbl_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "tbl_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    IsOfferable = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsSold = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Products_tbl_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "tbl_Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Products_tbl_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "tbl_Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Products_tbl_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "tbl_Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Products_tbl_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "tbl_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Offers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Percent = table.Column<double>(type: "float", nullable: false),
                    PercentPrice = table.Column<double>(type: "float", nullable: false),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Offers_tbl_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "tbl_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderCode = table.Column<byte[]>(type: "varbinary(12)", maxLength: 12, nullable: false),
                    IsBuy = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    AcceptOfferPrice = table.Column<double>(type: "float", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Orders_tbl_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "tbl_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tbl_Brands",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, "InitialCreate", new DateTime(2022, 2, 17, 21, 10, 7, 476, DateTimeKind.Local).AddTicks(1553), true, false, "InitialCreate", new DateTime(2022, 2, 17, 21, 10, 7, 476, DateTimeKind.Local).AddTicks(3641), "Samsung" },
                    { 2, "InitialCreate", new DateTime(2022, 2, 17, 21, 10, 7, 476, DateTimeKind.Local).AddTicks(4104), true, false, "InitialCreate", new DateTime(2022, 2, 17, 21, 10, 7, 476, DateTimeKind.Local).AddTicks(4106), "Slazenger" }
                });

            migrationBuilder.InsertData(
                table: "tbl_Categories",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, "InitialCreate", new DateTime(2022, 2, 17, 21, 10, 7, 480, DateTimeKind.Local).AddTicks(3894), "This Category contains electonical items", true, false, "InitialCreate", new DateTime(2022, 2, 17, 21, 10, 7, 480, DateTimeKind.Local).AddTicks(4634), "Electronic" },
                    { 2, "InitialCreate", new DateTime(2022, 2, 17, 21, 10, 7, 480, DateTimeKind.Local).AddTicks(4998), "This Category contains clothes", true, false, "InitialCreate", new DateTime(2022, 2, 17, 21, 10, 7, 480, DateTimeKind.Local).AddTicks(5003), "Clothes" }
                });

            migrationBuilder.InsertData(
                table: "tbl_Colors",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, "InitialCreate", new DateTime(2022, 2, 17, 21, 10, 7, 482, DateTimeKind.Local).AddTicks(4521), true, false, "InitialCreate", new DateTime(2022, 2, 17, 21, 10, 7, 482, DateTimeKind.Local).AddTicks(4534), "Red" },
                    { 2, "InitialCreate", new DateTime(2022, 2, 17, 21, 10, 7, 482, DateTimeKind.Local).AddTicks(5009), true, false, "InitialCreate", new DateTime(2022, 2, 17, 21, 10, 7, 482, DateTimeKind.Local).AddTicks(5011), "Blue" }
                });

            migrationBuilder.InsertData(
                table: "tbl_Roles",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, "InitialCreate", new DateTime(2022, 2, 17, 21, 10, 7, 509, DateTimeKind.Local).AddTicks(8505), "Full Authorize", true, false, "InitialCreate", new DateTime(2022, 2, 17, 21, 10, 7, 509, DateTimeKind.Local).AddTicks(8524), "Admin" },
                    { 2, "InitialCreate", new DateTime(2022, 2, 17, 21, 10, 7, 509, DateTimeKind.Local).AddTicks(8535), "Buy Authorize", true, false, "InitialCreate", new DateTime(2022, 2, 17, 21, 10, 7, 509, DateTimeKind.Local).AddTicks(8537), "User" }
                });

            migrationBuilder.InsertData(
                table: "tbl_Users",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Email", "FirstName", "IsActive", "IsDeleted", "LastName", "ModifiedByName", "ModifiedDate", "PasswordHash", "RoleId", "UserName" },
                values: new object[] { 1, "InitialCreate", new DateTime(2022, 2, 17, 21, 10, 7, 515, DateTimeKind.Local).AddTicks(1604), "emir97han@gmail.com", "Emir", true, false, "Avci", "InitialCreate", new DateTime(2022, 2, 17, 21, 10, 7, 515, DateTimeKind.Local).AddTicks(1618), new byte[] { 48, 49, 57, 50, 48, 50, 51, 97, 55, 98, 98, 100, 55, 51, 50, 53, 48, 53, 49, 54, 102, 48, 54, 57, 100, 102, 49, 56, 98, 53, 48, 48 }, 1, "Berengar" });

            migrationBuilder.InsertData(
                table: "tbl_Users",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Email", "FirstName", "IsActive", "IsDeleted", "LastName", "ModifiedByName", "ModifiedDate", "PasswordHash", "RoleId", "UserName" },
                values: new object[] { 2, "InitialCreate", new DateTime(2022, 2, 17, 21, 10, 7, 515, DateTimeKind.Local).AddTicks(2445), "soba97@gmail.com", "Furkan", true, false, "Soba", "InitialCreate", new DateTime(2022, 2, 17, 21, 10, 7, 515, DateTimeKind.Local).AddTicks(2446), new byte[] { 54, 97, 100, 49, 52, 98, 97, 57, 57, 56, 54, 101, 51, 54, 49, 53, 52, 50, 51, 100, 102, 99, 97, 50, 53, 54, 100, 48, 52, 101, 51, 102 }, 2, "Soba" });

            migrationBuilder.InsertData(
                table: "tbl_Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "ColorId", "CreatedByName", "CreatedDate", "Description", "IsActive", "IsDeleted", "IsOfferable", "ModifiedByName", "ModifiedDate", "Name", "UserId" },
                values: new object[] { 1, 1, 1, 1, "InitialCreate", new DateTime(2022, 2, 17, 21, 10, 7, 507, DateTimeKind.Local).AddTicks(5038), "First Product", true, false, true, "InitialCreate", new DateTime(2022, 2, 17, 21, 10, 7, 507, DateTimeKind.Local).AddTicks(6082), "Android Phone", 1 });

            migrationBuilder.InsertData(
                table: "tbl_Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "ColorId", "CreatedByName", "CreatedDate", "Description", "IsActive", "IsDeleted", "IsSold", "ModifiedByName", "ModifiedDate", "Name", "UserId" },
                values: new object[] { 2, 2, 2, 2, "InitialCreate", new DateTime(2022, 2, 17, 21, 10, 7, 507, DateTimeKind.Local).AddTicks(6962), "Second Product", true, false, true, "InitialCreate", new DateTime(2022, 2, 17, 21, 10, 7, 507, DateTimeKind.Local).AddTicks(6965), "Shoes", 1 });

            migrationBuilder.InsertData(
                table: "tbl_Offers",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "IsAccepted", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Percent", "PercentPrice", "Price", "ProductId" },
                values: new object[] { 1, "InitialCreate", new DateTime(2022, 2, 17, 21, 10, 7, 490, DateTimeKind.Local).AddTicks(9687), false, true, false, "InitialCreate", new DateTime(2022, 2, 17, 21, 10, 7, 491, DateTimeKind.Local).AddTicks(216), 40.0, 0.0, 1000.0, 2 });

            migrationBuilder.InsertData(
                table: "tbl_Offers",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "IsAccepted", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Percent", "PercentPrice", "Price", "ProductId" },
                values: new object[] { 2, "InitialCreate", new DateTime(2022, 2, 17, 21, 10, 7, 491, DateTimeKind.Local).AddTicks(4069), true, true, false, "InitialCreate", new DateTime(2022, 2, 17, 21, 10, 7, 491, DateTimeKind.Local).AddTicks(4072), 50.0, 0.0, 1000.0, 2 });

            migrationBuilder.InsertData(
                table: "tbl_Orders",
                columns: new[] { "Id", "AcceptOfferPrice", "CreatedByName", "CreatedDate", "IsActive", "IsBuy", "IsDeleted", "ModifiedByName", "ModifiedDate", "OrderCode", "ProductId" },
                values: new object[] { 1, 500.0, "InitialCreate", new DateTime(2022, 2, 17, 21, 10, 7, 499, DateTimeKind.Local).AddTicks(7593), true, true, false, "InitialCreate", new DateTime(2022, 2, 17, 21, 10, 7, 499, DateTimeKind.Local).AddTicks(7638), new byte[] { 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49 }, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Brands_Name",
                table: "tbl_Brands",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Categories_Name",
                table: "tbl_Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Colors_Name",
                table: "tbl_Colors",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Offers_ProductId",
                table: "tbl_Offers",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Orders_ProductId",
                table: "tbl_Orders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Products_BrandId",
                table: "tbl_Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Products_CategoryId",
                table: "tbl_Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Products_ColorId",
                table: "tbl_Products",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Products_UserId",
                table: "tbl_Products",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Users_Email",
                table: "tbl_Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Users_RoleId",
                table: "tbl_Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Users_UserName",
                table: "tbl_Users",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Offers");

            migrationBuilder.DropTable(
                name: "tbl_Orders");

            migrationBuilder.DropTable(
                name: "tbl_Products");

            migrationBuilder.DropTable(
                name: "tbl_Brands");

            migrationBuilder.DropTable(
                name: "tbl_Categories");

            migrationBuilder.DropTable(
                name: "tbl_Colors");

            migrationBuilder.DropTable(
                name: "tbl_Users");

            migrationBuilder.DropTable(
                name: "tbl_Roles");
        }
    }
}
