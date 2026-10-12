
using System.ComponentModel.DataAnnotations;

public class Coach
{
    [Key]
    public int id { get; set; }
    public string name { get; set; } = null!;

public ICollection<TrainingSession> Sessions { get; set; }
    = new List<TrainingSession>();}
