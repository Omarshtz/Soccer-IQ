using Microsoft.AspNetCore.Mvc;
using Soccer_IQ.Models;
using Soccer_IQ.Repository.IRepository;

[ApiController]
[Route("api/player-stats")]
public class PlayerStatPredictionController : ControllerBase
{
    private readonly IRepository<PLayerStat> _statRepo;
    private readonly PredictionService _ai;

    public PlayerStatPredictionController(
        IRepository<PLayerStat> statRepo,
        PredictionService ai)
    {
        _statRepo = statRepo;
        _ai = ai;
    }

    /* ───────── 1️⃣ تنبؤ لسِجلّ واحد ───────── */
    // POST api/player-stats/42/predict
    [HttpPost("{id}/predict")]
    public async Task<IActionResult> PredictOne(int id)
    {
        var stat = _statRepo.GetOne(null, s => s.Id == id, tracked: true);
        if (stat == null) return NotFound();

        await PredictAndSaveAsync(stat);
        return Ok(new
        {
            stat.Id,
            stat.PlayerId,
            stat.PredictedGoals,
            stat.PredictedAssists,
            stat.TotalPredictedContributions
        });
    }

    /* ───────── 2️⃣ تنبؤ لكل السجلات ───────── */
    // POST api/player-stats/predict-all
    [HttpPost("predict-all")]
    public async Task<IActionResult> PredictAll()
    {
        var stats = _statRepo.GetAll(null, null, tracked: true).ToList();
        foreach (var s in stats)
            await PredictAndSaveAsync(s);

        _statRepo.Commit();
        return Ok(new { updated = stats.Count });
    }

    /* ========== الدالة المساعدة ========== */
    private async Task PredictAndSaveAsync(PLayerStat stat)
    {
        stat.PredictedGoals = await _ai.PredictAsync(stat, "goals");
        stat.PredictedAssists = await _ai.PredictAsync(stat, "assists");
        _statRepo.Edit(stat);
        _statRepo.Commit();
    }
}
