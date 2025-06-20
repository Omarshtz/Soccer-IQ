using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Soccer_IQ.Migrations
{
    /// <inheritdoc />
    public partial class fixnull5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerStats_Players_PlayerId",
                table: "PlayerStats");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerStats_Players_PlayerId",
                table: "PlayerStats",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerStats_Players_PlayerId",
                table: "PlayerStats");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerStats_Players_PlayerId",
                table: "PlayerStats",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id");
        }
    }
}
