
// if(isTurn == false){
                //     //isTurn = changeTurn(isTurn, turnCounter, playerNumber);

                //     if (isTurn == true && turnCounter == 0){
                //         Console.WriteLine();
                //         Console.WriteLine("printed player 2");
                //         Console.WriteLine("first turn single mana count");
                //     }
                    
                // }

                // if(isTurn == true && turnCounter == 0){
                //     //isTurn = changeTurn(isTurn, turnCounter, playerNumber);
                //     turnCounter++;
                //     Console.WriteLine();
                //     Console.WriteLine("printed player 1");
                //     Console.WriteLine("turn number:" + turnCounter);
                //     isTurn = false;
                //     Console.ReadKey();
                    
                // }
                // else {
                //     Console.WriteLine();
                //     Console.WriteLine("no turns here");
                // }


        // public static bool changeTurn (bool turnStart, int turnNum){


        //     if (turnStart == true && turnNum == 0) {
        //         Console.WriteLine();
        //         Console.WriteLine("Player One turn");
        //         Console.WriteLine("is turn = true");
        //         Console.ReadKey();
        //         return false;
        //     }

        //     else if (turnStart == false && turnNum == 0)  {
        //         Console.WriteLine();
        //         Console.WriteLine("Player two turn");
        //         Console.WriteLine("isTurn = false");
        //         Console.ReadKey();
        //         return true;
        //     }
            
        //     else if (turnStart == true && turnNum > 0) {
        //         Console.WriteLine();
        //         Console.WriteLine("Player one SHOULD BE HERE");
        //         Console.WriteLine("Second turn");
        //         Console.ReadKey();
        //         return false;
        //     }
            
        //     else if (turnStart == false && turnNum > 0){
        //         Console.WriteLine();
        //         Console.WriteLine("To start press any key. SHOULD BE HERE FOR PLAYER 2");
        //         Console.WriteLine("Or this is player two turn #");
        //         Console.ReadKey();
        //         return true;
        //     }
        //     else {
        //         return turnStart;
        //     }


        // }



//hand selection
//will exit when i set playerTurn to false
//if the player picks a card && has no mana >> go to end turn
//must call playerTurn method again
//
//use commander card to track the numbers i want to use?
//after hand selection i need field selection
//
//at 0 mana end turn and loop back to draw until enemy health is 0
//
//foreach (var card in deck) //print deck
//{
//    Console.WriteLine(card.ToString());
//    //+"\n Card: {0}" , deck.IndexOf(card) + 1
//}
//rewrite a new method that takes all objects: shuffled, hand, field, graveyard, player, enemy
//i need an attack function
//maybe do a staging area??
//
//while player.playerTurn = true 
//probably want this in a function
//all 6 major objects have to be in my function
//create hand
//mana
//show hp
//show field
//play card
//resolve field(?) make everything attack
//end > loop > mana up
//have to send mana to allow cards to be cast
//+1 mana each turn
//

//function to create cards and add to a list?
//now that ive got my switch statements written as functions i can use them here 
//
//turns[] -- error in turn logic that doesnt always reset turn after endturn method
//--REQUIRES => player, enemy, hand, shuffled, field, graveyard
//---> something is added/removed/changed in these <---
//---> have a function that holds each turn action
//---> <start turn> <show mana> <show enemy & player hp> <show field> 
//---> <create hand> <draw> <play card> <mana up> <end turn>

//~~~~STEPS TO DO FOR TCG~~~//~~NOTES INCLUDED IN THIS~~//
//Create Deck object x
//create player object that takes inputs for other objects x
//find out what variables x
//i need to figure out a curve for 21 cards with the 7 cards
//3 of each card x
//create a hand x
//create a field x
//create a graveyard x
//each turn: draw > main phase(play cards to field) > attack phase(move to field from graveyard) > end turn
//loop turn until a player is below 0 health

