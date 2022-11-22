using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataModel.Migrations
{
    public partial class Realestate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                schema: "dbo",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "dbo",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "dbo",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "dbo",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Companies",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RowVersion = table.Column<int>(nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    RealestateTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LocationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    CreateUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_AspNetUsers_CreateUserId",
                        column: x => x.CreateUserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Companies_AspNetUsers_RealestateTypeId",
                        column: x => x.RealestateTypeId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Companies_AspNetUsers_UpdatedUserId",
                        column: x => x.UpdatedUserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CreateUserId",
                schema: "dbo",
                table: "Companies",
                column: "CreateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_RealestateTypeId",
                schema: "dbo",
                table: "Companies",
                column: "RealestateTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_UpdatedUserId",
                schema: "dbo",
                table: "Companies",
                column: "UpdatedUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                schema: "dbo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "dbo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "dbo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "dbo",
                table: "AspNetUsers");
        }
    }
}
