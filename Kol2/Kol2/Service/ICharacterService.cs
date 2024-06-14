using Kol2.Models;

namespace Kol2.Service;

public interface ICharacterService
{
    Task<ICollection<Characters>> GetCharactersData(int characterId);
    Task<bool> DoesCharacterExist(int characterId);
    Task<bool> DoesItemExist(int itemId);
    public Task AddNewBackpack(Backpacks backpack);
    Task<Items> GetItemById(int itemId);
    Task<Characters> GetCharacterById(int characterId);
}