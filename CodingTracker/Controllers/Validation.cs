using System.Globalization;
using System.Runtime.InteropServices.JavaScript;
using CodingTracker.Controllers;
using Spectre.Console;

namespace CodingTracker;

public class Validation
{
    internal class InputZero : Exception
    {
    }

    internal static string DateInputValidation(string input, string message)
    {
        while (!DateTime.TryParseExact(input, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
        {
            AnsiConsole.Markup($"[bold red]Invalid date input format.[/]\n");
            input = UserInput.GetDateInput();
        }

        return input;
    }
}