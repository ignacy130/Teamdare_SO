using System.Collections.Generic;
using Teamdare.Resources.Extensions;

namespace Teamdare.Resources
{
	public class ResourcesStrings
	{
        //meta
		public const string WelcomeText = "Welcome, I am the wizard of this Castle " + Emoji.European_Castle + " and I will guide you in this adventure! :D I have some tasks for you for your first few days in this comp... ekhm... castle. Are you ready?";
		public const string AdventureCongratulationsOnChallenge = "Good job! You're on your way! " + Emoji.Clap;
        public const string AdventureChallengePostponed = "Yeah, we can do it later I guess...";
        public static string Congratulations
        {
            get
            {
                return new List<string>() { "Congratulations!", "You're doing good!", "You're doing great!", "You're good!", "Well done!", "Great job!", "Fantastic!", "I'm impressed!", "Atta boy!", "Perfect!", "Superb!" }.PickRandom();
            }
        }
        public const string AdventureNewChallengeForYou = "Here is a new challenge for you: ";
        public const string AdventureHowIsChallengeGoing = "How is your challenge going? Let me remind you : {0}";

        //adv 1
        public const string PeopleAdventureTitle = "Allyventure";
        public const string PeopleAdventureFinished = "Congratulations! You are in the team! During these challenges you get to know your colleagues, hunted with them and shared best memories! Here is a badge for you!";
        public const string IntroduceYourselfChallengeTitle = "Know me!";
        public const string IntroduceYourselfChallengeDescription = "Talk to the person on your right during break... Yeah, just start with weather! ;) He'll appreciate it! " + Emoji.Sunny;
        public const string LunchChallengeTitle = "Let's hunt!";
        public const string LunchChallengeDescription = "Ask your peers when they are heading to the hunt... to the lunch. " + Emoji.Hamburger;
        public const string SelfieChallengeTitle = "Exegi monumentum";
        public const string SelfieChallengeDescription = "Now, that you know your colleagues it's to time be remembered forever! Let's take a selfie with them! " + Emoji.Camera;

        //adv 2
        public const string FoodAdventureTitle = "Food, fast!";
        public const string FoodAdventureFinished = "Bravo! You discover food and elixir sources! Now you are fully aware how to gain energy to survive work day. Here is a badge for you!";
        public const string CoffieWithChallengeTitle = "Elixir of energy";
        public const string CoffieWithChallengeDescription = "Sometimes even greates heroes need more energy! Ask colleague on your right for a coffee break. " + Emoji.Coffee;
        public const string ShopChallengeTitle = "Show me your goods!";
        public const string ShopChallengeDescription = "Even so well managed company as the one you started working for may lack some goods. Ask your colleagues where is the nearest shop. " + Emoji.Department_Store;
        public const string BeerChallengeTitle = "Golden intoxicant";
        public const string BeerChallengeDescription = "It's Friday afternoon. If you don't have plans so may some of your peers. Beer with your new coleagues sounds good, doesn't it? " + Emoji.Beers;

        //adv 3
        public const string PlacesAdventureTitle = "The New World";
        public const string PlacesAdventureFinished = "Oh, you Columbus! You discoverd a whole new world of mistic company. You will never ever have problems with preparing your fresh lion, resting after and... yeah... you know, the restroom. Here is a badge for you!";
		public const string KitchenChallengeTitle = "Canteen is cool";
		public const string KitchenChallengeDescription = "Have a fresh deer but no microwave to prepare it? Ask you peer where is the kitchen! " + Emoji.Fork_And_Knife;
		public const string ToiletChallengeTitle = "The king's seat";
		public const string ToiletChallengeDescription = "Don't hold it in yourself! Ask her... where is the restroom " + Emoji.Runner;
		public const string RelaxRoomChallengeTitle = "Little Lie";
		public const string RelaxRoomChallengeDescription = "Little lie(s) are essential at workplace. Come back refreshed in 15 minutes! " + Emoji.Bath;
	}
}