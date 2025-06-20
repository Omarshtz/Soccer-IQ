namespace Soccer_IQ.Models
{
    public class PLayerStat
    {
        public int Id { get; set; }

        /* ⇢ الأرقام الحقيقية من الموسم */
        public double Goals { get; set; }
        public double Assists { get; set; }          // ← صحّحت التهجئة
        public double MinutesPlayed { get; set; }
        public double Matches { get; set; }
        public string? Season { get; set; }

        public double XG { get; set; }
        public double XA { get; set; }

        /* ⇢ أعمدة FastAPI */
        public double Shots { get; set; }
        public double ShotsOnTarget { get; set; }
        public double ShootingAccuracyPct { get; set; }   // %
        public double BigChancesMissed { get; set; }
        public double HeadedGoals { get; set; }

        public double Passes { get; set; }
        public double AccurateLongBalls { get; set; }
        public double CrossAccuracyPct { get; set; }   // %

        public double Tackles { get; set; }
        public double TackleSuccessPct { get; set; }   // %

        public double Interceptions { get; set; }
        public double Recoveries { get; set; }

        public double DuelsWon { get; set; }
        public double DuelsLost { get; set; }
        public double AerialBattlesWon { get; set; }
        public double AerialBattlesLost { get; set; }

        public double Fouls { get; set; }
        public double YellowCards { get; set; }
        public double RedCards { get; set; }

        public double OwnGoals { get; set; }
        public double Wins { get; set; }
        public double Losses { get; set; }
        public double CleanSheets { get; set; }
        public double GoalsConceded { get; set; }

        public double SavesPer90 { get; set; }
        public double Saves { get; set; }
        public double PenaltiesSaved { get; set; }

        /* ⇢ أعمدة جديدة مطلوبة ل-FastAPI */
        public double BigChancesCreated { get; set; }   // NEW
        public double Goals_Assists => Goals + Assists;
        public double Total_Contributions => Goals + Assists;
        public double Minutes_per_Goal => Goals == 0 ? 0 : MinutesPlayed / Goals;
        public double Minutes_per_Assist => Assists == 0 ? 0 : MinutesPlayed / Assists;

        /* ⇢ التنبؤات اللى هنخزنها بعد استدعاء FastAPI */
        public double? PredictedGoals { get; set; }
        public double? PredictedAssists { get; set; }
        public double? TotalPredictedContributions =>
                           (PredictedGoals ?? 0) + (PredictedAssists ?? 0);

        /* ⇢ FK */
        public int PlayerId { get; set; }
        public Player Player { get; set; }
    }
}
