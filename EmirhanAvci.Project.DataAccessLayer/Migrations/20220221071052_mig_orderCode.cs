using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmirhanAvci.Project.DataAccessLayer.Migrations
{
    public partial class mig_orderCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OrderCode",
                table: "tbl_Orders",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(12)",
                oldMaxLength: 12);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "OrderCode",
                table: "tbl_Orders",
                type: "varbinary(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);
        }
    }
}
