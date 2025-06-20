using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using Soccer_IQ.Data;
using Soccer_IQ.Models;
using System.Globalization;

public class PlayerSeeder
{
    private readonly AppDbContext _ctx;
    public PlayerSeeder(AppDbContext ctx) => _ctx = ctx;

    public int SeedPlayers(string csvPath)
    {
        using var reader = new StreamReader(csvPath);
        using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HeaderValidated = null,
            MissingFieldFound = null
        });
        csv.Context.RegisterClassMap<PlayerCsvMap>();
        var players = csv.GetRecords<Player>().ToList();

        using var tx = _ctx.Database.BeginTransaction();
        _ctx.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Players ON");
        _ctx.Players.AddRange(players);
        _ctx.SaveChanges();
        _ctx.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Players OFF");
        tx.Commit();

        return players.Count;
    }
}
