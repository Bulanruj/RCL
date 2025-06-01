using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Password Strength Validator ===");
        Console.WriteLine("Type 'exit' to quit the program.\n");

        while (true)
        {
            // Ask user for input
            Console.Write("Enter a password to validate: ");
            string userPassword = Console.ReadLine();

            // Check for exit command
            if (userPassword.ToLower() == "exit")
            {
                Console.WriteLine("Exiting the program. Goodbye!");
                break; // Exit the loop
            }

            // Validate password and display result
            string result = ValidatePassword(userPassword);
            Console.WriteLine($"Password Strength: {result}\n");
        }
    }

    // Method to validate the strength of the password
    static string ValidatePassword(string password)
    {
        int criteriaMet = 0;

        // Check 1: At least 8 characters
        if (password.Length >= 8)
        {
            criteriaMet++;
        }

        // Check 2: At least one uppercase letter
        if (Regex.IsMatch(password, "[A-Z]"))
        {
            criteriaMet++;
        }

        // Check 3: At least one lowercase letter
        if (Regex.IsMatch(password, "[a-z]"))
        {
            criteriaMet++;
        }

        // Check 4: At least one digit
        if (Regex.IsMatch(password, "[0-9]"))
        {
            criteriaMet++;
        }

        // Check 5: At least one special character
        if (Regex.IsMatch(password, "[^a-zA-Z0-9]"))
        {
            criteriaMet++;
        }

        // Evaluate strength
        if (criteriaMet == 5)
        {
            return "Strong";
        }
        else if (criteriaMet >= 3)
        {
            return "Moderate";
        }
        else
        {
            return "Weak";
        }
    }
}
