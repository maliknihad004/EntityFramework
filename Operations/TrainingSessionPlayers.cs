
using Microsoft.EntityFrameworkCore;

public class ParticipationService
{
    public async Task AssignPlayer(int playerId, int sessionId)
    {
        using var context = new FootballDbContext();

        Player? player = await context.Players.FindAsync(playerId);
        TrainingSession? session = await context.TrainingSessions.FindAsync(sessionId);

        if (player == null || session == null)
        {
            Console.WriteLine("Player or Session not found");
            return;
        }

        bool exists = await context.TrainingSessionPlayers
            .AnyAsync(sp => sp.PlayerId == playerId &&
                            sp.TrainingSessionId == sessionId);

        if (exists)
        {
            Console.WriteLine("Player already assigned");
            return;
        }

        TrainingSessionPlayers participation = new TrainingSessionPlayers
        {
            PlayerId = playerId,
            TrainingSessionId = sessionId
        };

        context.TrainingSessionPlayers.Add(participation);
        await context.SaveChangesAsync();

        Console.WriteLine("Player assigned successfully");
    }


    public async Task RemovePlayer(int playerId, int sessionId)
    {
        using var context = new FootballDbContext();

        var participation = await context.TrainingSessionPlayers
            .FirstOrDefaultAsync(sp => sp.PlayerId == playerId &&
                                       sp.TrainingSessionId == sessionId);

        if (participation != null)
        {
            context.TrainingSessionPlayers.Remove(participation);
            await context.SaveChangesAsync();

            Console.WriteLine("Player removed");
        }
        else
        {
            Console.WriteLine("Participation not found");
        }
    }


    public async Task DisplayPlayers(int sessionId)
    {
        using var context = new FootballDbContext();

        var session = await context.TrainingSessions.FindAsync(sessionId);

        if (session == null)
        {
            Console.WriteLine("Session not found");
            return;
        }

        var participants = await context.TrainingSessionPlayers
            .Where(sp => sp.TrainingSessionId == sessionId)
            .Include(sp => sp.Player)
            .ToListAsync();

        foreach (var p in participants)
        {
            Console.WriteLine($"{p.Player.Id} - {p.Player.Name}");
        }
    }


    public async Task DisplaySessions(int playerId)
    {
        using var context = new FootballDbContext();

        var player = await context.Players.FindAsync(playerId);

        if (player == null)
        {
            Console.WriteLine("Player not found");
            return;
        }

        var sessions = await context.TrainingSessionPlayers
            .Where(sp => sp.PlayerId == playerId)
            .Include(sp => sp.TrainingSession)
            .ToListAsync();

        foreach (var s in sessions)
        {
            Console.WriteLine($"{s.TrainingSession.Id} - {s.TrainingSession.Title}");
        }
    }
}
