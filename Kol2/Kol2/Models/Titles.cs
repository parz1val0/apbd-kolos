using System.ComponentModel.DataAnnotations;

namespace Kol2.Models;

public class Titles
{
    [Key] 
    public int id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }= string.Empty;
    
    public ICollection<CharacterTitels> CharacterTitels { get; set; } = new HashSet<CharacterTitels>();
}