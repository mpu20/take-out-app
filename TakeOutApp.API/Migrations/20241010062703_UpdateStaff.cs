﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakeOutApp.API.Migrations
{
    public partial class UpdateStaff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Staffs");
        }
    }
}
