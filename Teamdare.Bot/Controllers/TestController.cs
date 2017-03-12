using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Teamdare.Database;

namespace Teamdare.Bot.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private readonly TeamdareContext _teamdareContext;

        public TestController(TeamdareContext teamdareContext)
        {
            _teamdareContext = teamdareContext;
        }

        [HttpGet]
        public string IsWorking()
        {
            var gameMasters = _teamdareContext.Players.Count();
            return "Bot is working (" + gameMasters + ")";
        }
    }
}