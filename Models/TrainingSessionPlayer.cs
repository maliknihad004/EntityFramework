
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

public class TrainingSessionPlayers
{
    [Key]
    public int id { get; set; }
    public int trainingSessionId { get; set; }
    
    [ForeignKey("trainingSessionId")]
    public TrainingSession trainingSession { get; set; } = null!;

    public int playerId { get; set; }

    [ForeignKey("playerId")]
    public Player player { get; set; } = null!;
}
