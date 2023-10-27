using System.Drawing;

public class MasterMind
{
    public static void Main()
    {
        Random random = new Random();
        List<string> colorCode = new List<string>();
        List<string> colorList = new List<string> { "Red", "Yellow", "Green", "Blue", "Purple", "Orange" };
        bool success = false; // Initialize the success flag to false

        for (int i = 0; i < 4; i++)
        {
            // Generate a random index
            int randomIndex = random.Next(0, colorList.Count);

            // Get the color at the random index and add it to the selectedColors array
            colorCode.Add(colorList[randomIndex]);

            // Remove the selected color from the original list to avoid duplicates
            colorList.RemoveAt(randomIndex);
        }

        // Console.WriteLine("Game Code: " + colorCode[0] + " " + colorCode[1] + " " + colorCode[2] + " " + colorCode[3]); // Print the generated color code for debugging purpose

        void WriteEmpty()
        {
            Console.WriteLine(" ");
        }

        void compareColorCodes(List<string> playerCode)
        {
            // Check if the lists have the same length.
            if (playerCode.Count != colorCode.Count)
            {
                WriteEmpty();
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Given code does't match expected syntax!");
                Console.WriteLine("Please try again.");
                Console.WriteLine("----------------------------------------");
                WriteEmpty();
                return;
            }

            if (playerCode.SequenceEqual(colorCode))
            {
                success = true; // Set success flag to true if lists match
                return;
            }

            WriteEmpty();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Enter a color code.");
            WriteEmpty();
            Console.WriteLine("Black Pin = Color and position matches");
            Console.WriteLine("White Pin = Only color matches");
            Console.WriteLine("----------------------------------------");
            WriteEmpty();

            // Compare elements at each index.
            for (int i = 0; i < colorCode.Count; i++)
            {
                if (colorCode.Contains(playerCode[i]))
                {
                    if (colorCode[i] != playerCode[i])
                    {
                        Console.WriteLine((i + 1) + ". White Pin");
                        continue;
                    }

                    Console.WriteLine((i + 1) + ". Black Pin");
                    continue;
                }

                Console.WriteLine((i + 1) + ". ----------");
            }

            WriteEmpty();
        }

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Welcome to Mastermind!");
        Console.WriteLine("Please enter a code of colors to begin.");
        WriteEmpty();
        Console.WriteLine("Syntax Example: Red Green Yellow Blue");
        Console.WriteLine("----------------------------------------");
        WriteEmpty();

        while (!success) // Continue looping until success flag is true
        {
            String inputColor = Console.ReadLine();

            if (inputColor == null)
            {
                return;
            }

            // Split the input string by whitespace into an array of strings
            string[] colors = inputColor.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            compareColorCodes(colors.ToList());
        }

        WriteEmpty();
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Eureka!");
        Console.WriteLine("You have entered the correct code.");
        Console.WriteLine("----------------------------------------");
        Console.ReadLine();
    }
}