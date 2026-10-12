
using System.ComponentModel.DataAnnotations;

public class Player
{
    [Key]
    public int id { get; set; }
    public string name { get; set; } = null!;
    public int age { get; set; }

public ICollection<TrainingSessionPlayers> SessionParticipants { get; set; }
    = new List<TrainingSessionPlayers>();}
