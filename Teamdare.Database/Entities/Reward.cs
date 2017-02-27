using System;
using Teamdare.Database.Base;

namespace Teamdare.Database.Entities
{
    public class Reward : Entity
    {
        public string Title { get; set; }
        public int Value { get; set; }

        public Guid AdventureId { get; set; }
        public Adventure Adventure { get; set; }

        public Guid PlayerId { get; set; }
        public Player Player { get; set; }
    }
}