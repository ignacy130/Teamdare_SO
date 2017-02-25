using System;
using System.Linq;
using Teamdare.Core.Commands;
using Teamdare.Database.Entities;

namespace Teamdare.Domain.Commands
{
    public class CompleteChallenge
    {
        public CompleteChallenge(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }

    public class CompleteChallengeCommand : CommandPerformer<CompleteChallenge>
    {
        public override void Execute(CompleteChallenge command)
        {
            var challange = DbContext.Challenges.SingleOrDefault(c => c.Id == command.Id);
            if (challange == null)
                return;

            challange.Status = ChallengeStatus.Completed;
        }
    }
}