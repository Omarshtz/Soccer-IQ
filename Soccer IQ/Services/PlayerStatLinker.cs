using System.Linq;
using Soccer_IQ.Data;
using Soccer_IQ.Models;

namespace Soccer_IQ.Services
{
    public class PlayerStatLinker
    {
        private readonly AppDbContext _ctx;
        public PlayerStatLinker(AppDbContext ctx) => _ctx = ctx;

        /// <summary>
        /// يملأ PlayerId المفقود بحيث PlayerId = Id - 4
        /// ويرجع عدد الصفوف التى تم تعديلها.
        /// </summary>
        public int FillPlayerIdsOffset4()
        {
            // حمّل كل Player مرة واحدة فى Dictionary للبحث السريع
            var players = _ctx.Players
                              .ToDictionary(p => p.Id, p => p);

            // حمّل الصفوف التى مازال PlayerId فيها null
            var stats = _ctx.PlayerStats
                            .Where(s => s.PlayerId == null)
                            .ToList();

            int updated = 0;

            foreach (var stat in stats)
            {
                int candidate = stat.Id - 4;
                if (players.ContainsKey(candidate))
                {
                    stat.PlayerId = candidate;
                    updated++;
                }
            }

            _ctx.SaveChanges();
            return updated;
        }
    }
}
