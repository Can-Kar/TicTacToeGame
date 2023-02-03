namespace TicTacToeGame
{
    internal class Program
    {
        class GameManager
        {
            public int coordinatedPickedCounter = 0;
            public char markX = 'X';
            public char markO = 'O';
            public char[,] coordinates = new char[3, 3];
            public bool[,] coordinatesToPick= new bool[3, 3] 
            {
                {true,true,true },
                {true,true,true },
                {true,true,true}
            };

            //Adds mark to the specified location
            public void addMark(char mark, int coordinateY, int coordinateX)
            {
                if (this.coordinatesToPick[coordinateY, coordinateX] == true)
                {
                    this.coordinates[coordinateY, coordinateX] = mark;
                    excludeCoordinate(coordinateY, coordinateX);
                }
                else
                {
                    Console.WriteLine("Given coordinate already has marked!");
                }

                this.coordinatedPickedCounter++;
            }

            //Returns the mark at specified location
            public char GetMark(int coordinateY, int coordinateX)
            {
                return this.coordinates[coordinateY, coordinateX];
            }

            //Sets marked coordinate to false to prevent remarking it
            public void excludeCoordinate(int coordinateY, int coordinateX)
            {
                this.coordinatesToPick[coordinateY, coordinateX] = false;
            }
        }

        static void Main(string[] args)
        {
            bool isGameOver = false;
            GameManager gameManager = new GameManager();
            Random random = new Random();

            while (!isGameOver)
            {
                getGameScreen(gameManager);
                if (isGameOver == false)
                {
                    PlayTurn(gameManager, random);
                }
                isGameOver = isGameOverFunc(gameManager);
                if (isGameOver == false)
                {
                    //Computer places mark O
                    ComputerMark(gameManager, random);
                    isGameOver = isGameOverFunc(gameManager);
                }
                getGameScreen(gameManager);
                if (isGameOver == false)
                {
                    Console.Clear();
                }
            }
        }

        private static void PlayTurn(GameManager gameManager, Random random)
        {
            //Player places mark X
            Console.WriteLine("Player mark is X, Computer mark is O. Please enter X coordinate to place your mark: ");
            int xCoordinate = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Player mark is X, Computer mark is O. Please enter Y coordinate to place your mark: ");
            int yCoordinate = Convert.ToInt32(Console.ReadLine());

            gameManager.addMark(gameManager.markX, xCoordinate, yCoordinate);
            
        }

        //Displays game screen
        private static void getGameScreen(GameManager gameManager)
        {
            string markLine = $"{gameManager.GetMark(0, 0)}\t|\t{gameManager.GetMark(0, 1)}\t|\t    {gameManager.GetMark(0, 2)}";

            string markLine1 = $"{gameManager.GetMark(1, 0)}\t|\t{gameManager.GetMark(1, 1)}\t|\t{gameManager.GetMark(1, 2)}";

            string markLine2 = $"{gameManager.GetMark(2, 0)}\t|\t{gameManager.GetMark(2, 1)} \t|\t{gameManager.GetMark(2, 2)}";

            string seperateLine = new string('-', 40);

            Console.Write(markLine + "\n" + seperateLine + "\n" + markLine1 + "\n" + seperateLine + "\n" + markLine2 + "\n");
        }

        //Finds a random suitable coordinate to mark O
        static void ComputerMark(GameManager gameManager, Random random)
        {
            bool isSelectionCorrect = false;

            while (isSelectionCorrect == false)
            {
                int xCoordinate = random.Next(0, 3);
                int yCoordinate = random.Next(0, 3);

                if (gameManager.coordinatesToPick[yCoordinate,xCoordinate] == true)
                {
                    gameManager.addMark(gameManager.markO, yCoordinate,xCoordinate);
                    isSelectionCorrect= true;
                }
            }            
        }


        static bool isGameOverFunc(GameManager gameManager)
        {
            //No spaces left to mark condition
            if (gameManager.coordinatedPickedCounter == 8)
            {
                Console.WriteLine("\nWe have a Winner!");
                return true;
            }

            //Horizontal Win Conditions
            for (int i = 0; i < 3; i++)
            {                
                if ((gameManager.coordinates[i,0] == gameManager.coordinates[i, 1] && gameManager.coordinates[i, 1] == gameManager.coordinates[i, 2]) &&(gameManager.coordinatesToPick[i, 0] != true && gameManager.coordinatesToPick[i, 1] != true && gameManager.coordinatesToPick[i, 2] != true))
                {
                    Console.WriteLine("\nWe have a Winner!");
                    return true;
                }
                
            }

            //Vertical Win Conditions
            for (int j = 0; j < 3; j++)
            {
                if ((gameManager.coordinates[0, j] == gameManager.coordinates[1, j] && gameManager.coordinates[1, j] == gameManager.coordinates[2, j]) && (gameManager.coordinatesToPick[0, j] != true && gameManager.coordinatesToPick[1, j] != true && gameManager.coordinatesToPick[2, j] != true))
                {
                    Console.WriteLine("\nWe have a Winner!");
                    return true;
                }
            }

            //Diagonal Win Conditions
            if ((gameManager.coordinates[0,0] == gameManager.coordinates[1, 1] && gameManager.coordinates[1, 1] == gameManager.coordinates[2, 2]) && (gameManager.coordinatesToPick[0,0] != true && gameManager.coordinatesToPick[1, 1] != true && gameManager.coordinatesToPick[2, 2] != true))
            {
                Console.WriteLine("\nWe have a Winner!");
                return true;
            }
            if ((gameManager.coordinates[0, 2] == gameManager.coordinates[1, 1] && gameManager.coordinates[1, 1] == gameManager.coordinates[2, 0])&& (gameManager.coordinatesToPick[0, 2] != true && gameManager.coordinatesToPick[1, 1] != true && gameManager.coordinatesToPick[2, 0] != true))
            {
                Console.WriteLine("\nWe have a Winner!");
                return true;
            }

            return false;
        }
    }
}