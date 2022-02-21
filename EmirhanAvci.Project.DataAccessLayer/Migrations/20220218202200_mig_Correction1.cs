using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmirhanAvci.Project.DataAccessLayer.Migrations
{
    public partial class mig_Correction1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tbl_Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tbl_Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "PercentPrice",
                table: "tbl_Offers");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "tbl_Offers");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "tbl_Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SoldPrice",
                table: "tbl_Products",
                type: "float",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Percent",
                table: "tbl_Offers",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "tbl_Products");

            migrationBuilder.DropColumn(
                name: "SoldPrice",
                table: "tbl_Products");

            migrationBuilder.AlterColumn<double>(
                name: "Percent",
                table: "tbl_Offers",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PercentPrice",
                table: "tbl_Offers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "tbl_Offers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "tbl_Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "ColorId", "CreatedByName", "CreatedDate", "Description", "IsActive", "IsDeleted", "IsOfferable", "ModifiedByName", "ModifiedDate", "Name", "OrderId", "UserId" },
                values: new object[] { 1, 1, 1, 1, "InitialCreate", new DateTime(2022, 2, 18, 22, 24, 14, 176, DateTimeKind.Local).AddTicks(6047), "First Product", true, false, true, "InitialCreate", new DateTime(2022, 2, 18, 22, 24, 14, 177, DateTimeKind.Local).AddTicks(429), "Android Phone", null, 1 });

            migrationBuilder.InsertData(
                table: "tbl_Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "ColorId", "CreatedByName", "CreatedDate", "Description", "IsActive", "IsDeleted", "IsSold", "ModifiedByName", "ModifiedDate", "Name", "OrderId", "UserId" },
                values: new object[] { 2, 2, 2, 2, "InitialCreate", new DateTime(2022, 2, 18, 22, 24, 14, 177, DateTimeKind.Local).AddTicks(2606), "Second Product", true, false, true, "InitialCreate", new DateTime(2022, 2, 18, 22, 24, 14, 177, DateTimeKind.Local).AddTicks(2611), "Shoes", null, 1 });
        }
    }
}
