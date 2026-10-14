using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Index(nameof(Title), IsUnique = true)]
public class TrainingSession
{
    [Key]
    public int Id { get; set; }

    public string Title { get; set; } = null!;
    public DateTime Date { get; set; }

    public int CoachId { get; set; }

    [ForeignKey(nameof(CoachId))]
    public Coach Coach { get; set; } = null!;

    public ICollection<TrainingSessionPlayers> SessionParticipants { get; set; } = new List<TrainingSessionPlayers>();
}
