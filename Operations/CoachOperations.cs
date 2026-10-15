
using Microsoft.EntityFrameworkCore;

public class CoachService
{
    public async Task AddCoach()
    {
        using var context = new FootballDbContext();

        Console.Write("Enter Coach Name: ");
        string? name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Invalid coach name");
            return;
        }

        Coach coach = new Coach
        {
            Name = name.Trim()
        };

        context.Coaches.Add(coach);
        await context.SaveChangesAsync();

        Console.WriteLine($"Coach {coach.Name} added successfully! ID: {coach.Id}, Salary: {coach.Salary}");
    }

    public async Task DisplayCoaches()
    {
        using var context = new FootballDbContext();

        var coaches = await context.Coaches.ToListAsync();

        foreach (var c in coaches)
        {
            Console.WriteLine($"{c.Id} - {c.Name} - Salary: {c.Salary}");
        }
    }

    public async Task FindCoach(int coachId)
    {
        using var context = new FootballDbContext();

        Coach? foundCoach = await context.Coaches.FindAsync(coachId);

        if (foundCoach != null)
        {
            Console.WriteLine($"{foundCoach.Id} - {foundCoach.Name} - Salary: {foundCoach.Salary}");
        }
        else
        {
            Console.WriteLine("Coach not found");
        }
    }

   
public async Task UpdateCoach(int coachId)
{
    using var context = new FootballDbContext();

    CoachRepository repository = new CoachRepository(context);

    Coach? updatedCoach = await repository.FindCoach(coachId);

    if (updatedCoach != null)
    {
        Console.Write("Enter New Coach Name: ");
        string? name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Invalid coach name");
            return;
        }

        Console.Write("Enter New Coach Salary: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal salary) || salary <= 0)
        {
            Console.WriteLine("Invalid coach salary");
            return;
        }

        await repository.UpdateCoach(updatedCoach, name.Trim(), salary);

        Console.WriteLine("Coach updated successfully");
    }
    else
    {
        Console.WriteLine("Coach not found");
    }
}


    public async Task DeleteCoach(int coachId)
    {
        using var context = new FootballDbContext();

        Coach? deletedCoach = await context.Coaches.FindAsync(coachId);

        if (deletedCoach != null)
        {
            context.Coaches.Remove(deletedCoach);
            await context.SaveChangesAsync();

            Console.WriteLine("Coach deleted successfully");
        }
        else
        {
            Console.WriteLine("Coach not found");
        }
    }
}
