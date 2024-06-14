using System.ComponentModel.DataAnnotations;

namespace Kol2.Models;

public class Items
{
    [Key] 
    public int id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }= string.Empty;
    public int Weight { get; set; }
    public ICollection<Backpacks> Backpacks { get; set; } = new HashSet<Backpacks>();
}