using CodingTracker.Controllers;

namespace CodingTracker.Models;

public class CodingSession(string id, string start, string end)
{
    public string Id { get; set; } = id;
    public string StartTime { get; set; } = start;
    public string EndTime { get; set; } = end;

    public string Duration => CalculateDuration();

    private string CalculateDuration()
    {
        var start = HelpersValidation.ConvertToTime(StartTime);
        var end = HelpersValidation.ConvertToTime(EndTime);
        var duration = end - start;

        return $"{duration.Hours.ToString().PadLeft(2, '0')}:{duration.Minutes.ToString().PadLeft(2, '0')}";
    }
}