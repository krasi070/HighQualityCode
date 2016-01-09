using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Minesweeper
{
    public class Minesweeper
    {
        

        private static void Main(string[] args)
        {
            string command = string.Empty;
            char[,] board = CreatePlayingField();
            char[,] bombs = PlaceBombs();
            int pointsCounter = 0;
            bool hasExploded = false;
            List<LeaderBoardRanking> leaderBoardRankings = new List<LeaderBoardRanking>(6);
            int row = 0;
            int column = 0;
            bool makeNewBoard = true;
            const int max = 35;
            bool hasWon = false;

            do
            {
                if (makeNewBoard)
                {
                    Console.WriteLine(
                        "Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki."
                        + " Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
                    PrintBoard(board);
                    makeNewBoard = false;
                }

                Console.Write("Daj red i kolona : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) && int.TryParse(command[2].ToString(), out column)
                        && row <= board.GetLength(0) && column <= board.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        PrintLeaderBoardRankings(leaderBoardRankings);
                        break;
                    case "restart":
                        board = CreatePlayingField();
                        bombs = PlaceBombs();
                        PrintBoard(board);
                        hasExploded = false;
                        makeNewBoard = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (bombs[row, column] != '*')
                        {
                            if (bombs[row, column] == '-')
                            {
                                ExecuteTurn(board, bombs, row, column);
                                pointsCounter++;
                            }

                            if (max == pointsCounter)
                            {
                                hasWon = true;
                            }
                            else
                            {
                                PrintBoard(board);
                            }
                        }
                        else
                        {
                            hasExploded = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nGreshka! nevalidna Komanda\n");
                        break;
                }

                
                if (hasExploded)
                {
                    PrintBoard(bombs);
                    Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " + "Daj si niknejm: ", pointsCounter);
                    AddLeaderBoardRanking(leaderBoardRankings, pointsCounter);
                    
                    PrintLeaderBoardRankings(leaderBoardRankings);

                    board = CreatePlayingField();
                    bombs = PlaceBombs();
                    pointsCounter = 0;
                    hasExploded = false;
                    makeNewBoard = true;
                }

                if (hasWon)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    PrintBoard(bombs);
                    Console.WriteLine("Daj si imeto, batka: ");
                    AddLeaderBoardRanking(leaderBoardRankings, pointsCounter);
                    PrintLeaderBoardRankings(leaderBoardRankings);
                    board = CreatePlayingField();
                    bombs = PlaceBombs();
                    pointsCounter = 0;
                    hasWon = false;
                    makeNewBoard = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void AddLeaderBoardRanking(List<LeaderBoardRanking> leaderBoardRankings, int points)
        {
            string name = Console.ReadLine();
            LeaderBoardRanking leaderBoardRanking = new LeaderBoardRanking(name, points);
            if (leaderBoardRankings.Count < 5)
            {
                leaderBoardRankings.Add(leaderBoardRanking);
            }
            else
            {
                for (int i = 0; i < leaderBoardRankings.Count; i++)
                {
                    if (leaderBoardRankings[i].Points < leaderBoardRanking.Points)
                    {
                        leaderBoardRankings.Insert(i, leaderBoardRanking);
                        leaderBoardRankings.RemoveAt(leaderBoardRankings.Count - 1);
                        break;
                    }
                }
            }

            leaderBoardRankings.Sort((LeaderBoardRanking r1, LeaderBoardRanking r2) => r2.Name.CompareTo(r1.Name));
            leaderBoardRankings.Sort((LeaderBoardRanking r1, LeaderBoardRanking r2) => r2.Points.CompareTo(r1.Points));
        }

        private static void PrintLeaderBoardRankings(List<LeaderBoardRanking> leaderBoardRankings)
        {
            Console.WriteLine("\nTo4KI:");
            if (leaderBoardRankings.Count > 0)
            {
                for (int i = 0; i < leaderBoardRankings.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii", i + 1, leaderBoardRankings[i].Name, leaderBoardRankings[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }

        private static void ExecuteTurn(char[,] board, char[,] bombs, int row, int col)
        {
            char numberOfBombsNearCells = GetNumberOfBombsNearCell(bombs, row, col);
            bombs[row, col] = numberOfBombsNearCells;
            board[row, col] = numberOfBombsNearCells;
        }

        private static void PrintBoard(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < cols; j++)
                {
                    Console.Write("{0} ", board[i, j]);
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreatePlayingField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] PlaceBombs()
        {
            int rows = 5;
            int cols = 10;
            char[,] board = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    board[i, j] = '-';
                }
            }

            List<int> bombPositions = new List<int>();
            while (bombPositions.Count < 15)
            {
                Random random = new Random();
                int bombPosition = random.Next(50);
                if (!bombPositions.Contains(bombPosition))
                {
                    bombPositions.Add(bombPosition);
                }
            }

            foreach (int bombPosition in bombPositions)
            {
                int bombColumn = bombPosition / cols;
                int bombRow = bombPosition % cols;
                if (bombRow == 0 && bombPosition != 0)
                {
                    bombColumn--;
                    bombRow = cols;
                }
                else
                {
                    bombRow++;
                }

                board[bombColumn, bombRow - 1] = '*';
            }

            return board;
        }

        private static void CalculateNumberOfBombsNearEachCell(char[,] board)
        {
            int row = board.GetLength(0);
            int col = board.GetLength(1);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (board[i, j] != '*')
                    {
                        char numberOfBombsNearCell = GetNumberOfBombsNearCell(board, i, j);
                        board[i, j] = numberOfBombsNearCell;
                    }
                }
            }
        }

        private static char GetNumberOfBombsNearCell(char[,] field, int col, int row)
        {
            int numberOfBombsNearCell = 0;
            int rows = field.GetLength(0);
            int cols = field.GetLength(1);

            if (col - 1 >= 0)
            {
                if (field[col - 1, row] == '*')
                {
                    numberOfBombsNearCell++;
                }
            }

            if (col + 1 < rows)
            {
                if (field[col + 1, row] == '*')
                {
                    numberOfBombsNearCell++;
                }
            }

            if (row - 1 >= 0)
            {
                if (field[col, row - 1] == '*')
                {
                    numberOfBombsNearCell++;
                }
            }

            if (row + 1 < cols)
            {
                if (field[col, row + 1] == '*')
                {
                    numberOfBombsNearCell++;
                }
            }

            if ((col - 1 >= 0) && (row - 1 >= 0))
            {
                if (field[col - 1, row - 1] == '*')
                {
                    numberOfBombsNearCell++;
                }
            }

            if ((col - 1 >= 0) && (row + 1 < cols))
            {
                if (field[col - 1, row + 1] == '*')
                {
                    numberOfBombsNearCell++;
                }
            }

            if ((col + 1 < rows) && (row - 1 >= 0))
            {
                if (field[col + 1, row - 1] == '*')
                {
                    numberOfBombsNearCell++;
                }
            }

            if ((col + 1 < rows) && (row + 1 < cols))
            {
                if (field[col + 1, row + 1] == '*')
                {
                    numberOfBombsNearCell++;
                }
            }

            return char.Parse(numberOfBombsNearCell.ToString());
        }
    }
}