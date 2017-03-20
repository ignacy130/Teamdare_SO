using System;
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
                command.ServiceUrl, gameMaster.Id)).Result;

            var adventures = new List<Tuple<string, string, string>>()
            {
                new Tuple<string, string, string>(ResourcesStrings.AdventurePlacesAdventureTitle,
                    ResourcesStrings.AdventurePlacesAdventureFinished, ResourcesImages.PlacesBadge),
                new Tuple<string, string, string>(ResourcesStrings.AdventureFoodAdventureTitle,
                    ResourcesStrings.AdventureFoodAdventureFinished, ResourcesImages.FoodBadge),
                new Tuple<string, string, string>(ResourcesStrings.AdventurePlacesAdventureTitle,
                    ResourcesStrings.AdventurePlacesAdventureFinished, ResourcesImages.PlacesBadge)
            };

            var challanges = new List<List<Tuple<string,string>>>()
            {
                new List<Tuple<string,string>>()
                {
					new Tuple<string, string>(ResourcesStrings.AdventureIntroduceYourselfChallengeTitle , ResourcesStrings
                        .AdventureIntroduceYourselfChallengeDescription),
					new Tuple<string, string>(ResourcesStrings.AdventureLunchChallengeTitle, ResourcesStrings
                        .AdventureLunchChallengeDescription),
					new Tuple<string, string>(ResourcesStrings.AdventureSelfieChallengeTitle, ResourcesStrings
                        .AdventureSelfieChallengeDescription)
                },
				new List<Tuple<string,string>>()
				{
					new Tuple<string, string>(ResourcesStrings.AdventureCoffieWithChallengeTitle , ResourcesStrings
                        .AdventureCoffieWithChallengeDescription),
					new Tuple<string, string>(ResourcesStrings.AdventureShopChallengeTitle , ResourcesStrings
                        .AdventureShopChallengeDescription),
					new Tuple<string, string>(ResourcesStrings.AdventureBeerChallengeTitle , ResourcesStrings
                        .AdventureBeerChallengeDescription)
                },
				new List<Tuple<string,string>>()
				{
					new Tuple<string, string>(ResourcesStrings.AdventureToiletChallengeTitle , ResourcesStrings
                        .AdventureToiletChallengeDescription),
					new Tuple<string, string>(ResourcesStrings.AdventureRelaxRoomChallengeTitle , ResourcesStrings
                        .AdventureRelaxRoomChallengeDescription),
					new Tuple<string, string>(ResourcesStrings.AdventureKitchenChallengeTitle , ResourcesStrings
                        .AdventureKitchenChallengeDescription)
                }
            };

            for (var i = 0; i < adventures.Count; i++)
            {
                var adventureStrings = adventures[i];
                var adventure = CreateAdventure(player, adventureStrings.Item1, adventureStrings.Item2,
                    adventureStrings.Item3, i);

                CreateChallenges(player, adventure, challanges[i]);
            }

            DbContext.SaveChanges();
        }

        private Adventure CreateAdventure(Player player, string title, string finishedMessage, string finishedImageUrl, int order)
        {
             var adventure = new Adventure()
             {
                 Player = player,
                 Title = title,
                 FinishedText = finishedMessage,
                 FinishedImageUrl = finishedImageUrl,
                 Order = order
             };

            DbContext.Adventures.Add(adventure);

            return adventure;
        }

        private void CreateChallenges(Player player, Adventure adventure, IList<Tuple<string,string>> titles)
        {
            for (var i = 0; i < titles.Count(); i++)
            {
                var challange = new Challenge()
                {
                    Title = titles[i].Item1,
					Description = titles[i].Item2,
                    Order = i,
                    Adventure = adventure,
                    Player = player
                };

                DbContext.Challenges.Add(challange);
            }
        }
    }
}