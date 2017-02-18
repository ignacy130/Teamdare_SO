using System;
using System.Collections.Generic;
using Teamdare.Database.Base;

namespace Teamdare.Database.Entities
{
    public class Adventure : Entity
    {
        public Adventure()
        {
            this.Challenges = new List<Challenge>();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public string FinishedText { get; set; }
        public string FinishedImageUrl { get; set; }

        public Guid GameMasterId { get; set; }
        public GameMaster GameMaster { get; set; }

        public Guid HeroId { get; set; }
        public Player Hero { get; set; }

        public List<Challenge> Challenges { get; set; }
    }
}