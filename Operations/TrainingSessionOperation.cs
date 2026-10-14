using Microsoft.EntityFrameworkCore;
using System.Globalization;

public class TrainingSessionService
{
    public async Task AddSession()
    {
        using var context = new FootballDbContext();

        Console.Write("Enter Session Title: ");
        string? title = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine("Invalid session title");
            return;
        }

        title = title.Trim();

        Console.Write("Enter Session Date (yyyy-MM-dd HH:mm UTC): ");
        if (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm",
            CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
        {
            Console.WriteLine("Invalid session date");
            return;
        }

        date = DateTime.SpecifyKind(date, DateTimeKind.Utc);

        Console.Write("Enter Coach ID: ");
        if (!int.TryParse(Console.ReadLine(), out int coachId) || coachId <= 0)
        {
            Console.WriteLine("Invalid coach ID");
            return;
        }

        var coach = await context.Coaches.FindAsync(coachId);

        bool titleExists = await context.TrainingSessions
            .AnyAsync(s => s.Title == title);

        if (coach != null && !titleExists)
        {
            TrainingSession session = new TrainingSession
            {
                Title = title,
                Date = date,
                CoachId = coachId
            };

            context.TrainingSessions.Add(session);

            await context.SaveChangesAsync();
            Console.WriteLine($"Session {session.Title} added successfully! ID: {session.Id}");
        }
        else if (titleExists)
        {
            Console.WriteLine("Training session title already exists");
        }
        else
        {
            Console.WriteLine("Coach not found");
        }
    }

    public async Task DisplaySessions()
    {
        using var context = new FootballDbContext();

        var sessions = await context.TrainingSessions.ToListAsync();

        foreach (var session in sessions)
        {
            Console.WriteLine($"{session.Id} - {session.Title} - {session.Date} - {session.CoachId}");
        }
    }

    public async Task FindSession(int sessionId)
    {
        using var context = new FootballDbContext();

        TrainingSession? foundSession = await context.TrainingSessions.FindAsync(sessionId);

        if (foundSession != null)
        {
            Console.WriteLine(foundSession.Title);
        }
        else
        {
            Console.WriteLine("Session not found");
        }
    }

    public async Task UpdateSession(int sessionId)
    {
        using var context = new FootballDbContext();

        TrainingSession? updatedSession = await context.TrainingSessions.FindAsync(sessionId);

        if (updatedSession == null)
        {
            Console.WriteLine("Session not found");
            return;
        }

        Console.Write("Enter New Session Title: ");
        string? newTitle = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(newTitle))
        {
            Console.WriteLine("Invalid session title");
            return;
        }

        newTitle = newTitle.Trim();

        Console.Write("Enter New Session Date (yyyy-MM-dd HH:mm UTC): ");
        if (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm",
            CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime newDate))
        {
            Console.WriteLine("Invalid session date");
            return;
        }

        newDate = DateTime.SpecifyKind(newDate, DateTimeKind.Utc);

        Console.Write("Enter New Coach ID: ");
        if (!int.TryParse(Console.ReadLine(), out int newCoachId) || newCoachId <= 0)
        {
            Console.WriteLine("Invalid coach ID");
            return;
        }

        bool duplicateTitle = await context.TrainingSessions
            .AnyAsync(s => s.Title == newTitle && s.Id != sessionId);

        var newCoach = await context.Coaches.FindAsync(newCoachId);

        if (newCoach != null && !duplicateTitle)
        {
            updatedSession.Title = newTitle;
            updatedSession.Date = newDate;
            updatedSession.CoachId = newCoachId;

            await context.SaveChangesAsync();
            Console.WriteLine("Session updated successfully");
        }
        else if (duplicateTitle)
        {
            Console.WriteLine("Training session title already exists");
        }
        else
        {
            Console.WriteLine("Coach not found");
        }
    }

    public async Task DeleteSession(int sessionId)
    {
        using var context = new FootballDbContext();

        TrainingSession? deletedSession = await context.TrainingSessions.FindAsync(sessionId);

        if (deletedSession != null)
        {
            context.TrainingSessions.Remove(deletedSession);
            await context.SaveChangesAsync();

            Console.WriteLine("Session deleted successfully");
        }
        else
        {
            Console.WriteLine("Session not found");
        }
    }
}