//start creating program here
//for a card game the steps i need are
//create deck x
//create hand x
//select card from hand x
//play card x
//end turn x

////
//ways of creating a deck
//hard code the deck of 21 with specific cards and use loops to make multiples
//i need to put the cards into a list and then create a shuffle loop to display 3 random card names 
//to hard code the deck i need to add the number of cards at cost and duplicates
//21 cards in a deck 
//3 of each card
//
//create the cards that make the deck
//7 cards and 3 of each
//chose to create each card individually
//now I need to to shuffle the deck
////
///
//

//
//turn based system
//use card for the object constructor for both the player and the target
//steps to take for a single turn
//show player and enemy health and mana
//draw[x]
//select card[x]
//play card[x]
//show field(use field)[]
//select field card[]
//end turn[x]



//first loop is while player or enemy health is above 0 keep creating turns
//second loop that adds one mana to the avatar per turn to a max of 5(maybe iterate after each turn with isMaxMana)
//

//->if creature summonedSickness = false 
//-- ask if they want to attack
//->if spell cast it or go back to hand
//->if creature select to play or go back to hand
//-->same steps for player 2

//show player health and mana crystals(have 1 at the start, mana++ each looping turn to a max of 5) 
//have main loop be while (enemy.hp || player.hp > 0)  { // do logic}
//inside the main loop have a while (mana < 5) { mana++; }
//conditions of player.draw == true && player.playCard == true && player.endTurn??
//or give player options and use conditions to say playing this card isnt possible?
//

//maybe do a turn one bool
//one single turn is draw > pick > play > show field > pick > attack > end
//Second turn > automate the steps with the idea that the AI will play one > two > three mana costs
//OR I can do player turn and have player input
//

//everything is in the handselection
//my logic sends the card selected to the field
//create the loop to go through the program and adds mana
//make sure all my objects and properties allow for each method to work
//loop until health
//add each card properties as methods that check what object is in the fieldarea and plays
//
//

using System;



namespace CardGame01
{
    class Program
    {
        //global variables
        public static bool isTurn;
        public static bool isGame;
        public static int turnCounter;
        public static void changeTurn () {

            if (isTurn == true && turnCounter == 0) {
                    
                Console.WriteLine();
                Console.WriteLine("this is player one");
                Console.ReadKey();
                isTurn = false;
                }

            else if (isTurn == true && turnCounter > 0) {
                Console.WriteLine();
                Console.WriteLine("player one now has mana");
                Console.WriteLine(" p1 turn number: " + turnCounter);
                Console.ReadKey();
                isTurn = false;
                turnCounter++;

                }

            else if (isTurn == false && turnCounter > 0) {
                Console.WriteLine();
                Console.WriteLine("player two now has mana");
                Console.WriteLine(" p2 turn number: " + turnCounter);
                Console.ReadKey();
                isTurn = true;
                turnCounter++;
                }
                
            else if (isTurn == false && turnCounter == 0) {
                Console.WriteLine();
                Console.WriteLine("this player two");
                Console.ReadKey();
                isTurn = true;
                turnCounter++;
                }


                else {
                Console.WriteLine();
                Console.WriteLine("this is random else");
                Console.ReadKey();

                }

        }
        public static void gameStart (bool isGame, bool isTurn, int turnCounter) {
            do {
                changeTurn();
            } while (isGame == true);
        }
        // What do I need?
        static void Main(string[] args)
        {
            // turnStart = false;
            // gameStart = false;
            Console.SetWindowSize(150, 40);

            for (int i = 0; i < 150; i++) {
                Console.SetCursorPosition(i,0);
                Console.WriteLine("*");
            }
            Console.SetCursorPosition(62,2);
            Console.WriteLine("Hello World 2222!");
            Console.WriteLine();
            Console.ReadKey();
            turnCounter = 0;
            isGame = true;
            isTurn = true;
            gameStart(isGame, isTurn, turnCounter);
        }
    }
}
