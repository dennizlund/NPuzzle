using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Board.Moves move = Board.Moves.LeftArrow;

            Console.WriteLine("Please enter the dimension you want for NPuzzle");
            string userInput = Console.ReadLine();
            int setDimension;

            while(Int32.TryParse(userInput, out setDimension) == false)
            {
                Console.WriteLine("Please enter a valid integer");
                userInput = Console.ReadLine();
            }
            Board board = new Board(setDimension);

            board.DrawBoard();
            do
            {
                move = board.KeyPressed();
                board.Move(move);
                board.DrawBoard();
            } while (!board.IsSolved());

            Console.WriteLine("Congratulations, you have solved the puzzle!");
           

            
        }
    }
}
