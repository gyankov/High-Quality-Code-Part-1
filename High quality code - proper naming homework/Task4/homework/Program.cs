namespace Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Mines
    {
        public static void Main(string[] args)
        {
            const int MAX = 35;
            string command = string.Empty;
            char[,] field = CreateGameField();
            char[,] mines = PlaceBombs();
            int counter = 0;
            bool explode = false;
            List<Score> champions = new List<Score>(6);
            int row = 0;
            int col = 0;
            bool firstFlag = true;
            bool secondFlag = false;

            do
            {
                if (firstFlag)
                {
                    Console.WriteLine("Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki." +
                    " command 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
                    DrawBoard(field);
                    firstFlag = false;
                }

                Console.Write("Daj red i kolona : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out col) &&
                        row <= field.GetLength(0) && col <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        Ranking(champions);
                        break;
                    case "restart":
                        field = CreateGameField();
                        mines = PlaceBombs();
                        DrawBoard(field);
                        explode = false;
                        firstFlag = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (mines[row, col] != '*')
                        {
                            if (mines[row, col] == '-')
                            {
                                MakeMove(field, mines, row, col);
                                counter++;
                            }

                            if (MAX == counter)
                            {
                                secondFlag = true;
                            }
                            else
                            {
                                DrawBoard(field);
                            }
                        }
                        else
                        {
                            explode = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nGreshka! nevalidna command\n");
                        break;
                }

                if (explode)
                {
                    DrawBoard(mines);
                    Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. Daj si niknejm: ", counter);
                    string nickName = Console.ReadLine();
                    Score bestScore = new Score(nickName, counter);
                    if (champions.Count < 5)
                    {
                        champions.Add(bestScore);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].Points < bestScore.Points)
                            {
                                champions.Insert(i, bestScore);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }

                    champions.Sort((Score r1, Score r2) => r2.Name.CompareTo(r1.Name));
                    champions.Sort((Score r1, Score r2) => r2.Points.CompareTo(r1.Points));
                    Ranking(champions);

                    field = CreateGameField();
                    mines = PlaceBombs();
                    counter = 0;
                    explode = false;
                    firstFlag = true;
                }

                if (secondFlag)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    DrawBoard(mines);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string name = Console.ReadLine();
                    Score score = new Score(name, counter);
                    champions.Add(score);
                    Ranking(champions);
                    field = CreateGameField();
                    mines = PlaceBombs();
                    counter = 0;
                    secondFlag = false;
                    firstFlag = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void Ranking(List<Score> points)
        {
            Console.WriteLine("\nTo4KI:");
            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine(
                        "{0}. {1} --> {2} kutii",
                        i + 1,
                        points[i].Name,
                        points[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }

        private static void MakeMove(
            char[,] field,
            char[,] mines, 
            int row, 
            int col)
        {
            char minesCount = MinesCounter(mines, row, col);
            mines[row, col] = minesCount;
            field[row, col] = minesCount;
        }

        private static void DrawBoard(char[,] board)
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
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateGameField()
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
            char[,] gameField = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    gameField[i, j] = '-';
                }
            }

            List<int> randomNumbers = new List<int>();
            while (randomNumbers.Count < 15)
            {
                Random random = new Random();
                int nextRandomNumber = random.Next(50);
                if (!randomNumbers.Contains(nextRandomNumber))
                {
                    randomNumbers.Add(nextRandomNumber);
                }
            }

            foreach (int i2 in randomNumbers)
            {
                int col = i2 / cols;
                int row = i2 % cols;
                if (row == 0 && i2 != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }

                gameField[col, row - 1] = '*';
            }

            return gameField;
        }

        private static void CalculatePonts(char[,] gameField)
        {
            int col = gameField.GetLength(0);
            int row = gameField.GetLength(1);

            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (gameField[i, j] != '*')
                    {
                        char minesCount = MinesCounter(gameField, i, j);
                        gameField[i, j] = minesCount;
                    }
                }
            }
        }

        private static char MinesCounter(char[,] field, int row, int col)
        {
            int count = 0;
            int rows = field.GetLength(0);
            int cols = field.GetLength(1);

            if (row - 1 >= 0)
            {
                if (field[row - 1, col] == '*')
                {
                    count++;
                }
            }

            if (row + 1 < rows)
            {
                if (field[row + 1, col] == '*')
                {
                    count++;
                }
            }

            if (col - 1 >= 0)
            {
                if (field[row, col - 1] == '*')
                {
                    count++;
                }
            }

            if (col + 1 < cols)
            {
                if (field[row, col + 1] == '*')
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (field[row - 1, col - 1] == '*')
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (field[row - 1, col + 1] == '*')
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (field[row + 1, col - 1] == '*')
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (field[row + 1, col + 1] == '*')
                {
                    count++;
                }
            }

            return char.Parse(count.ToString());
        }
    }
}
