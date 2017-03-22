using System.Collections.Generic;
using System.Linq;
using Teamdare.Core.Commands;
using Teamdare.Database.Entities;
using Teamdare.Resources;

namespace Teamdare.Domain.Commands
{
    public class InitializeGame
    {
        public InitializeGame(string username, string userId, string conversationId, string serviceUrl)
        {
            Username = username;
            UserId = userId;
            ConversationId = conversationId;
            ServiceUrl = serviceUrl;
        }

        public string Username { get; set; }
        public string UserId { get; set; }
        public string ConversationId { get; set; }
        public string ServiceUrl { get; set; }
    }

    public class InitializeGameCommand : CommandPerformer<InitializeGame>
    {
        public override void Execute(InitializeGame command)
        {
            var gameMaster = Please.Do(new GetOrCreateGameMaster()).Result;
            var player = Please.Do(new GetOrCreatePlayer(command.Username, command.UserId, command.ConversationId,
                command.ServiceUrl, gameMaster.Id )).Result;

            var adventures = new List<InitializeGameAdventure>()
            {
                new InitializeGameAdventure(ResourcesStrings.PeopleAdventureTitle,
                    ResourcesStrings.PeopleAdventureFinished, ResourcesImages.PeopleBadge),
                new InitializeGameAdventure(ResourcesStrings.FoodAdventureTitle,
                    ResourcesStrings.FoodAdventureFinished, ResourcesImages.FoodBadge),
                new InitializeGameAdventure(ResourcesStrings.PlacesAdventureTitle,
                    ResourcesStrings.PlacesAdventureFinished, ResourcesImages.PlacesBadge)
            };

            var challanges = new List<List<InitializeGameChallenge>>()
            {
                new List<InitializeGameChallenge>()
                {
					new InitializeGameChallenge(ResourcesStrings.IntroduceYourselfChallengeTitle , ResourcesStrings
                        .IntroduceYourselfChallengeDescription),
					new InitializeGameChallenge(ResourcesStrings.LunchChallengeTitle, ResourcesStrings
                        .LunchChallengeDescription),
					new InitializeGameChallenge(ResourcesStrings.SelfieChallengeTitle, ResourcesStrings
                        .SelfieChallengeDescription)
                },
				new List<InitializeGameChallenge>()
				{
					new InitializeGameChallenge(ResourcesStrings.CoffieWithChallengeTitle , ResourcesStrings
                        .CoffieWithChallengeDescription),
					new InitializeGameChallenge(ResourcesStrings.ShopChallengeTitle , ResourcesStrings
                        .ShopChallengeDescription),
					new InitializeGameChallenge(ResourcesStrings.BeerChallengeTitle , ResourcesStrings
                        .BeerChallengeDescription)
                },
				new List<InitializeGameChallenge>()
				{
					new InitializeGameChallenge(ResourcesStrings.ToiletChallengeTitle , ResourcesStrings
                        .ToiletChallengeDescription),
					new InitializeGameChallenge(ResourcesStrings.RelaxRoomChallengeTitle , ResourcesStrings
                        .RelaxRoomChallengeDescription),
					new InitializeGameChallenge(ResourcesStrings.KitchenChallengeTitle , ResourcesStrings
                        .KitchenChallengeDescription)
                }
            };

            for (var i = 0; i < adventures.Count; i++)
            {
                var adventure = CreateAdventure(player, adventures[i], i);

                CreateChallenges(player, adventure, challanges[i]);
            }

            DbContext.SaveChanges();
        }

        private Adventure CreateAdventure(Player player, InitializeGameAdventure adventureInfo, int order)
        {
             var adventure = new Adventure()
             {
                 Player = player,
                 Title = adventureInfo.Title,
                 FinishedText = adventureInfo.FinishedMessage,
                 FinishedImageUrl = adventureInfo.FinishedImageUrl,
                 Order = order
             };

            DbContext.Adventures.Add(adventure);

            return adventure;
        }

        private void CreateChallenges(Player player, Adventure adventure, IList<InitializeGameChallenge> challenges)
        {
            for (var i = 0; i < challenges.Count(); i++)
            {
                var challange = new Challenge()
                {
                    Title = challenges[i].Title,
					Description = challenges[i].Description,
                    Order = i,
                    Adventure = adventure,
                    Player = player
                };

                DbContext.Challenges.Add(challange);
            }
        }

        private class InitializeGameAdventure
        {
            public InitializeGameAdventure(string title, string finishedMessage, string finishedImageUrl)
            {
                Title = title;
                FinishedMessage = finishedMessage;
                FinishedImageUrl = finishedImageUrl;
            }

            public string Title { get; }
            public string FinishedMessage { get; }
            public string FinishedImageUrl { get; }
        }

        private class InitializeGameChallenge
        {
            public InitializeGameChallenge(string title, string description)
            {
                Title = title;
                Description = description;
            }

            public string Title { get; }
            public string Description { get; }
        }
    }
}