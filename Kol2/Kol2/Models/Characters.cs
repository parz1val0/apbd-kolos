using System.ComponentModel.DataAnnotations;

namespace Kol2.Models;

public class Characters
{
    [Key] 
    public int id { get; set; }
    [MaxLength(100)]
    public string FirstName { get; set; }= string.Empty;
    [MaxLength(100)]
    public string LastName { get; set; }= string.Empty;
    public int MaxWeight { get; set; }
    public int CurrentWeight { get; set; }
    public ICollection<Backpacks> Backpacks { get; set; } = new HashSet<Backpacks>();
    public ICollection<CharacterTitels> CharacterTitels { get; set; } = new HashSet<CharacterTitels>();
}