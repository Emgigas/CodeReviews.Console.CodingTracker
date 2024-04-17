using System.Globalization;
using CodingTracker.Models;
using Spectre.Console;

namespace CodingTracker.Controllers;

public class HelpersValidation
{
    
    internal static DateTime ConvertToTime(string datetimeString)
    {
        return DateTime.ParseExact(datetimeString, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
    }
    internal class InputZero : Exception
    {
    }

    internal static string DateInputValidation(string input, string message, string dateInput)
    {
        while (!DateTime.TryParseExact(input, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
        {
            AnsiConsole.Markup($"[bold red]Invalid date format.[/]\n");
            input = UserInput.GetDateInput(dateInput);
        }

        return input;
    }

    internal static string TimeInputValidation(string input, string message, string timeInput)
    {
        while (!DateTime.TryParseExact(input, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
        {
            AnsiConsole.Markup($"[bold red]Invalid date format.[/]\n");
            input = UserInput.GetTimeInput(timeInput);
        }

        return input;
    }

    internal static string GetDateTimeInput(string startOrEnd)
    {
        return $"{UserInput.GetDateInput(startOrEnd)} {UserInput.GetTimeInput(startOrEnd)}";
    }

    internal static CodingSession GetSessionData()
    {
        string startDateTime = "";
        string endDateTime = "";
        try
        {
            startDateTime = GetDateTimeInput("start");
            endDateTime = GetDateTimeInput("end");
                
            while (ConvertToTime(endDateTime) < ConvertToTime(startDateTime))
            {
                AnsiConsole.Markup($"[bold red] {endDateTime} is before {startDateTime}. Please provide a correct end date & time.[/]\n\n");
                endDateTime = GetDateTimeInput("end");
            }
            
        }
        catch (InputZero)
        {
            AnsiConsole.MarkupLine("[bold]Returning to main menu...[/]");
        }

        return new CodingSession("", startDateTime, endDateTime);
    }
    
}