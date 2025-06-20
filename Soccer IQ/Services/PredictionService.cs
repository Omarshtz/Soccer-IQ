using System.Net.Http;
using System.Net.Http.Json;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Soccer_IQ.Models;

public class PredictionService
{
    private readonly HttpClient _http;
    public PredictionService(HttpClient http) => _http = http;

    public async Task<double> PredictAsync(PLayerStat stat, string target /* "goals" | "assists" */)
    {
        // 1) حوّل خصائص الـ C# للأسماء اللى الـ AI عايزها
        var features = stat.GetType()
            .GetProperties()
            .Where(p => p.PropertyType == typeof(int) || p.PropertyType == typeof(double))
            .ToDictionary(
                p => MapKey(p.Name),
                p => (object?)p.GetValue(stat) ?? 0
            );
        // ─── قيم إضافية يطلبها FastAPI ───
        features["Goals_Assists"] = stat.Goals + stat.Assists;
        features["Total_Contributions"] = stat.Goals + stat.Assists;
        features["saves"] = stat.Saves;          // نفس القيمة لكن بحروف صغيرة


        // 2) ابنى الـ Payload
        var body = new
        {
            model_type = "regression",
            target = target,
            features = features
        };

        // 3) ابعت الطلب
        var res = await _http.PostAsJsonAsync("/predict", body);
        if (!res.IsSuccessStatusCode)
            throw new ApplicationException($"AI API error: {(int)res.StatusCode}");

        var obj = await res.Content.ReadFromJsonAsync<PredictionResponse>();
        return obj?.prediction ?? 0;
    }

    // خرائط الأسماء ذات المسافات أو %
    private static string MapKey(string k) => k switch
    {
        "GoalsConceded" => "Goals Conceded",
        "TackleSuccessPct" => "Tackle success %",
        "CrossAccuracyPct" => "Cross accuracy %",
        "ShootingAccuracyPct" => "Shooting accuracy %",
        "BigChancesCreated" => "Big Chances Created",
        _ => k
    };

    private class PredictionResponse { public double prediction { get; set; } }
}
