﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace IndustryLocationSelector.Migrations
{
    public partial class updateDatabaseAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PlaceType",
                newName: "PlaceTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlaceTypeId",
                table: "PlaceType",
                newName: "Id");
        }
    }
}
