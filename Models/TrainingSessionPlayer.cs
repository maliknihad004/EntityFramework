using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class TrainingSessionPlayers
{
    [Key]
    public int Id { get; set; }

    public int TrainingSessionId { get; set; }

    [ForeignKey(nameof(TrainingSessionId))]
    public TrainingSession TrainingSession { get; set; } = null!;

    public int PlayerId { get; set; }

    [ForeignKey(nameof(PlayerId))]
    public Player Player { get; set; } = null!;
}
