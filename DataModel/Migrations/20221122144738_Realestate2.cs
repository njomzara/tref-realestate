using Microsoft.EntityFrameworkCore.Migrations;

namespace DataModel.Migrations
{
    public partial class Realestate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_AspNetUsers_CreateUserId",
                schema: "dbo",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_AspNetUsers_RealestateTypeId",
                schema: "dbo",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_AspNetUsers_UpdatedUserId",
                schema: "dbo",
                table: "Companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                schema: "dbo",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "Companies",
                schema: "dbo",
                newName: "Realestate",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_UpdatedUserId",
                schema: "dbo",
                table: "Realestate",
                newName: "IX_Realestate_UpdatedUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_RealestateTypeId",
                schema: "dbo",
                table: "Realestate",
                newName: "IX_Realestate_RealestateTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_CreateUserId",
                schema: "dbo",
                table: "Realestate",
                newName: "IX_Realestate_CreateUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Realestate",
                schema: "dbo",
                table: "Realestate",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Realestate_AspNetUsers_CreateUserId",
                schema: "dbo",
                table: "Realestate",
                column: "CreateUserId",
                principalSchema: "dbo",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Realestate_AspNetUsers_RealestateTypeId",
                schema: "dbo",
                table: "Realestate",
                column: "RealestateTypeId",
                principalSchema: "dbo",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Realestate_AspNetUsers_UpdatedUserId",
                schema: "dbo",
                table: "Realestate",
                column: "UpdatedUserId",
                principalSchema: "dbo",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Realestate_AspNetUsers_CreateUserId",
                schema: "dbo",
                table: "Realestate");

            migrationBuilder.DropForeignKey(
                name: "FK_Realestate_AspNetUsers_RealestateTypeId",
                schema: "dbo",
                table: "Realestate");

            migrationBuilder.DropForeignKey(
                name: "FK_Realestate_AspNetUsers_UpdatedUserId",
                schema: "dbo",
                table: "Realestate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Realestate",
                schema: "dbo",
                table: "Realestate");

            migrationBuilder.RenameTable(
                name: "Realestate",
                schema: "dbo",
                newName: "Companies",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_Realestate_UpdatedUserId",
                schema: "dbo",
                table: "Companies",
                newName: "IX_Companies_UpdatedUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Realestate_RealestateTypeId",
                schema: "dbo",
                table: "Companies",
                newName: "IX_Companies_RealestateTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Realestate_CreateUserId",
                schema: "dbo",
                table: "Companies",
                newName: "IX_Companies_CreateUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                schema: "dbo",
                table: "Companies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_AspNetUsers_CreateUserId",
                schema: "dbo",
                table: "Companies",
                column: "CreateUserId",
                principalSchema: "dbo",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_AspNetUsers_RealestateTypeId",
                schema: "dbo",
                table: "Companies",
                column: "RealestateTypeId",
                principalSchema: "dbo",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_AspNetUsers_UpdatedUserId",
                schema: "dbo",
                table: "Companies",
                column: "UpdatedUserId",
                principalSchema: "dbo",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
