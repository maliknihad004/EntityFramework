
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[Index(nameof(TrainingSessionId), nameof(PlayerId), IsUnique = true)]
public class TrainingSessionPlayers
{
    [Key]
    public int Id { get; set; }

    public int TrainingSessionId { get; set; }

    [ForeignKey("TrainingSessionId")]
    public TrainingSession TrainingSession { get; set; } = null!;

    public int PlayerId { get; set; }

    [ForeignKey("PlayerId")]
    public Player Player { get; set; } = null!;
}
