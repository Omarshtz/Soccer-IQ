using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using Soccer_IQ.Data;
using Soccer_IQ.Models;
using Soccer_IQ.Services.Maps;

public class CsvSeeder
{
    private readonly AppDbContext _ctx;
    public CsvSeeder(AppDbContext ctx) => _ctx = ctx;

    public int SeedPlayerStats(string csvPath)
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HeaderValidated = null,
            MissingFieldFound = null
        };

        using var reader = new StreamReader(csvPath);
        using var csv = new CsvReader(reader, config);
        csv.Context.RegisterClassMap<PlayerStatCsvMap>();

        var records = csv.GetRecords<PLayerStat>().ToList();

        // حوّل النِّسَب المئوية
        records.ForEach(r =>
        {
            r.ShootingAccuracyPct /= 100;
            r.CrossAccuracyPct /= 100;
            r.TackleSuccessPct /= 100;
        });

        _ctx.PlayerStats.AddRange(records);
        return _ctx.SaveChanges();
    }
}
