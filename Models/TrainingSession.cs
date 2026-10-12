
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[Index(nameof(Title), IsUnique = true)]
public class TrainingSession
{
    [Key]
    public int id { get; set; }
    public string Title { get; set; } = null!;
    public DateTime date { get; set; }

    public int coachId { get; set; }

    [ForeignKey("coachId")]
    public Coach coach { get; set; } = null!;

public ICollection<TrainingSessionPlayers> SessionParticipants { get; set; }
    = new List<TrainingSessionPlayers>();}
