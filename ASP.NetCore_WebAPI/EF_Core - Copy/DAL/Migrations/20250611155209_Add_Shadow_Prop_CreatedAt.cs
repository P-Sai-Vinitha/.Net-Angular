using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Add_Shadow_Prop_CreatedAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "UserInfo",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.UpdateData(
                table: "UserInfo",
                keyColumn: "EmailId",
                keyValue: "admin@gmail.com",
                column: "UserName",
                value: "Admin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "UserInfo");

            migrationBuilder.UpdateData(
                table: "UserInfo",
                keyColumn: "EmailId",
                keyValue: "admin@gmail.com",
                column: "UserName",
                value: "John");
        }
    }
}
