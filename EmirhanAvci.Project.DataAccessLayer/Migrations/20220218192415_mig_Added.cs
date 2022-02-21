using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmirhanAvci.Project.DataAccessLayer.Migrations
{
    public partial class mig_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Orders_tbl_Products_ProductId",
                table: "tbl_Orders");

            migrationBuilder.DeleteData(
                table: "tbl_Brands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tbl_Brands",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tbl_Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tbl_Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tbl_Colors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tbl_Colors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tbl_Offers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tbl_Offers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tbl_Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tbl_Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tbl_Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tbl_Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tbl_Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "AAAA",
                table: "tbl_Orders");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "tbl_Orders",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_Orders_ProductId",
                table: "tbl_Orders",
                newName: "IX_tbl_Orders_UserId");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "tbl_Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "tbl_Offers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "tbl_Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 18, 22, 24, 14, 176, DateTimeKind.Local).AddTicks(6047), new DateTime(2022, 2, 18, 22, 24, 14, 177, DateTimeKind.Local).AddTicks(429) });

            migrationBuilder.UpdateData(
                table: "tbl_Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 18, 22, 24, 14, 177, DateTimeKind.Local).AddTicks(2606), new DateTime(2022, 2, 18, 22, 24, 14, 177, DateTimeKind.Local).AddTicks(2611) });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Products_OrderId",
                table: "tbl_Products",
                column: "OrderId",
                unique: true,
                filter: "[OrderId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Offers_UserId",
                table: "tbl_Offers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Offers_tbl_Users_UserId",
                table: "tbl_Offers",
                column: "UserId",
                principalTable: "tbl_Users",
                principalColumn: "Id"
                );

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Orders_tbl_Users_UserId",
                table: "tbl_Orders",
                column: "UserId",
                principalTable: "tbl_Users",
                principalColumn: "Id"
                );

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Products_tbl_Orders_OrderId",
                table: "tbl_Products",
                column: "OrderId",
                principalTable: "tbl_Orders",
                principalColumn: "Id"
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Offers_tbl_Users_UserId",
                table: "tbl_Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Orders_tbl_Users_UserId",
                table: "tbl_Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Products_tbl_Orders_OrderId",
                table: "tbl_Products");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Products_OrderId",
                table: "tbl_Products");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Offers_UserId",
                table: "tbl_Offers");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "tbl_Products");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "tbl_Offers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "tbl_Orders",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_Orders_UserId",
                table: "tbl_Orders",
                newName: "IX_tbl_Orders_ProductId");

            migrationBuilder.AddColumn<string>(
                name: "AAAA",
                table: "tbl_Orders",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "tbl_Brands",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, "InitialCreate", new DateTime(2022, 2, 18, 21, 56, 28, 980, DateTimeKind.Local).AddTicks(1445), true, false, "InitialCreate", new DateTime(2022, 2, 18, 21, 56, 28, 980, DateTimeKind.Local).AddTicks(2949), "Samsung" },
                    { 2, "InitialCreate", new DateTime(2022, 2, 18, 21, 56, 28, 980, DateTimeKind.Local).AddTicks(3260), true, false, "InitialCreate", new DateTime(2022, 2, 18, 21, 56, 28, 980, DateTimeKind.Local).AddTicks(3262), "Slazenger" }
                });

            migrationBuilder.InsertData(
                table: "tbl_Categories",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, "InitialCreate", new DateTime(2022, 2, 18, 21, 56, 28, 983, DateTimeKind.Local).AddTicks(9287), "This Category contains electonical items", true, false, "InitialCreate", new DateTime(2022, 2, 18, 21, 56, 28, 983, DateTimeKind.Local).AddTicks(9920), "Electronic" },
                    { 2, "InitialCreate", new DateTime(2022, 2, 18, 21, 56, 28, 984, DateTimeKind.Local).AddTicks(239), "This Category contains clothes", true, false, "InitialCreate", new DateTime(2022, 2, 18, 21, 56, 28, 984, DateTimeKind.Local).AddTicks(241), "Clothes" }
                });

            migrationBuilder.InsertData(
                table: "tbl_Colors",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, "InitialCreate", new DateTime(2022, 2, 18, 21, 56, 28, 986, DateTimeKind.Local).AddTicks(4229), true, false, "InitialCreate", new DateTime(2022, 2, 18, 21, 56, 28, 986, DateTimeKind.Local).AddTicks(4260), "Red" },
                    { 2, "InitialCreate", new DateTime(2022, 2, 18, 21, 56, 28, 986, DateTimeKind.Local).AddTicks(4825), true, false, "InitialCreate", new DateTime(2022, 2, 18, 21, 56, 28, 986, DateTimeKind.Local).AddTicks(4827), "Blue" }
                });

            migrationBuilder.InsertData(
                table: "tbl_Offers",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "IsAccepted", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Percent", "PercentPrice", "Price", "ProductId" },
                values: new object[,]
                {
                    { 1, "InitialCreate", new DateTime(2022, 2, 18, 21, 56, 28, 996, DateTimeKind.Local).AddTicks(5891), false, true, false, "InitialCreate", new DateTime(2022, 2, 18, 21, 56, 28, 996, DateTimeKind.Local).AddTicks(6385), 40.0, 0.0, 1000.0, 2 },
                    { 2, "InitialCreate", new DateTime(2022, 2, 18, 21, 56, 28, 996, DateTimeKind.Local).AddTicks(8914), true, true, false, "InitialCreate", new DateTime(2022, 2, 18, 21, 56, 28, 996, DateTimeKind.Local).AddTicks(8917), 50.0, 0.0, 1000.0, 2 }
                });

            migrationBuilder.InsertData(
                table: "tbl_Orders",
                columns: new[] { "Id", "AAAA", "AcceptOfferPrice", "CreatedByName", "CreatedDate", "IsActive", "IsBuy", "IsDeleted", "ModifiedByName", "ModifiedDate", "OrderCode", "ProductId" },
                values: new object[] { 1, "aaaa", 500.0, "InitialCreate", new DateTime(2022, 2, 18, 21, 56, 29, 8, DateTimeKind.Local).AddTicks(4896), true, true, false, "InitialCreate", new DateTime(2022, 2, 18, 21, 56, 29, 8, DateTimeKind.Local).AddTicks(4913), new byte[] { 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49 }, 2 });

            migrationBuilder.UpdateData(
                table: "tbl_Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 18, 21, 56, 29, 16, DateTimeKind.Local).AddTicks(1803), new DateTime(2022, 2, 18, 21, 56, 29, 16, DateTimeKind.Local).AddTicks(2927) });

            migrationBuilder.UpdateData(
                table: "tbl_Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 18, 21, 56, 29, 16, DateTimeKind.Local).AddTicks(3785), new DateTime(2022, 2, 18, 21, 56, 29, 16, DateTimeKind.Local).AddTicks(3790) });

            migrationBuilder.InsertData(
                table: "tbl_Roles",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, "InitialCreate", new DateTime(2022, 2, 18, 21, 56, 29, 21, DateTimeKind.Local).AddTicks(4825), "Full Authorize", true, false, "InitialCreate", new DateTime(2022, 2, 18, 21, 56, 29, 21, DateTimeKind.Local).AddTicks(4867), "Admin" },
                    { 2, "InitialCreate", new DateTime(2022, 2, 18, 21, 56, 29, 21, DateTimeKind.Local).AddTicks(4890), "Buy Authorize", true, false, "InitialCreate", new DateTime(2022, 2, 18, 21, 56, 29, 21, DateTimeKind.Local).AddTicks(4894), "User" }
                });

            migrationBuilder.InsertData(
                table: "tbl_Users",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Email", "FirstName", "IsActive", "IsDeleted", "LastName", "ModifiedByName", "ModifiedDate", "PasswordHash", "RoleId", "UserName" },
                values: new object[] { 1, "InitialCreate", new DateTime(2022, 2, 18, 21, 56, 29, 27, DateTimeKind.Local).AddTicks(30), "emir97han@gmail.com", "Emir", true, false, "Avci", "InitialCreate", new DateTime(2022, 2, 18, 21, 56, 29, 27, DateTimeKind.Local).AddTicks(52), new byte[] { 48, 49, 57, 50, 48, 50, 51, 97, 55, 98, 98, 100, 55, 51, 50, 53, 48, 53, 49, 54, 102, 48, 54, 57, 100, 102, 49, 56, 98, 53, 48, 48 }, 1, "Berengar" });

            migrationBuilder.InsertData(
                table: "tbl_Users",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Email", "FirstName", "IsActive", "IsDeleted", "LastName", "ModifiedByName", "ModifiedDate", "PasswordHash", "RoleId", "UserName" },
                values: new object[] { 2, "InitialCreate", new DateTime(2022, 2, 18, 21, 56, 29, 27, DateTimeKind.Local).AddTicks(1089), "soba97@gmail.com", "Furkan", true, false, "Soba", "InitialCreate", new DateTime(2022, 2, 18, 21, 56, 29, 27, DateTimeKind.Local).AddTicks(1090), new byte[] { 54, 97, 100, 49, 52, 98, 97, 57, 57, 56, 54, 101, 51, 54, 49, 53, 52, 50, 51, 100, 102, 99, 97, 50, 53, 54, 100, 48, 52, 101, 51, 102 }, 2, "Soba" });

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Orders_tbl_Products_ProductId",
                table: "tbl_Orders",
                column: "ProductId",
                principalTable: "tbl_Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
