/*Ludi : you can play with 2 to 4 players. a player needs to roll two 6s to get a piece out of the base.
 once a piece is out of the base, the player can move it forward by the number rolled on the dice.
 if a player rolls a 6, they get another turn. if a player lands on a space occupied by another player's piece, 
 the other player's piece is sent back to their base. the first player to get all their pieces to the finish line wins the game.
*/

/* |class Dice                
 --------------------------------
 - sides : int
 - topSide : int
 - rand : Random
 --------------------------------
 + Dice()
 + Dice(int)
 + Roll() : void
 + TopSide : int
 + Sides : int
 --------------------------------
 */
using System;

public class Dice
{
    private int sides;
    private int topSide;
    private static Random rand = new Random();

    // Default constructor
    public Dice()
    {
        sides = 6;
    }

    // Constructor with specified number of sides
    public Dice(int sides)
    {
        if (sides < 4)
        {
            throw new ArgumentOutOfRangeException("sides", "Number of sides must be at least 4.");
        }
        else
        {
            this.sides = sides;
        }
    }

    public void Roll()
    {
        topSide = rand.Next(1, sides + 1);
    }

    public int TopSide
    {
        get { return topSide; }
    }

    public int Sides
    {
        get { return sides; }
    }
}

// Test Case1:
//1. create a Dice object using default constructor 
//2. create a Dice object with positive number of sides
//3. check the topSide after rolling the dice, ensure it is within [1, sides]

public class DiceGame
{
     public static bool Contains(int[] array, int number)
        {
            foreach (int item in array)
            {
                if (item == number)
                {
                    return true;
                }
            }
            return false;
        }
       
       /*public static int[] UniqueRolls(Dice dice)
        {
            List<int> uniqueNumbers = new List<int>();

            while (uniqueNumbers.Count < dice.Sides)
            {
                dice.Roll();
                if (!uniqueNumbers.Contains(dice.TopSide))
                {
                    uniqueNumbers.Add(dice.TopSide);
                }
            }
            return uniqueNumbers.ToArray();
        }
        */

        public static int[] UniqueRolls(int[] rolls)
        {
            HashSet<int> uniqueNumbers = new HashSet<int>(rolls);
            return uniqueNumbers.ToArray();
        }
    public static void Main(String[] args)
    {
        Dice dice1 = new Dice();
        Dice dice2 = new Dice(10);

       // dice1.Roll();
        //dice2.Roll();

        //Console.WriteLine($"Dice1 ({dice1.Sides} sides) rolled: {dice1.TopSide}");
        //Console.WriteLine($"Dice2 ({dice2.Sides} sides) rolled: {dice2.TopSide}");


        /* Create two dice objects, roll the both dices and compare which one is bigger [X]
        Repeat the tasks above 5 times and compare which dice wins more [X]
        Implement a method to check if an array tracking the top side after rolling N = 5 times contains a given number. [X]
        Implement a method to create an array of unique numbers by rolling a dice (roll as many time as needed) [X]
        */

        int[] dice1Rolls = new int[5];
        int[] dice2Rolls = new int[5];
        int dice1Wins = 0;
        int dice2Wins = 0;

        for (int i = 0; i < 5; i++)
        {
            dice1.Roll();
            dice2.Roll();

            dice1Rolls[i] = dice1.TopSide;
            dice2Rolls[i] = dice2.TopSide;

            Console.WriteLine($"Round {i + 1}: Dice1 rolled {dice1.TopSide}, Dice2 rolled {dice2.TopSide}");
            if (dice1.TopSide > dice2.TopSide)
            {
                Console.WriteLine("Dice1 wins this round!");
                dice1Wins++;
            }
            else if (dice1.TopSide < dice2.TopSide)
            {
                Console.WriteLine("Dice2 wins this round!");
                dice2Wins++;
            }
            else
            {
                Console.WriteLine("It's a tie!");
            }
        }
        Console.WriteLine($"\nFinal Score:\n Dice1: {dice1Wins} - Dice2: {dice2Wins}");
        Console.WriteLine($"{(dice1Wins > dice2Wins ? "Dice1 wins the game!" : dice1Wins < dice2Wins ? "Dice2 wins the game!" : "The game is a tie!")}");
        
       int numCheck = 2;
    
       Console.WriteLine($"\nChecking if Dice1 rolls contain {numCheck}: {Contains(dice1Rolls, numCheck)}");

       Console.WriteLine($"Unique rolls from Dice2: {string.Join(", ", UniqueRolls(dice2Rolls))}");
        
    }
}