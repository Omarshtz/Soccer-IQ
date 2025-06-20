namespace Soccer_IQ.Services.Maps
{
    using CsvHelper.Configuration;
    using Soccer_IQ.Models;

    public sealed class PlayerStatCsvMap : ClassMap<PLayerStat>
    {
        public PlayerStatCsvMap()
        {
            Map(m => m.PlayerId).Name("ID");
           // Map(m => m.PositionCode).Name("position").Optional();
            Map(m => m.Goals).Name("goals_scored").Optional();
            Map(m => m.Assists).Name("assists").Optional();
            Map(m => m.Shots).Name("Shots").Optional();
            Map(m => m.ShotsOnTarget).Name("Shots on target").Optional();
            Map(m => m.ShootingAccuracyPct).Name("Shooting accuracy %").Optional();
            Map(m => m.BigChancesMissed).Name("Big chances missed").Optional();
            Map(m => m.HeadedGoals).Name("Headed goals").Optional();
            Map(m => m.Passes).Name("Passes").Optional();
            Map(m => m.AccurateLongBalls).Name("Accurate long balls").Optional();
            Map(m => m.CrossAccuracyPct).Name("Cross accuracy %").Optional();
            Map(m => m.Tackles).Name("Tackles").Optional();
            Map(m => m.TackleSuccessPct).Name("Tackle success %").Optional();
            Map(m => m.Interceptions).Name("Interceptions").Optional();
            Map(m => m.Recoveries).Name("Recoveries").Optional();
            Map(m => m.DuelsWon).Name("Duels won").Optional();
            Map(m => m.DuelsLost).Name("Duels lost").Optional();
            Map(m => m.AerialBattlesWon).Name("Aerial battles won").Optional();
            Map(m => m.AerialBattlesLost).Name("Aerial battles lost").Optional();
            Map(m => m.Fouls).Name("Fouls").Optional();
            Map(m => m.YellowCards).Name("yellow_cards").Optional();
            Map(m => m.RedCards).Name("red_cards").Optional();
            Map(m => m.OwnGoals).Name("own_goals").Optional();
            Map(m => m.Wins).Name("Wins").Optional();
            Map(m => m.Losses).Name("Losses").Optional();
            Map(m => m.CleanSheets).Name("clean_sheets").Optional();
            Map(m => m.GoalsConceded).Name("Goals Conceded").Optional();
            Map(m => m.SavesPer90).Name("saves_per_90").Optional();
            Map(m => m.Saves).Name("saves").Optional();
            Map(m => m.PenaltiesSaved).Name("penalties_saved").Optional();
            // باقى الأعمدة إذا احتجتها
        }
    }
}
    
