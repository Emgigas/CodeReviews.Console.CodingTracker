using CodingTracker.Models;
using Dapper;
using Spectre.Console;

namespace CodingTracker.Controllers;

public class CrudManager
{
    public static void InsertSqlRecord()
    {
        using (var connection = DbBuilder.GetConnection())
        {
            connection.Open();
            CodingSession session = HelpersValidation.GetSessionData();
            var sql =
                $"INSERT INTO coding_tracker (startTime, endTime, duration)" +
                $"VALUES ('{session.StartTime}', '{session.EndTime}', '{session.Duration}')";

            var rowsAffected = connection.Execute(sql);
            AnsiConsole.Markup($"[bold underline]{rowsAffected}[/] row(s) inserted.");
        }
    }
}