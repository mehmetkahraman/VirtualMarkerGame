using System.Diagnostics.Metrics;
using System.Reflection;
using System.Threading;

namespace MarkerGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteSlowly("Hi!");
            Thread.Sleep(200);
            WriteSlowly("Welcome to this exciting marker game!" + Environment.NewLine);
            Thread.Sleep(400);
            WriteSlowly("Please navigate the cursor in grid pattern using arrow keys." + Environment.NewLine);
            Thread.Sleep(400);
            WriteSlowly("Press 'E' to exit and display the move history." + Environment.NewLine);
            Thread.Sleep(400);
            WriteSlowly("If everything seems ok, let's begin!" + Environment.NewLine);
            Thread.Sleep(400);
            WriteSlowly("Now, please define the grid size for X axis and press Enter: " + Environment.NewLine);

        XGridLoop:
            string numberOfGridXAxisAsString = Console.ReadLine().ToString(); // Define the grid size in X dimension
            int numberOfGridXAxis = CkeckIfNumber(numberOfGridXAxisAsString);
            if (numberOfGridXAxis == 0) goto XGridLoop;
            Thread.Sleep(200);
            WriteSlowly("Now, please define the grid size for Y axis and press Enter: " + Environment.NewLine);

        YGridLoop:
            string numberOfGridYAxisAsString = Console.ReadLine().ToString(); // Define the grid size in X dimension
            int numberOfGridYAxis = CkeckIfNumber(numberOfGridYAxisAsString);
            if (numberOfGridYAxis == 0) goto YGridLoop;

            WriteSlowly("Thank you! ");
            Thread.Sleep(300);
            WriteSlowly("Now you can start to move your virtual marker with arrow keys after pressing Enter button.");
            
            int XAxis = 0;   // Initial marker position in X dimension
            int YAxis = 0;   // Initial marker position in Y dimension
            List<string> history = new List<string>();

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                string move = "";

                switch (keyInfo.Key)
                {
                    case ConsoleKey.RightArrow:
                        if (XAxis < numberOfGridXAxis - 1)
                        {
                            XAxis++;
                            move = $"Moved right. The current position is at: X: {XAxis} , Y: {YAxis}";
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        if (XAxis > 0)
                        {
                            XAxis--;
                            move = $"Moved left. The current position is at: X: {XAxis} , Y: {YAxis}";
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        if (YAxis > 0)
                        {
                            YAxis--;
                            move = $"Moved up. The current position is at: X: {XAxis} , Y: {YAxis}";
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (YAxis < numberOfGridYAxis - 1)
                        {
                            YAxis++;
                            move = $"Moved down. The current position is at: X: {XAxis} , Y: {YAxis}";
                        }
                        break;

                    case ConsoleKey.E:
                        Console.WriteLine("\nMove History:");
                        foreach (var historyMove in history)
                        {
                            Console.WriteLine(historyMove);
                        }
                        return;
                }

                Console.Clear();
                Console.WriteLine($"Current Position: X = {XAxis}, Y = {YAxis}");
                history.Add(move);
            }
        }


        public static void WriteSlowly(string text)
        {
            foreach (var letter in text)
            {
                Console.Write(letter);
                Thread.Sleep(50);
            }
        }

        public static int CkeckIfNumber(string userInput)
        {
            if (userInput.Count() > 0 && int.TryParse(userInput, out int Yvalue))
            {
                return Convert.ToInt16(userInput); // Define the grid size in Y dimension
            }
            else
            {
                WriteSlowly("Please write a number such as: 10" + Environment.NewLine);
                return 0;
            }
        }
    }
}
