using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmirhanAvci.Project.DataAccessLayer.Migrations
{
    public partial class mig_Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AAAA",
                table: "tbl_Orders",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "tbl_Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 18, 21, 56, 28, 980, DateTimeKind.Local).AddTicks(1445), new DateTime(2022, 2, 18, 21, 56, 28, 980, DateTimeKind.Local).AddTicks(2949) });

            migrationBuilder.UpdateData(
                table: "tbl_Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 18, 21, 56, 28, 980, DateTimeKind.Local).AddTicks(3260), new DateTime(2022, 2, 18, 21, 56, 28, 980, DateTimeKind.Local).AddTicks(3262) });

            migrationBuilder.UpdateData(
                table: "tbl_Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 18, 21, 56, 28, 983, DateTimeKind.Local).AddTicks(9287), new DateTime(2022, 2, 18, 21, 56, 28, 983, DateTimeKind.Local).AddTicks(9920) });

            migrationBuilder.UpdateData(
                table: "tbl_Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 18, 21, 56, 28, 984, DateTimeKind.Local).AddTicks(239), new DateTime(2022, 2, 18, 21, 56, 28, 984, DateTimeKind.Local).AddTicks(241) });

            migrationBuilder.UpdateData(
                table: "tbl_Colors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 18, 21, 56, 28, 986, DateTimeKind.Local).AddTicks(4229), new DateTime(2022, 2, 18, 21, 56, 28, 986, DateTimeKind.Local).AddTicks(4260) });

            migrationBuilder.UpdateData(
                table: "tbl_Colors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 18, 21, 56, 28, 986, DateTimeKind.Local).AddTicks(4825), new DateTime(2022, 2, 18, 21, 56, 28, 986, DateTimeKind.Local).AddTicks(4827) });

            migrationBuilder.UpdateData(
                table: "tbl_Offers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 18, 21, 56, 28, 996, DateTimeKind.Local).AddTicks(5891), new DateTime(2022, 2, 18, 21, 56, 28, 996, DateTimeKind.Local).AddTicks(6385) });

            migrationBuilder.UpdateData(
                table: "tbl_Offers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 18, 21, 56, 28, 996, DateTimeKind.Local).AddTicks(8914), new DateTime(2022, 2, 18, 21, 56, 28, 996, DateTimeKind.Local).AddTicks(8917) });

            migrationBuilder.UpdateData(
                table: "tbl_Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AAAA", "CreatedDate", "ModifiedDate" },
                values: new object[] { "aaaa", new DateTime(2022, 2, 18, 21, 56, 29, 8, DateTimeKind.Local).AddTicks(4896), new DateTime(2022, 2, 18, 21, 56, 29, 8, DateTimeKind.Local).AddTicks(4913) });

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

            migrationBuilder.UpdateData(
                table: "tbl_Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 18, 21, 56, 29, 21, DateTimeKind.Local).AddTicks(4825), new DateTime(2022, 2, 18, 21, 56, 29, 21, DateTimeKind.Local).AddTicks(4867) });

            migrationBuilder.UpdateData(
                table: "tbl_Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 18, 21, 56, 29, 21, DateTimeKind.Local).AddTicks(4890), new DateTime(2022, 2, 18, 21, 56, 29, 21, DateTimeKind.Local).AddTicks(4894) });

            migrationBuilder.UpdateData(
                table: "tbl_Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 18, 21, 56, 29, 27, DateTimeKind.Local).AddTicks(30), new DateTime(2022, 2, 18, 21, 56, 29, 27, DateTimeKind.Local).AddTicks(52) });

            migrationBuilder.UpdateData(
                table: "tbl_Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 18, 21, 56, 29, 27, DateTimeKind.Local).AddTicks(1089), new DateTime(2022, 2, 18, 21, 56, 29, 27, DateTimeKind.Local).AddTicks(1090) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AAAA",
                table: "tbl_Orders");

            migrationBuilder.UpdateData(
                table: "tbl_Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 17, 21, 10, 7, 476, DateTimeKind.Local).AddTicks(1553), new DateTime(2022, 2, 17, 21, 10, 7, 476, DateTimeKind.Local).AddTicks(3641) });

            migrationBuilder.UpdateData(
                table: "tbl_Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 17, 21, 10, 7, 476, DateTimeKind.Local).AddTicks(4104), new DateTime(2022, 2, 17, 21, 10, 7, 476, DateTimeKind.Local).AddTicks(4106) });

            migrationBuilder.UpdateData(
                table: "tbl_Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 17, 21, 10, 7, 480, DateTimeKind.Local).AddTicks(3894), new DateTime(2022, 2, 17, 21, 10, 7, 480, DateTimeKind.Local).AddTicks(4634) });

            migrationBuilder.UpdateData(
                table: "tbl_Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 17, 21, 10, 7, 480, DateTimeKind.Local).AddTicks(4998), new DateTime(2022, 2, 17, 21, 10, 7, 480, DateTimeKind.Local).AddTicks(5003) });

            migrationBuilder.UpdateData(
                table: "tbl_Colors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 17, 21, 10, 7, 482, DateTimeKind.Local).AddTicks(4521), new DateTime(2022, 2, 17, 21, 10, 7, 482, DateTimeKind.Local).AddTicks(4534) });

            migrationBuilder.UpdateData(
                table: "tbl_Colors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 17, 21, 10, 7, 482, DateTimeKind.Local).AddTicks(5009), new DateTime(2022, 2, 17, 21, 10, 7, 482, DateTimeKind.Local).AddTicks(5011) });

            migrationBuilder.UpdateData(
                table: "tbl_Offers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 17, 21, 10, 7, 490, DateTimeKind.Local).AddTicks(9687), new DateTime(2022, 2, 17, 21, 10, 7, 491, DateTimeKind.Local).AddTicks(216) });

            migrationBuilder.UpdateData(
                table: "tbl_Offers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 17, 21, 10, 7, 491, DateTimeKind.Local).AddTicks(4069), new DateTime(2022, 2, 17, 21, 10, 7, 491, DateTimeKind.Local).AddTicks(4072) });

            migrationBuilder.UpdateData(
                table: "tbl_Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 17, 21, 10, 7, 499, DateTimeKind.Local).AddTicks(7593), new DateTime(2022, 2, 17, 21, 10, 7, 499, DateTimeKind.Local).AddTicks(7638) });

            migrationBuilder.UpdateData(
                table: "tbl_Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 17, 21, 10, 7, 507, DateTimeKind.Local).AddTicks(5038), new DateTime(2022, 2, 17, 21, 10, 7, 507, DateTimeKind.Local).AddTicks(6082) });

            migrationBuilder.UpdateData(
                table: "tbl_Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 17, 21, 10, 7, 507, DateTimeKind.Local).AddTicks(6962), new DateTime(2022, 2, 17, 21, 10, 7, 507, DateTimeKind.Local).AddTicks(6965) });

            migrationBuilder.UpdateData(
                table: "tbl_Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 17, 21, 10, 7, 509, DateTimeKind.Local).AddTicks(8505), new DateTime(2022, 2, 17, 21, 10, 7, 509, DateTimeKind.Local).AddTicks(8524) });

            migrationBuilder.UpdateData(
                table: "tbl_Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 17, 21, 10, 7, 509, DateTimeKind.Local).AddTicks(8535), new DateTime(2022, 2, 17, 21, 10, 7, 509, DateTimeKind.Local).AddTicks(8537) });

            migrationBuilder.UpdateData(
                table: "tbl_Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 17, 21, 10, 7, 515, DateTimeKind.Local).AddTicks(1604), new DateTime(2022, 2, 17, 21, 10, 7, 515, DateTimeKind.Local).AddTicks(1618) });

            migrationBuilder.UpdateData(
                table: "tbl_Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 17, 21, 10, 7, 515, DateTimeKind.Local).AddTicks(2445), new DateTime(2022, 2, 17, 21, 10, 7, 515, DateTimeKind.Local).AddTicks(2446) });
        }
    }
}
