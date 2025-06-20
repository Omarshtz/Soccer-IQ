using Microsoft.AspNetCore.Mvc;
using Soccer_IQ.Models;
using Soccer_IQ.Repository.IRepository;

namespace Soccer_IQ.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly IRepository<Player> _playerRepo;

        public PlayersController(IRepository<Player> playerRepo)
        {
            _playerRepo = playerRepo;
        }

        // GET: api/players
        [HttpGet]
        public IActionResult GetAllPlayers()
        {
            var players = _playerRepo.GetAll();
            return Ok(players);
        }

        // GET: api/players/{id}
        [HttpGet("{id}")]
        public IActionResult GetPlayer(int id)
        {
            var player = _playerRepo.GetOne(null, p => p.Id == id);
            if (player == null) return NotFound();
            return Ok(player);
        }

        // POST: api/players
        [HttpPost]
        public IActionResult CreatePlayer([FromBody] Player player)
        {
            if (player == null) return BadRequest();

            _playerRepo.Create(player);
            _playerRepo.Commit();

            // يعيد 201 مع Location header يشير إلى GET الخاص بالعنصر الجديد
            return CreatedAtAction(nameof(GetPlayer), new { id = player.Id }, player);
        }

        // PUT: api/players/{id}
        [HttpPut("{id}")]
        public IActionResult UpdatePlayer(int id, [FromBody] Player updatedPlayer)
        {
            if (updatedPlayer == null || id != updatedPlayer.Id)
                return BadRequest();

            var existing = _playerRepo.GetOne(null, p => p.Id == id, tracked: true);
            if (existing == null) return NotFound();

            // عدّل الحقول المراد تحديثها
            existing.Name = updatedPlayer.Name;
            existing.PhotoUrl = updatedPlayer.PhotoUrl;
            existing.Position = updatedPlayer.Position;
            existing.Club = updatedPlayer.Club;

            _playerRepo.Edit(existing);
            _playerRepo.Commit();

            return Ok(existing);
        }

        // DELETE: api/players/{id}
        [HttpDelete("{id}")]
        public IActionResult DeletePlayer(int id)
        {
            var player = _playerRepo.GetOne(null, p => p.Id == id, tracked: true);
            if (player == null) return NotFound();

            _playerRepo.Delete(player);
            _playerRepo.Commit();

            return NoContent();
        }
    }
}
