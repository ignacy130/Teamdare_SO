using System;
using System.Linq;
using Teamdare.Core.Commands;
using Teamdare.Database.Entities;

namespace Teamdare.Domain.Commands
{
    public class BeginChallange
    {
        public BeginChallange(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }

    public class BeginChallangeCommand : CommandPerformer<BeginChallange>
    {
        public override void Execute(BeginChallange command)
        {
            var challenge = DbContext.Challenges.SingleOrDefault(c => c.Id == command.Id);
            if (challenge == null)
                return;

            challenge.Status = ChallengeStatus.InProgress;
            challenge.StartDate = DateTimeGetter.GetDateTime();
            DbContext.SaveChanges();
        }
    }
}