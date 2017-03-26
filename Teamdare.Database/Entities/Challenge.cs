using System;
using Teamdare.Database.Base;

namespace Teamdare.Database.Entities
{
    public class Challenge : Entity
    {
        public DateTime? StartDate { get; set; }
        public string Title { get; set; }
		public string Description { get; set; }
		public ChallengeStatus Status { get; set; }
        public int Order { get; set; }

        public Guid AdventureId { get; set; }
        public Adventure Adventure { get; set; }

        public Guid PlayerId { get; set; }
        public Player Player { get; set; }
    }

    public enum ChallengeStatus
    {
        New,
        InProgress,
        Completed
    }
}