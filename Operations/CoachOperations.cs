using Microsoft.EntityFrameworkCore;

public class PlayerService
{
    public async Task AddPlayer()
    {
        using var context = new FootballDbContext();

        Console.Write("Enter Player Name: ");
        string? name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Invalid player name");
            return;
        }

        Console.Write("Enter Player Age: ");
        if (!int.TryParse(Console.ReadLine(), out int age) || age <= 0)
        {
            Console.WriteLine("Invalid player age");
            return;
        }

        Player player = new Player
        {
            Name = name.Trim(),
            Age = age
        };

        context.Players.Add(player);
        await context.SaveChangesAsync();

        Console.WriteLine($"Player {player.Name} added successfully! ID: {player.Id}");
    }

    public async Task DisplayPlayers()
    {
        using var context = new FootballDbContext();

        var players = await context.Players.ToListAsync();

        foreach (var p in players)
        {
            Console.WriteLine($"{p.Id} - {p.Name} - {p.Age}");
        }
    }

    public async Task FindPlayer(int playerId)
    {
        using var context = new FootballDbContext();

        Player? foundPlayer = await context.Players.FindAsync(playerId);

        if (foundPlayer != null)
        {
            Console.WriteLine($"{foundPlayer.Id} - {foundPlayer.Name} - {foundPlayer.Age}");
        }
        else
        {
            Console.WriteLine("Player not found");
        }
    }

    public async Task UpdatePlayer(int playerId)
    {
        using var context = new FootballDbContext();

        Player? updatedPlayer = await context.Players.FindAsync(playerId);

        if (updatedPlayer != null)
        {
            Console.Write("Enter New Player Name: ");
            string? name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Invalid player name");
                return;
            }

            Console.Write("Enter New Player Age: ");
            if (!int.TryParse(Console.ReadLine(), out int age) || age <= 0)
            {
                Console.WriteLine("Invalid player age");
                return;
            }

            updatedPlayer.Name = name.Trim();
            updatedPlayer.Age = age;

            await context.SaveChangesAsync();

            Console.WriteLine("Player updated successfully");
        }
        else
        {
            Console.WriteLine("Player not found");
        }
    }

    public async Task DeletePlayer(int playerId)
    {
        using var context = new FootballDbContext();

        Player? deletedPlayer = await context.Players.FindAsync(playerId);

        if (deletedPlayer != null)
        {
            context.Players.Remove(deletedPlayer);
            await context.SaveChangesAsync();

            Console.WriteLine("Player deleted successfully");
        }
        else
        {
            Console.WriteLine("Player not found");
        }
    }
}
