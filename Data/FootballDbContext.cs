
using Microsoft.EntityFrameworkCore;
using DotNetEnv;

public class FootballDbContext : DbContext
{
    public DbSet<Coach> Coaches => Set<Coach>();
    public DbSet<Player> Players => Set<Player>();

    public DbSet<TrainingSession> TrainingSessions => Set<TrainingSession>();

    public DbSet<TrainingSessionPlayers> TrainingSessionPlayers
        => Set<TrainingSessionPlayers>();

protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    Env.Load();

    string connectionString =
        Environment.GetEnvironmentVariable("FOOTBALL_DB_CONNECTION")!;

    optionsBuilder.UseNpgsql(connectionString);
}
}
