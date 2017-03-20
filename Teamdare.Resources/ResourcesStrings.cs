using System.Collections.Generic;
using Teamdare.Resources.Extensions;

namespace Teamdare.Resources
{
	public class ResourcesStrings
	{
		public const string WelcomeText = "Welcome, I am the wizard of this Castle and I will guide you in this adventure! :D I have some tasks for you for your first few days in this comp... ekhm... castle. Are you ready?";

		public const string AdventureNewChallengeForYou = "Here is a new challenge for you: ";
		public const string AdventureHowIsChallengeGoing = "How is your challenge going? Let me remind you : {0}";
		public const string AdventureCongratulationsOnChallenge = "Good job! You're on your way!";
		public const string AdventurePeopleAdventureTitle = "Allyventure";
		public const string AdventurePeopleAdventureFinished = "Congratulations! You are in the team! During these challenges you get to know your colleagues, hunted with them and shared best memories! Here is a badge for you!";
		public const string AdventureIntroduceYourselfChallengeTitle = "Know me!";
		public const string AdventureIntroduceYourselfChallengeDescription = "Talk to the person on your right during break... Yeah, just start with weather! ;) He'll appreciate it!";
		public const string AdventureLunchChallengeTitle = "Let's hunt!";
		public const string AdventureLunchChallengeDescription = "Ask your peers when they are heading to the hunt... to the lunch.";
		public const string AdventureSelfieChallengeTitle = "Exegi monumentum";
		public const string AdventureSelfieChallengeDescription = "Now, that you know your colleagues it's to time be remembered forever! Let's take a selfie with them!";
		public const string AdventureFoodAdventureTitle = "Food, fast!";
		public const string AdventureFoodAdventureFinished = "Bravo! You discover food and elixir sources! Now you are fully aware how to gain energy to survive work day. Here is a badge for you!";
		public const string AdventureCoffieWithChallengeTitle = "Elixir of energy";
		public const string AdventureCoffieWithChallengeDescription = "Sometimes even greates heroes need more energy! Ask colleague on your right for a coffee break.";
		public const string AdventureShopChallengeTitle = "Show me your goods!";
		public const string AdventureShopChallengeDescription = "Even so well managed company as the one you started working for may lack some goods. Ask your colleagues where is the nearest shop.";
		public const string AdventureBeerChallengeTitle = "Golden intoxicant";
		public const string AdventureBeerChallengeDescription = "It's Friday afternoon. If you don't have plans so may some of your peers. Beer with your new coleagues sounds good, doesn't it?";
		public const string AdventurePlacesAdventureTitle = "The New World";
		public const string AdventurePlacesAdventureFinished = "Oh, you Columbus! You discoverd a whole new world of mistic company. You will never ever have problems with preparing your fresh lion, resting after and... yeah... you know, the restroom. Here is a badge for you!";
		public const string AdventureKitchenChallengeTitle = "Canteen is cool";
		public const string AdventureKitchenChallengeDescription = "Have a fresh deer but no microwave to prepare it? Ask you peer where is the kitchen!";
		public const string AdventureToiletChallengeTitle = "The king's seat";
		public const string AdventureToiletChallengeDescription = "Don't hold it in yourself! Ask her... where is the restroom";
		public const string AdventureRelaxRoomChallengeTitle = "Little Lie";
		public const string AdventureRelaxRoomChallengeDescription = "Little lie(s) are essential at workplace. Come back refreshed in 15 minutes!";
		public const string AdventureChallengePostponed = "Yeah, we can do it later I guess...";

		public static string Congratulations {
			get{
				return new List<string>() { "Congratulations!", "You're doing good!", "You're doing great!", "You're good!", "Well done!", "Great job!", "Fantastic!", "I'm impressed!", "Atta boy!", "Perfect!", "Superb!" }.PickRandom();
			}
		}

	}
}