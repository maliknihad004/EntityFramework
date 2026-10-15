public class CoachRepository
{
    private readonly FootballDbContext context;

    public CoachRepository(FootballDbContext context)
    {
        this.context = context;
    }

    public async Task<Coach?> FindCoach(int coachId)
    {
        return await context.Coaches.FindAsync(coachId);
    }

    public async Task UpdateCoach(Coach coach, string name, decimal salary)
    {
        coach.Name = name;
        coach.Salary = salary;

        await context.SaveChangesAsync();
    }
}