using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPuzzle
{
    class Board
    {
        private Tile[,] PuzzleBoard;
        readonly int Dimension;
        Position Empty;
        public enum Moves { Zero, LeftArrow, RightArrow, UpArrow, DownArrow }

        public Board(int dimension)
        {
            Dimension = dimension;
            PuzzleBoard = new Tile[dimension, dimension];
            FillBoard(PuzzleBoard);
            Empty.x = Empty.y = (Dimension -1); // Sätter tomma positionens plats.
            Scramble();
        }

        private void FillBoard(Tile[,] boardToFill)
        {
            int value = 1;

            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    if(i == (Dimension-1) && j == (Dimension-1)) // Om det är sista positionen ska vi lägga till en nolla istället för nästa tal.
                    {
                        boardToFill[i, j] = new Tile(0);
                    }
                    else
                    {
                        boardToFill[i, j] = new Tile(value++);
                    }
                    
                }

            }

        }

        public Moves KeyPressed()
        {
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();

            if (consoleKeyInfo.Key == ConsoleKey.LeftArrow)
                return Moves.LeftArrow;
            else if (consoleKeyInfo.Key == ConsoleKey.RightArrow)
                return Moves.RightArrow;
            else if (consoleKeyInfo.Key == ConsoleKey.UpArrow)
                return Moves.UpArrow;
            else if (consoleKeyInfo.Key == ConsoleKey.DownArrow)
                return Moves.DownArrow;
            else if (consoleKeyInfo.Key == ConsoleKey.Escape)
                return 0;
            else
                return 0;
        }

        public void Move(Moves d)
        {
            if (d == Moves.LeftArrow)
            {
                Position LeftMove = Empty;
                if (LeftMove.y > 0 && LeftMove.y < Dimension)
                {
                    LeftMove.y--;
                    SwapTiles(LeftMove);
                }

            }
            else if (d == Moves.RightArrow)
            {
                Position RightMove = Empty;
                if (RightMove.y >= 0 && (RightMove.y < Dimension - 1))
                {
                    RightMove.y++;
                    SwapTiles(RightMove);
                }


            }
            else if (d == Moves.UpArrow)
            {
                Position UpMove = Empty;
                if (UpMove.x > 0 && (UpMove.x < Dimension))
                {
                    UpMove.x--;
                    SwapTiles(UpMove);
                }

            }
            else if (d == Moves.DownArrow)
            {
                Position DownMove = Empty;
                if (DownMove.x >= 0 && (DownMove.x < Dimension - 1))
                {
                    DownMove.x++;
                    SwapTiles(DownMove);
                }
            }
            else
                return;

        }

        private void Scramble()
        {
            Random rng = new Random();


            for (int i = 0; i < 100000; i++)
            {
                Moves move = (Moves)rng.Next(1, 5);
                Move(move);
            }
        }

        public bool IsSolved()
        {
            Tile[,] solvedBoard = new Tile[Dimension, Dimension];
            FillBoard(solvedBoard);

            for(int i = 0; i < Dimension; i++)
                for(int j = 0; j < Dimension; j++)
                {
                    if(solvedBoard[i,j].Data != PuzzleBoard[i,j].Data)
                    {
                        return false;
                    }
                }
            return true;
        }

        public void DrawBoard()
        {
            Console.Clear();
            String empty = "";

            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    if (PuzzleBoard[i, j].Data != 0)
                    {
                        Console.Write(String.Format("{0}\t", PuzzleBoard[i, j].Data));
                    }
                    else
                        Console.Write("{0}\t", empty);
                }
                Console.WriteLine();
            }
        }

        private void SwapTiles(Position newPosition)
        {
            var tempTile = PuzzleBoard[newPosition.x, newPosition.y];
            PuzzleBoard[newPosition.x, newPosition.y] = PuzzleBoard[Empty.x, Empty.y];
            PuzzleBoard[Empty.x, Empty.y] = tempTile;
            Empty = newPosition;        // Uppdaterar tomma tilens position.
        }

    }

}
