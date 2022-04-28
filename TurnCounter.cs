

using System;




namespace CardGame01 {


public class TurnCounter {
    public static bool isTurn;
    public static bool isGame;
    public static int turnCounter;


            public static void changeTurn () {

            if(isTurn == true && turnCounter == 0) {
                    
                Console.WriteLine();
                Console.WriteLine("this is player one");
                Console.ReadKey();
                isTurn = false;
                }

            if (isTurn == true && turnCounter > 0) {
                Console.WriteLine();
                Console.WriteLine("player one now has mana");
                Console.WriteLine(" p1 turn number: " + turnCounter);
                Console.ReadKey();
                isTurn = false;
                turnCounter++;

                }

            if (isTurn == false && turnCounter > 0) {
                Console.WriteLine();
                Console.WriteLine("player two now has mana");
                Console.WriteLine(" p2 turn number: " + turnCounter);
                Console.ReadKey();
                isTurn = true;
                turnCounter++;
                }
                
            if (isTurn == false && turnCounter == 0) {
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


}




}




