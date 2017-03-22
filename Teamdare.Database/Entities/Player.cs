using System;
using System.Collections.Generic;
using Teamdare.Database.Base;

namespace Teamdare.Database.Entities
{
    public class Player : Entity
    {
        public Player()
        {
            this.Adventures = new List<Adventure>();
            this.Rewards = new List<Reward>();
        }
        public int Level { get; set; }
        public string Nick { get; set; }
        public string UserId { get; set; }

        public Guid GameMasterId { get; set; }
        public GameMaster GameMaster { get; set; }

        public List<Adventure> Adventures { get; set; }
        public List<Reward> Rewards { get; set; }

        public string ServiceUrl { get; set; }
        public string ConversationId { get; set; }
    }
}