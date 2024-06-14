using Kol2.Data;
using Kol2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kol2.Service;

public class CharacterService:ICharacterService
{
    private readonly CharacterContext _context;
    public CharacterService(CharacterContext context)
    {
        _context = context;
    }

    public async Task<ICollection<Characters>> GetCharactersData(int characterId)
    {
        return await _context.Characters
            .Include(e => e.Backpacks)
            .Include(e => e.CharacterTitels)
            .ThenInclude(e => e.Title)
            .Include(e => e.Backpacks)
            .ThenInclude(e => e.Item)
            .Where(e => e.id == characterId)
            .ToListAsync();
    }

    public async Task<bool> DoesCharacterExist(int characterId)
    {
        return await _context.Characters.AnyAsync(e => e.id == characterId);
    }

    public async Task<bool> DoesItemExist(int itemId)
    {
        return await _context.Items.AnyAsync(e => e.id == itemId);
    }
    
    public async Task AddNewBackpack(Backpacks backpack)
    {
        await _context.AddAsync(backpack);
        await _context.SaveChangesAsync();
    }

    public async Task<Items> GetItemById(int itemId)
    {
        return await _context.Items.FirstOrDefaultAsync(e => e.id == itemId);
    }

    public async Task<Characters> GetCharacterById(int characterId)
    {
        return await _context.Characters.FirstOrDefaultAsync(e => e.id == characterId);
    }
}