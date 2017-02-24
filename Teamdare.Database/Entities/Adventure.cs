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

        public Guid PlayerId { get; set; }
        public Player Player { get; set; }

        public List<Challenge> Challenges { get; set; }
    }
}