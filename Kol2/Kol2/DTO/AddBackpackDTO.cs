using Kol2.Models;

namespace Kol2.DTO;

public class AddBackpackDTO
{
    public ICollection<int> ItemsList { get; set; }= null!;
}

public class BackPacksDTO
{
    public ICollection<Backpacks> BackpacksList { get; set; }= null!;
}
