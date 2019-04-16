using Microsoft.EntityFrameworkCore.Migrations;

namespace IndustryLocationSelector.Migrations
{
    public partial class ChangeColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_OrganizationType_TypeId",
                table: "Organizations");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Organizations",
                newName: "OrganizationTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Organizations_TypeId",
                table: "Organizations",
                newName: "IX_Organizations_OrganizationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_OrganizationType_OrganizationTypeId",
                table: "Organizations",
                column: "OrganizationTypeId",
                principalTable: "OrganizationType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_OrganizationType_OrganizationTypeId",
                table: "Organizations");

            migrationBuilder.RenameColumn(
                name: "OrganizationTypeId",
                table: "Organizations",
                newName: "TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Organizations_OrganizationTypeId",
                table: "Organizations",
                newName: "IX_Organizations_TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_OrganizationType_TypeId",
                table: "Organizations",
                column: "TypeId",
                principalTable: "OrganizationType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
