using CsvHelper.Configuration;
using Soccer_IQ.Models;

public sealed class PlayerCsvMap : ClassMap<Player>
{
    public PlayerCsvMap()
    {
        Map(p => p.Id).Name("Id");
        Map(p => p.Name).Name("Name");
        Map(p => p.Position).Name("Position");
        Map(p => p.Club).Name("Club");
        Map(p => p.PhotoUrl).Constant(null);  // حاليًا مش معانا صور
    }
}
