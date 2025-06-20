using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Soccer_IQ.Migrations
{
    /// <inheritdoc />
    public partial class fastapi1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccurateLongBalls",
                table: "PlayerStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AerialBattlesLost",
                table: "PlayerStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AerialBattlesWon",
                table: "PlayerStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BigChancesMissed",
                table: "PlayerStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CleanSheets",
                table: "PlayerStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "CrossAccuracyPct",
                table: "PlayerStats",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "DuelsLost",
                table: "PlayerStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DuelsWon",
                table: "PlayerStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Fouls",
                table: "PlayerStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GoalsConceded",
                table: "PlayerStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HeadedGoals",
                table: "PlayerStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Interceptions",
                table: "PlayerStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Losses",
                table: "PlayerStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OwnGoals",
                table: "PlayerStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Passes",
                table: "PlayerStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PenaltiesSaved",
                table: "PlayerStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "PredictedAssists",
                table: "PlayerStats",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PredictedGoals",
                table: "PlayerStats",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Recoveries",
                table: "PlayerStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RedCards",
                table: "PlayerStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Saves",
                table: "PlayerStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "SavesPer90",
                table: "PlayerStats",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ShootingAccuracyPct",
                table: "PlayerStats",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Shots",
                table: "PlayerStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShotsOnTarget",
                table: "PlayerStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TackleSuccessPct",
                table: "PlayerStats",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Tackles",
                table: "PlayerStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Wins",
                table: "PlayerStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "YellowCards",
                table: "PlayerStats",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccurateLongBalls",
                table: "PlayerStats");

            migrationBuilder.DropColumn(
                name: "AerialBattlesLost",
                table: "PlayerStats");

            migrationBuilder.DropColumn(
                name: "AerialBattlesWon",
                table: "PlayerStats");

            migrationBuilder.DropColumn(
                name: "BigChancesMissed",
                table: "PlayerStats");

            migrationBuilder.DropColumn(
                name: "CleanSheets",
                table: "PlayerStats");

            migrationBuilder.DropColumn(
                name: "CrossAccuracyPct",
                table: "PlayerStats");

            migrationBuilder.DropColumn(
                name: "DuelsLost",
                table: "PlayerStats");

            migrationBuilder.DropColumn(
                name: "DuelsWon",
                table: "PlayerStats");

            migrationBuilder.DropColumn(
                name: "Fouls",
                table: "PlayerStats");

            migrationBuilder.DropColumn(
                name: "GoalsConceded",
                table: "PlayerStats");

            migrationBuilder.DropColumn(
                name: "HeadedGoals",
                table: "PlayerStats");

            migrationBuilder.DropColumn(
                name: "Interceptions",
                table: "PlayerStats");

            migrationBuilder.DropColumn(
                name: "Losses",
                table: "PlayerStats");

            migrationBuilder.DropColumn(
                name: "OwnGoals",
                table: "PlayerStats");

            migrationBuilder.DropColumn(
                name: "Passes",
                table: "PlayerStats");

            migrationBuilder.DropColumn(
                name: "PenaltiesSaved",
                table: "PlayerStats");

            migrationBuilder.DropColumn(
                name: "PredictedAssists",
                table: "PlayerStats");

            migrationBuilder.DropColumn(
                name: "PredictedGoals",
                table: "PlayerStats");

            migrationBuilder.DropColumn(
                name: "Recoveries",
                table: "PlayerStats");

            migrationBuilder.DropColumn(
                name: "RedCards",
                table: "PlayerStats");

            migrationBuilder.DropColumn(
                name: "Saves",
                table: "PlayerStats");

            migrationBuilder.DropColumn(
                name: "SavesPer90",
                table: "PlayerStats");

            migrationBuilder.DropColumn(
                name: "ShootingAccuracyPct",
                table: "PlayerStats");

            migrationBuilder.DropColumn(
                name: "Shots",
                table: "PlayerStats");

            migrationBuilder.DropColumn(
                name: "ShotsOnTarget",
                table: "PlayerStats");

            migrationBuilder.DropColumn(
                name: "TackleSuccessPct",
                table: "PlayerStats");

            migrationBuilder.DropColumn(
                name: "Tackles",
                table: "PlayerStats");

            migrationBuilder.DropColumn(
                name: "Wins",
                table: "PlayerStats");

            migrationBuilder.DropColumn(
                name: "YellowCards",
                table: "PlayerStats");
        }
    }
}
