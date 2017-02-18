using System.Collections.Generic;
using Teamdare.Database.Base;

namespace Teamdare.Database.Entities
{
    public class GameMaster : Entity
    {
        public GameMaster()
        {
            this.Players = new List<Player>();
            this.Adventures = new List<Adventure>();
        }

        public List<Player> Players { get; set; }
        public List<Adventure> Adventures { get; set; }
    }
}