using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/seeder")]
public class SeederController : ControllerBase
{
    private readonly CsvSeeder _seeder;
    private readonly PlayerSeeder _playerSeeder;
    public SeederController(CsvSeeder seeder, PlayerSeeder playerSeeder)
    { _seeder = seeder;
        _playerSeeder = playerSeeder;
    }

   // POST api/seeder/playerstats
   [HttpPost("playerstats")]
    public IActionResult SeedStats()
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(),
                                "Data", "Cleaned_Players_Data.csv");

        if (!System.IO.File.Exists(path))
            return NotFound("CSV file not found."+path);

        var count = _seeder.SeedPlayerStats(path);
        return Ok(new { inserted = count });
    }


    [HttpPost("players")]
    public IActionResult SeedPlayers()
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(),
                                "Data", "Player_Basic_Info_Updated.csv");

        if (!System.IO.File.Exists(path))
            return NotFound("CSV file not found: " + path);

        var count = _playerSeeder.SeedPlayers(path);
        return Ok(new { inserted = count });
    }
}
