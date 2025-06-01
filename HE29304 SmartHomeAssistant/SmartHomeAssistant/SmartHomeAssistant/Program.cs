using System;  // Import basic system functions

class SmartHomeAssistant
{
    // Entry point of the application
    static void Main()
    {
        // Draw the main ASCII-art menu centered at the top
        DrawCenteredMenu();

        // Infinite loop to continuously accept user commands
        while (true)
        {
            // Determine row index two lines from the bottom
            int promptRow = Console.WindowHeight - 2;

            // Move cursor to that row, clear it, and ask for input
            Console.SetCursorPosition(0, promptRow);
            Console.Write(new string(' ', Console.WindowWidth));  // Clear the entire line
            Console.SetCursorPosition(0, promptRow);
            Console.Write("Enter choice (number or command): ");

            // Read user input, convert to lowercase, and trim spaces
            string input = Console.ReadLine().ToLower().Trim();

            // Handle both numeric and text versions of commands
            switch (input)
            {
                case "1":
                case "turn on lights":
                    WriteFeedback("Lights are now ON.");
                    break;

                case "2":
                case "turn off lights":
                    WriteFeedback("Lights are now OFF.");
                    break;

                case "3":
                case "set temperature":
                    // Move to new line to prompt for numeric temperature
                    Console.Write("\nEnter desired temperature: ");
                    string tempInput = Console.ReadLine().Trim();  // Read and trim
                    // Try to parse the temperature
                    if (int.TryParse(tempInput, out int temp))
                        WriteFeedback($"Temperature set to {temp}°.");
                    else
                        WriteFeedback("Invalid number—please enter a valid temperature.");
                    break;

                case "4":
                case "play music":
                    WriteFeedback("Playing your favourite music.");
                    break;

                case "5":
                case "stop music":
                    WriteFeedback("Music stopped.");
                    break;

                case "6":
                case "exit":
                    WriteFeedback("Goodbye!");
                    return;  // Exit the loop and end program

                default:
                    // Handle any unrecognized input
                    WriteFeedback("Invalid selection. Please try again.");
                    break;
            }
        }
    }

    // Draws a fixed ASCII-art box menu, centered horizontally
    static void DrawCenteredMenu()
    {
        string[] lines = {
            "╔════════════════════════════════════════╗",
            "║          Smart Home Assistant          ║",
            "╠════════════════════════════════════════╣",
            "║ 1 – Turn on lights                     ║",
            "║ 2 – Turn off lights                    ║",
            "║ 3 – Set temperature                    ║",
            "║ 4 – Play music                         ║",
            "║ 5 – Stop music                         ║",
            "║ 6 – Exit                               ║",
            "╚════════════════════════════════════════╝"
        };

        int top = 2;  // Start drawing two lines down from the top
        foreach (var line in lines)
        {
            // Calculate left padding to center each line
            int pad = Math.Max((Console.WindowWidth - line.Length) / 2, 0);
            Console.SetCursorPosition(pad, top++);  // Move cursor then increment row
            Console.WriteLine(line);                // Print the menu line
        }
    }

    // Writes a single-line feedback message two lines above the prompt
    static void WriteFeedback(string message)
    {
        int feedbackRow = Console.WindowHeight - 4;  // Row for feedback
        Console.SetCursorPosition(0, feedbackRow);
        Console.Write(new string(' ', Console.WindowWidth));  // Clear old feedback
        Console.SetCursorPosition(0, feedbackRow);
        Console.WriteLine(message);  // Display new feedback
    }
}
