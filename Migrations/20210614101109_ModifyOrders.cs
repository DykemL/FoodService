using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodService.Migrations
{
    public partial class ModifyOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderTime",
                table: "Orders",
                newName: "OrderTimeStart");

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderTimeEnd",
                table: "Orders",
                type: "timestamp without time zone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderTimeEnd",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "OrderTimeStart",
                table: "Orders",
                newName: "OrderTime");
        }
    }
}
