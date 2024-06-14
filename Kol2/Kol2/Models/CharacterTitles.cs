using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kol2.Models;

[PrimaryKey(nameof(CharacterId), nameof(TitelsId))]
public class CharacterTitels
{
    public int CharacterId { get; set; }
    public int TitelsId { get; set; }
    
    public DateTime AcquiredAt { get; set; }
    [ForeignKey(nameof(CharacterId))]
    public Characters Character { get; set; } = null!;
    [ForeignKey(nameof(TitelsId))]
    public Titles Title { get; set; } = null!;
}