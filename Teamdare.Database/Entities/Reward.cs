using Teamdare.Database.Base;

namespace Teamdare.Database.Entities
{
    public class Reward : Entity
    {
        public string Title { get; set; }
        public int Value { get; set; }

        public int AdventureId { get; set; }
        public virtual Adventure Adventure { get; set; }

        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }
    }
}