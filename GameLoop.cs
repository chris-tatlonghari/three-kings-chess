using System;
using System.IO;
using ThreeKings.Engines;
using ThreeKings.Library;
using static ThreeKings.Utilities.MoveUtility;

namespace ThreeKings
{
    public class GameLoop
    {
        private static Board _board = new Board();

        public static void Start()
        {
            byte[] inputBuffer = new byte[1024];
            Stream inputStream = Console.OpenStandardInput(inputBuffer.Length);
            Console.SetIn(new StreamReader(inputStream, Console.InputEncoding, false, inputBuffer.Length));

            while (true)
            {
                string[] tokens = Console.ReadLine().Trim().Split();
                switch (tokens[0])
                {
                    case "uci":
                        Console.WriteLine("uciok");
                        break;
                    case "isready":
                        Console.WriteLine("readyok");
                        break;
                    case "position":
                        UciPosition(tokens);
                        Print(_board);
                        break;
                    case "go":
                        UciGo(tokens);
                        break;
                    default:
                        break;
                }
            }
        }

        #region UCI Functions

        private static void UciPosition(string[] tokens)
        {
            int firstMove = Array.IndexOf(tokens, "moves") + 1;
            if (firstMove == 0)
            {
                return;
            }

            _board.SetupBoard();

            for (int i = firstMove; i < tokens.Length; i++)
            {
                Move move = new Move(tokens[i]);
                move.Adjust();
                _board.Play(move);
            }
        }

        private static void UciGo(string[] tokens)
        {
            // Call Engine to make move.
            Randy.Move(_board);
        }

        #endregion

        #region Command Line Game Functions



        #endregion

        #region Helper Functions

        private static void Print(Board board)
        {
            Console.WriteLine("  A B C D E F G H");
            Console.WriteLine("  ---------------");
            for (int rank = 7; rank >= 0; rank--)
            {
                Console.Write($"{rank + 1}|");
                for (int file = 0; file < 8; file++)
                {
                    Piece piece = board[rank, file];
                    Print(piece);
                    //Console.Write((rank * 8 + file) + " ");
                }
                Console.WriteLine();
            }
        }

        private static void Print(Piece piece)
        {
            Console.Write(Notation.ToChar(piece._type));
            Console.Write(' ');
        }

        #endregion

    }
}








