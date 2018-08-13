using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CustomVacations.Data.Migrations
{
    public partial class VacationCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateTable(
                name: "VacationCarts",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Applicationuserid = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    DateLastModified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationCarts", x => x.id);
                    table.ForeignKey(
                        name: "FK_VacationCarts_AspNetUsers_Applicationuserid",
                        column: x => x.Applicationuserid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "vacationCategories",
                columns: table => new
                {
                    CategoryName = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: true, defaultValueSql: "GetDate()"),
                    DateLastModified = table.Column<DateTime>(nullable: true, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vacationCategories", x => x.CategoryName);
                });

            migrationBuilder.CreateTable(
                name: "VacationModels",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerName = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    DateLastModified = table.Column<DateTime>(nullable: true),
                    DestinationDescription = table.Column<string>(nullable: true),
                    DreamDestination = table.Column<string>(nullable: true),
                    VacationCategoryCategoryName = table.Column<string>(nullable: true),
                    VacationModelName = table.Column<string>(nullable: true),
                    budget = table.Column<decimal>(nullable: false),
                    email = table.Column<string>(nullable: true),
                    phoneNumber = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationModels", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VacationModels_vacationCategories_VacationCategoryCategoryName",
                        column: x => x.VacationCategoryCategoryName,
                        principalTable: "vacationCategories",
                        principalColumn: "CategoryName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VacationModelCarts",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    DateLastModified = table.Column<DateTime>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    VacationCartId = table.Column<int>(nullable: false),
                    vacationModelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationModelCarts", x => x.id);
                    table.ForeignKey(
                        name: "FK_VacationModelCarts_VacationCarts_VacationCartId",
                        column: x => x.VacationCartId,
                        principalTable: "VacationCarts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacationModelCarts_VacationModels_vacationModelId",
                        column: x => x.vacationModelId,
                        principalTable: "VacationModels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VacationCarts_Applicationuserid",
                table: "VacationCarts",
                column: "Applicationuserid",
                unique: true,
                filter: "[Applicationuserid] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VacationModelCarts_VacationCartId",
                table: "VacationModelCarts",
                column: "VacationCartId");

            migrationBuilder.CreateIndex(
                name: "IX_VacationModelCarts_vacationModelId",
                table: "VacationModelCarts",
                column: "vacationModelId");

            migrationBuilder.CreateIndex(
                name: "IX_VacationModels_VacationCategoryCategoryName",
                table: "VacationModels",
                column: "VacationCategoryCategoryName");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "VacationModelCarts");

            migrationBuilder.DropTable(
                name: "VacationCarts");

            migrationBuilder.DropTable(
                name: "VacationModels");

            migrationBuilder.DropTable(
                name: "vacationCategories");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
