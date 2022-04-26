using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireDeckTest
{

    class Program
    {

        public static int consoleWidth = 200;
        public bool createDeck = true;
        static void Main(string[] args)
        {


            Console.SetWindowSize(150, 50);
            CreateMainStory();

            //using lists for each of the areas areas
            List<Card> shuffled = new List<Card>();
            List<Card> startHand = new List<Card>();
            List<Card> fieldArea = new List<Card>();
            List<Card> graveyardArea = new List<Card>();
            //create the enemy avatar
            Card player = new FireAvatar();
            Card enemy = new WaterAvatar();

            List<Card> deck = new List<Card>
            {
            //deck created with card objects
                new ImpCard(), new ImpCard(), new ImpCard(),
                new LittleDraco(), new LittleDraco(), new LittleDraco(),
                new SpiritOFire(), new SpiritOFire(), new SpiritOFire(),
                new FireDrake(), new FireDrake(), new FireDrake(),
                new FireBall(), new FireBall(), new FireBall(),
                new FlameStrike(), new FlameStrike(), new FlameStrike(),
                new WildFire(), new WildFire(), new WildFire() };

            //these three methods are to be run first
            shuffleFunction(deck, shuffled);
            Console.WriteLine();
            Console.WriteLine("~~~~~~SHUFFLED~~~~~~");
            CommanderInfo(player, enemy);
            createHand(shuffled, startHand);
            //set playerTurn true
            playerTurn(player, enemy, shuffled, startHand, fieldArea, graveyardArea);
        }

        public static void CreateMainStory()
                {
                    Console.SetCursorPosition(100,3);
                    Console.WriteLine("    |<--- Trading Card Game! --->|");
                    Console.WriteLine("\n|<--- Press Enter to Continue --->|");
                    Console.WriteLine();
                    Console.ReadKey();
                }

        public static void shuffleFunction(List<Card> deck, List<Card> shuffled)
        {

            Random ran = new Random();

            int count = deck.Count();
            int selection = 0;

            for (int i = 0; i < count; i++)
            {
                selection = ran.Next(deck.Count - 1);
                shuffled.Add(deck[selection]);
                deck.RemoveAt(selection);
            }
            //shuffled deck

            //dont need to print deck
            //foreach (var card in shuffled)
            //{
            //    Console.WriteLine("Deck number: " + (shuffled.IndexOf(card) + 1) + card.ToString());
            //}

        }
        public static void createHand(List<Card> shuffled, List<Card> startHand)
        {
            int drawSize = 3;
            int deckIndex = shuffled.Count();

            for (int i = 0; i < drawSize; i++)
            {
                startHand.Add(shuffled[0]);
                shuffled.RemoveAt(0);
            }
        }

        //could probably change this to if(firstTurn = true) { //draw one } else { //draw two }
        public static void drawFunction(List<Card> startHand, List<Card> shuffled)
        {
            Console.WriteLine("Adding one card to your hand.");
            startHand.Add(shuffled[0]);
            shuffled.RemoveAt(0);

            //Console.WriteLine();
            //Console.WriteLine("Are you going first or second? Press 1 for first and 2 for second.");
            ////create a drawCard function
            ////if firstTurn
            ////add one
            ////else add two
            //var input = Console.ReadLine();
            //Int32.TryParse(input, out int result);
            //switch (result)
            //{
            //    case 1:
            //        Console.WriteLine("Adding one card to your hand.");
            //        startHand.Add(shuffled[0]);
            //        shuffled.RemoveAt(0);
            //        break;
            //    case 2:
            //        Console.WriteLine("Adding two cards to your hand.");
            //        startHand.Add(shuffled[0]);
            //        shuffled.RemoveAt(0);
            //        startHand.Add(shuffled[0]);
            //        shuffled.RemoveAt(0);
            //        break;
            //    default:
            //        isFirstTurn(startHand, shuffled);
            //        loop
            //        break;
            //}
        }

        public static void playerTurn(Card player, Card enemy, List<Card> shuffled, List<Card> startHand, List<Card> fieldArea, List<Card> graveyard)
        {
            while (enemy.Health > 0)
            {
                //play game
                if (player.playerTurn == false)
                {

                    printField(fieldArea);
                    Console.WriteLine("player mana: {0} and player turn {0}", player.currentMana, player.playerTurnCount);
                    player.playerTurn = true;
                    drawFunction(startHand, shuffled);
                    handSelection(startHand, fieldArea, player, enemy); // have no breaks in this yet -- maybe create if statement functions
                    foreach (var card in fieldArea)
                    {
                        Console.WriteLine("Field slot {0}: " + card.CardName, fieldArea.IndexOf(card) + 1);
                        if (card.isCreature == true && card.summonSickness == false) {
                            card.dealDamage(enemy);
                            //it exits after enemy is at 0 hp
                            //looking at mono game right now
                        } else if (card.summonSickness == true) {
                            Console.WriteLine("Can't attack this turn");
                            card.summonSickness = false;
                        }
                        if (card.CardName == "Little Draco")
                        {
                            Console.WriteLine("do fire logic");
                            //nesting 6 if statements isnt bad logic is it LMAO
                        }
                    }
                    //use currentMana
                    //cost   
                }
            } //ends game
        }


        public static void handSelection(List<Card> startHand, List<Card> fieldArea, Card player, Card enemy)
        {
            //printHand(startHand, fieldArea, player, enemy);
            //if (player.currentMana <= 0)
            //{
            //    Console.WriteLine("Out of mana");
            //    endTurn(startHand, fieldArea, player, enemy);
            //}
            //else {
            //    handSelection(startHand, fieldArea, player, enemy);
            //}
            int numCard = 0;
            Console.WriteLine();
            Console.WriteLine("Look at card in your hand using 1-6. 7 to view hand. 8 To view field. 9 to quit.");
            var input = Console.ReadLine();
            Int32.TryParse(input, out numCard);
            //will default to 0 if nothing selected
            switch (numCard)
            {
                case 1:
                    try
                    {
                        Console.WriteLine("You selected: " + startHand[numCard - 1].CardName);
                        startHand[numCard - 1].printCard();
                        Console.WriteLine("Press 1 to play the card. 2 to go back to hand.");
                        var numInput = Console.ReadLine();
                        Int32.TryParse(numInput, out int choice);
                        //default || zero if nothing input
                        switch (choice)
                        {
                            case 1:
                                if (startHand[numCard - 1].isCreature == true && startHand[numCard - 1].Cost <= player.currentMana)
                                {
                                    //if creature place on field && summonSickness == true
                                    //remove from hand and place on field
                                    Console.WriteLine("You played: " + startHand[numCard - 1].CardName);
                                    startHand[numCard - 1].summonSickness = true;
                                    fieldArea.Add(startHand[numCard - 1]);
                                    startHand.RemoveAt(numCard - 1);
                                    endTurn(startHand, fieldArea, player, enemy);
                                    player.playerTurn = false;
                                    player.currentMana--;
                                    break;
                                    //handSelection(startHand, fieldArea, player, enemy);
                                }
                                else if (startHand[numCard - 1].isCreature == true && startHand[numCard - 1].Cost >= player.currentMana)
                                {
                                    Console.WriteLine("This creature costs more than 1 mana");
                                    Console.ReadKey();
                                    handSelection(startHand, fieldArea, player, enemy);
                                }
                                else if (startHand[numCard - 1].isCreature == false && startHand[numCard - 1].Cost <= player.currentMana)
                                {
                                    Console.WriteLine("You played: " + startHand[numCard - 1].CardName);
                                    fieldArea.Add(startHand[numCard - 1]);
                                    startHand.RemoveAt(numCard - 1);
                                    startHand[numCard - 1].dealDamage(enemy);
                                    player.playerTurn = false;
                                    break;
                                    //damage logic
                                }
                                else if (startHand[numCard - 1].isCreature == false && startHand[numCard - 1].Cost >= player.currentMana)
                                {
                                    Console.WriteLine("This spell costs more than 1 mana");
                                    Console.ReadKey();
                                    handSelection(startHand, fieldArea, player, enemy);
                                }

                                ////card action and select targets etc
                                //startHand[numCard - 1].dealDamage(avatar);
                                //startHand.RemoveAt(numCard - 1);
                                //start next turn
                                break;
                            case 2:
                                handSelection(startHand, fieldArea, player, enemy);
                                break;
                            default:
                                handSelection(startHand, fieldArea, player, enemy);
                                break;
                        }
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        Console.WriteLine(e.Message);
                        handSelection(startHand, fieldArea, player, enemy);
                    }
                    break;
                case 2:
                    try
                    {
                        Console.WriteLine("You selected: " + startHand[numCard - 1].CardName);
                        startHand[numCard - 1].printCard();
                        ///Console.WriteLine("You selected: " + startHand[0].CardName);
                        Console.WriteLine("Press 1 to play the card. 2 to go back to hand.");
                        var numInput = Console.ReadLine();
                        Int32.TryParse(numInput, out int choice);
                        switch (choice)
                        {
                            case 1:
                                if (startHand[numCard - 1].isCreature == true && startHand[numCard - 1].Cost <= 1)
                                {
                                    //if creature place on field && summonSickness == true
                                    //remove from hand and place on field
                                    Console.WriteLine("You played: " + startHand[numCard - 1].CardName);
                                    startHand[numCard - 1].summonSickness = true;
                                    fieldArea.Add(startHand[numCard - 1]);
                                    startHand.RemoveAt(numCard - 1);
                                    player.playerTurn = false;
                                    break;
                                }
                                else if (startHand[numCard - 1].isCreature == true && startHand[numCard - 1].Cost >= 1)
                                {
                                    Console.WriteLine("This creature costs more than 1 mana");
                                    Console.ReadKey();
                                    handSelection(startHand, fieldArea, player, enemy);
                                }
                                else if (startHand[numCard - 1].isCreature == false && startHand[numCard - 1].Cost <= 1)
                                {
                                    Console.WriteLine("You played: " + startHand[numCard - 1].CardName);
                                    fieldArea.Add(startHand[numCard - 1]);
                                    startHand.RemoveAt(numCard - 1);
                                    handSelection(startHand, fieldArea, player, enemy);
                                    startHand[numCard - 1].dealDamage(enemy);
                                    //damage logic
                                }
                                else if (startHand[numCard - 1].isCreature == false && startHand[numCard - 1].Cost >= 1)
                                {
                                    Console.WriteLine("This spell costs more than 1 mana");
                                    Console.ReadKey();
                                    handSelection(startHand, fieldArea, player, enemy);
                                }

                                ////card action and select targets etc
                                //startHand[numCard - 1].dealDamage(avatar);
                                //startHand.RemoveAt(numCard - 1);
                                //start next turn
                                break;
                            case 2:
                                handSelection(startHand, fieldArea, player, enemy);
                                break;
                            default:
                                handSelection(startHand, fieldArea, player, enemy);
                                break;
                        }
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        //throw new ArgumentOutOfRangeException("no card in this slot", e);
                        Console.WriteLine(e.Message);
                        handSelection(startHand, fieldArea, player, enemy);
                    }
                    break;
                case 3:
                    try
                    {
                        Console.WriteLine("You selected: " + startHand[numCard - 1].CardName);
                        startHand[numCard - 1].printCard();
                        ///Console.WriteLine("You selected: " + startHand[0].CardName);
                        Console.WriteLine("Press 1 to play the card. 2 to go back to hand.");
                        var numInput = Console.ReadLine();
                        Int32.TryParse(numInput, out int choice);
                        switch (choice)
                        {
                            case 1:
                                if (startHand[numCard - 1].isCreature == true && startHand[numCard - 1].Cost <= 1)
                                {
                                    //if creature place on field && summonSickness == true
                                    //remove from hand and place on field
                                    Console.WriteLine("You played: " + startHand[numCard - 1].CardName);
                                    startHand[numCard - 1].summonSickness = true;
                                    fieldArea.Add(startHand[numCard - 1]);
                                    startHand.RemoveAt(numCard - 1);
                                    handSelection(startHand, fieldArea, player, enemy);
                                }
                                else if (startHand[numCard - 1].isCreature == true && startHand[numCard - 1].Cost >= 1)
                                {
                                    Console.WriteLine("This creature costs more than 1 mana");
                                    Console.ReadKey();
                                    handSelection(startHand, fieldArea, player, enemy);
                                }
                                else if (startHand[numCard - 1].isCreature == false && startHand[numCard - 1].Cost <= 1)
                                {
                                    Console.WriteLine("You played: " + startHand[numCard - 1].CardName);
                                    fieldArea.Add(startHand[numCard - 1]);
                                    startHand.RemoveAt(numCard - 1);
                                    handSelection(startHand, fieldArea, player, enemy);
                                    //damage logic
                                }
                                else if (startHand[numCard - 1].isCreature == false && startHand[numCard - 1].Cost >= 1)
                                {
                                    Console.WriteLine("This spell costs more than 1 mana");
                                    Console.ReadKey();
                                    handSelection(startHand, fieldArea, player, enemy);
                                }

                                ////card action and select targets etc
                                //startHand[numCard - 1].dealDamage(avatar);
                                //startHand.RemoveAt(numCard - 1);
                                //start next turn
                                break;
                            case 2:
                                handSelection(startHand, fieldArea, player, enemy);
                                break;
                            default:
                                handSelection(startHand, fieldArea, player, enemy);
                                break;
                        }
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        //throw new ArgumentOutOfRangeException("no card in this slot", e);
                        Console.WriteLine(e.Message);
                        handSelection(startHand, fieldArea, player, enemy);
                    }
                    break;
                case 4:
                    try
                    {
                        Console.WriteLine("You selected: " + startHand[numCard - 1].CardName);
                        startHand[numCard - 1].printCard();
                        ///Console.WriteLine("You selected: " + startHand[0].CardName);
                        Console.WriteLine("Press 1 to play the card. 2 to go back to hand.");
                        var numInput = Console.ReadLine();
                        Int32.TryParse(numInput, out int choice);
                        switch (choice)
                        {
                            case 1:
                                if (startHand[numCard - 1].isCreature == true && startHand[numCard - 1].Cost <= 1)
                                {
                                    //if creature place on field && summonSickness == true
                                    //remove from hand and place on field
                                    Console.WriteLine("You played: " + startHand[numCard - 1].CardName);
                                    startHand[numCard - 1].summonSickness = true;
                                    fieldArea.Add(startHand[numCard - 1]);
                                    startHand.RemoveAt(numCard - 1);
                                    handSelection(startHand, fieldArea, player, enemy);
                                }
                                else if (startHand[numCard - 1].isCreature == true && startHand[numCard - 1].Cost >= 1)
                                {
                                    Console.WriteLine("This creature costs more than 1 mana");
                                    Console.ReadKey();
                                    handSelection(startHand, fieldArea, player, enemy);
                                }
                                else if (startHand[numCard - 1].isCreature == false && startHand[numCard - 1].Cost <= 1)
                                {
                                    Console.WriteLine("You played: " + startHand[numCard - 1].CardName);
                                    fieldArea.Add(startHand[numCard - 1]);
                                    startHand.RemoveAt(numCard - 1);
                                    handSelection(startHand, fieldArea, player, enemy);
                                    //damage logic
                                }
                                else if (startHand[numCard - 1].isCreature == false && startHand[numCard - 1].Cost >= 1)
                                {
                                    Console.WriteLine("This spell costs more than 1 mana");
                                    Console.ReadKey();
                                    handSelection(startHand, fieldArea, player, enemy);
                                }

                                ////card action and select targets etc
                                //startHand[numCard - 1].dealDamage(avatar);
                                //startHand.RemoveAt(numCard - 1);
                                //start next turn
                                break;
                            case 2:
                                handSelection(startHand, fieldArea, player, enemy);
                                break;
                            default:
                                handSelection(startHand, fieldArea, player, enemy);
                                break;
                        }
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        //throw new ArgumentOutOfRangeException("no card in this slot", e);
                        Console.WriteLine(e.Message);
                        handSelection(startHand, fieldArea, player, enemy);
                    }
                    break;
                case 5:
                    try
                    {
                        Console.WriteLine("You selected: " + startHand[numCard - 1].CardName);
                        startHand[numCard - 1].printCard();
                        ///Console.WriteLine("You selected: " + startHand[0].CardName);
                        Console.WriteLine("Press 1 to play the card. 2 to go back to hand.");
                        var numInput = Console.ReadLine();
                        Int32.TryParse(numInput, out int choice);
                        switch (choice)
                        {
                            case 1:
                                if (startHand[numCard - 1].isCreature == true && startHand[numCard - 1].Cost <= 1)
                                {
                                    //if creature place on field && summonSickness == true
                                    //remove from hand and place on field
                                    Console.WriteLine("You played: " + startHand[numCard - 1].CardName);
                                    startHand[numCard - 1].summonSickness = true;
                                    fieldArea.Add(startHand[numCard - 1]);
                                    startHand.RemoveAt(numCard - 1);
                                    handSelection(startHand, fieldArea, player, enemy);
                                }
                                else if (startHand[numCard - 1].isCreature == true && startHand[numCard - 1].Cost >= 1)
                                {
                                    Console.WriteLine("This creature costs more than 1 mana");
                                    Console.ReadKey();
                                    handSelection(startHand, fieldArea, player, enemy);
                                }
                                else if (startHand[numCard - 1].isCreature == false && startHand[numCard - 1].Cost <= 1)
                                {
                                    Console.WriteLine("You played: " + startHand[numCard - 1].CardName);
                                    fieldArea.Add(startHand[numCard - 1]);
                                    startHand.RemoveAt(numCard - 1);
                                    handSelection(startHand, fieldArea, player, enemy);
                                    //damage logic
                                }
                                else if (startHand[numCard - 1].isCreature == false && startHand[numCard - 1].Cost >= 1)
                                {
                                    Console.WriteLine("This spell costs more than 1 mana");
                                    Console.ReadKey();
                                    handSelection(startHand, fieldArea, player, enemy);
                                }

                                ////card action and select targets etc
                                //startHand[numCard - 1].dealDamage(avatar);
                                //startHand.RemoveAt(numCard - 1);
                                //start next turn
                                break;
                            case 2:
                                handSelection(startHand, fieldArea, player, enemy);
                                break;
                            default:
                                handSelection(startHand, fieldArea, player, enemy);
                                break;
                        }
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        //throw new ArgumentOutOfRangeException("no card in this slot", e);
                        Console.WriteLine(e.Message);
                        handSelection(startHand, fieldArea, player, enemy);
                    }
                    break;
                case 6:
                    try
                    {
                        Console.WriteLine("You selected: " + startHand[numCard - 1].CardName);
                        startHand[numCard - 1].printCard();
                        ///Console.WriteLine("You selected: " + startHand[0].CardName);
                        Console.WriteLine("Press 1 to play the card. 2 to go back to hand.");
                        var numInput = Console.ReadLine();
                        Int32.TryParse(numInput, out int choice);
                        switch (choice)
                        {
                            case 1:
                                if (startHand[numCard - 1].isCreature == true && startHand[numCard - 1].Cost <= 1)
                                {
                                    //if creature place on field && summonSickness == true
                                    //remove from hand and place on field
                                    Console.WriteLine("You played: " + startHand[numCard - 1].CardName);
                                    startHand[numCard - 1].summonSickness = true;
                                    fieldArea.Add(startHand[numCard - 1]);
                                    startHand.RemoveAt(numCard - 1);
                                    handSelection(startHand, fieldArea, player, enemy);
                                }
                                else if (startHand[numCard - 1].isCreature == true && startHand[numCard - 1].Cost >= 1)
                                {
                                    Console.WriteLine("This creature costs more than 1 mana");
                                    Console.ReadKey();
                                    handSelection(startHand, fieldArea, player, enemy);
                                }
                                else if (startHand[numCard - 1].isCreature == false && startHand[numCard - 1].Cost <= 1)
                                {
                                    Console.WriteLine("You played: " + startHand[numCard - 1].CardName);
                                    fieldArea.Add(startHand[numCard - 1]);
                                    startHand.RemoveAt(numCard - 1);
                                    //damage logic
                                }
                                else if (startHand[numCard - 1].isCreature == false && startHand[numCard - 1].Cost >= 1)
                                {
                                    Console.WriteLine("This spell costs more than 1 mana");
                                    Console.ReadKey();
                                    handSelection(startHand, fieldArea, player, enemy);
                                }

                                ////card action and select targets etc
                                //startHand[numCard - 1].dealDamage(avatar);
                                //startHand.RemoveAt(numCard - 1);
                                //start next turn
                                break;
                            case 2:
                                handSelection(startHand, fieldArea, player, enemy);
                                break;
                            default:
                                handSelection(startHand, fieldArea, player, enemy);
                                break;
                        }
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        //throw new ArgumentOutOfRangeException("no card in this slot", e);
                        Console.WriteLine(e.Message);
                        handSelection(startHand, fieldArea, player, enemy);
                    }
                    break;
                case 7:
                    printHand(startHand, fieldArea, player, enemy);
                    handSelection(startHand, fieldArea, player, enemy);
                    break;
                case 8:
                    CommanderInfo(player, enemy);
                    printField(fieldArea);
                    endTurn(startHand, fieldArea, player, enemy);
                    break;
                case 9:
                    endTurn(startHand, fieldArea, player, enemy);
                    break;
                default:
                    handSelection(startHand, fieldArea, player, enemy);
                    break;
            }
        }



        public static void CommanderInfo(Card player, Card enemy)
        {
            Console.WriteLine("----Your Commanders Info---");
            player.printCard();
            Console.WriteLine("---Enemy Commander Info---");
            enemy.printCard();
        }

        public static void printHand(List<Card> startHand, List<Card> fieldArea, Card player, Card enemy)
        {
            //print hand
            Console.WriteLine("~~~~~~Your Hand~~~~~~");

            foreach (var card in startHand)
            {

                Console.WriteLine("Card: {0} " + card.ToString(), (startHand.IndexOf(card) + 1));
            }
            endTurn(startHand, fieldArea, player, enemy);
        }

        public static void endTurn(List<Card> startHand, List<Card> fieldArea, Card player, Card enemy)
        {
            Console.WriteLine("End turn? Press 1 for yes 2 for no.");
            var input = Console.ReadLine();
            Int32.TryParse(input, out int result);
            switch (result)
            {
                case 1:
                    Console.WriteLine("Mana++ here");
                    player.playerTurnCount++;
                    player.currentMana++;
                    player.maxMana++;
                    player.playerTurn = false;
                    break;
                case 2:
                    handSelection(startHand, fieldArea, player, enemy);
                    break;
                default:
                    Console.WriteLine("nothing here");
                    handSelection(startHand, fieldArea, player, enemy);
                    //ends
                    //send into a function for while loop
                    break;
            }
        }

        public static void printField(List<Card> fieldArea)
        {
            Console.WriteLine("*FIELD AREA*");

            foreach (var card in fieldArea)
            {
                Console.WriteLine("Field slot {0}: " + card.CardName, fieldArea.IndexOf(card) + 1);
            }
        }
    }
}
