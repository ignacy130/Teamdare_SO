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
                new Tuple<string, string, string>(ResourcesStrings.PeopleAdventureTitle,
                    ResourcesStrings.PeopleAdventureFinished, ResourcesImages.PeopleBadge),
                new Tuple<string, string, string>(ResourcesStrings.FoodAdventureTitle,
                    ResourcesStrings.FoodAdventureFinished, ResourcesImages.FoodBadge),
                new Tuple<string, string, string>(ResourcesStrings.PlacesAdventureTitle,
                    ResourcesStrings.PlacesAdventureFinished, ResourcesImages.PlacesBadge)
            };

            var challanges = new List<List<Tuple<string,string>>>()
            {
                new List<Tuple<string,string>>()
                {
					new Tuple<string, string>(ResourcesStrings.IntroduceYourselfChallengeTitle , ResourcesStrings
                        .IntroduceYourselfChallengeDescription),
					new Tuple<string, string>(ResourcesStrings.LunchChallengeTitle, ResourcesStrings
                        .LunchChallengeDescription),
					new Tuple<string, string>(ResourcesStrings.SelfieChallengeTitle, ResourcesStrings
                        .SelfieChallengeDescription)
                },
				new List<Tuple<string,string>>()
				{
					new Tuple<string, string>(ResourcesStrings.CoffieWithChallengeTitle , ResourcesStrings
                        .CoffieWithChallengeDescription),
					new Tuple<string, string>(ResourcesStrings.ShopChallengeTitle , ResourcesStrings
                        .ShopChallengeDescription),
					new Tuple<string, string>(ResourcesStrings.BeerChallengeTitle , ResourcesStrings
                        .BeerChallengeDescription)
                },
				new List<Tuple<string,string>>()
				{
					new Tuple<string, string>(ResourcesStrings.ToiletChallengeTitle , ResourcesStrings
                        .ToiletChallengeDescription),
					new Tuple<string, string>(ResourcesStrings.RelaxRoomChallengeTitle , ResourcesStrings
                        .RelaxRoomChallengeDescription),
					new Tuple<string, string>(ResourcesStrings.KitchenChallengeTitle , ResourcesStrings
                        .KitchenChallengeDescription)
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