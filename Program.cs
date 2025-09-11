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
    public static void Main(String[] args)
    {
        Dice dice1 = new Dice();
        Dice dice2 = new Dice(10);

        dice1.Roll();
        dice2.Roll();

        Console.WriteLine($"Dice1 ({dice1.Sides} sides) rolled: {dice1.TopSide}");
        Console.WriteLine($"Dice2 ({dice2.Sides} sides) rolled: {dice2.TopSide}");
    }
}