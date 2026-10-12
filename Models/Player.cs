
using System.ComponentModel.DataAnnotations;

public class Player
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Age { get; set; }

    public ICollection<TrainingSessionPlayers> SessionParticipants { get; set; }
        = new List<TrainingSessionPlayers>();
}
