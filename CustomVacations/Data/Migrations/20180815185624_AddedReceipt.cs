using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CustomVacations.Data.Migrations
{
    public partial class AddedReceipt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VacationOrder",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    email = table.Column<string>(nullable: true),
                    streetaddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationOrder", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "VacationOrderDestinationDetails",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    Budget = table.Column<decimal>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    DateLastModified = table.Column<DateTime>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    VacationOrderId = table.Column<Guid>(nullable: false),
                    destination = table.Column<string>(nullable: true),
                    destinationdescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationOrderDestinationDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_VacationOrderDestinationDetails_VacationOrder_VacationOrderId",
                        column: x => x.VacationOrderId,
                        principalTable: "VacationOrder",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VacationOrderDestinationDetails_VacationOrderId",
                table: "VacationOrderDestinationDetails",
                column: "VacationOrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VacationOrderDestinationDetails");

            migrationBuilder.DropTable(
                name: "VacationOrder");
        }
    }
}
