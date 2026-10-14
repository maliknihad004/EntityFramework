using System.ComponentModel.DataAnnotations;

public class Coach
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public ICollection<TrainingSession> Sessions { get; set; } = new List<TrainingSession>();
}
