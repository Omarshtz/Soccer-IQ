﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Soccer_IQ.Migrations
{
    /// <inheritdoc />
    public partial class fix1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Asissts",
                table: "PlayerStats",
                newName: "BigChancesCreated");

            migrationBuilder.AddColumn<int>(
                name: "Assists",
                table: "PlayerStats",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Assists",
                table: "PlayerStats");

            migrationBuilder.RenameColumn(
                name: "BigChancesCreated",
                table: "PlayerStats",
                newName: "Asissts");
        }
    }
}
