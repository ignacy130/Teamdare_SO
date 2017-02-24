using System;
using System.Collections.Generic;
using Teamdare.Database.Base;

namespace Teamdare.Database.Entities
{
    public class Challenge : Entity
    {
        public Challenge()
        {
            this.Participants = new List<Player>();
        }

        public DateTime StartDate { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsStarted { get; set; }
        public int Order { get; set; }

        public Guid AdventureId { get; set; }
        public Adventure Adventure { get; set; }

        public Guid PlayerId { get; set; }
        public Player Player { get; set; }

        public List<Player> Participants { get; set; }
    }
}