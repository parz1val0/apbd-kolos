using System.Transactions;
using Kol2.DTO;
using Kol2.Models;
using Kol2.Service;
using Microsoft.AspNetCore.Mvc;

namespace Kol2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BackpackController : ControllerBase
{
    private readonly ICharacterService _characterService;
    public BackpackController(ICharacterService characterService)
    {
        _characterService = characterService;
    }
    
    /*[HttpPost("{characterId}/backpacks")]
    public async Task<IActionResult> AddNewBackPack(int characterId,AddBackpackDTO newBackpacksDto)
    {
        if (!await _characterService.DoesCharacterExist(characterId))
            return NotFound($"Character with given ID - {characterId} doesn't exist");

        foreach (var ItemId in newBackpacksDto.ItemsList)
        {
            if (!await _characterService.DoesItemExist(ItemId))
                return NotFound($"Item with given ID - {ItemId} doesn't exist");
        }
        

        Characters character = await _characterService.GetCharacterById(characterId);
        ICollection<Items>? ItemsList = null;
        foreach (var ItemId in newBackpacksDto.ItemsList)
        {
            var item = await _characterService.GetItemById(ItemId);
            ItemsList.Add(item);
            if (character.CurrentWeight + item.Weight > character.MaxWeight)
            {
                return BadRequest($"Character hasn't enough free weight for new item");
            }
        }




        IEnumerable<Backpacks> backpack = null;
        foreach (var Items in ItemsList)
        {
            new BackPacksDTO().BackpacksList.Add(new Backpacks()
            {
                Amount = 1,
                CharacterId = characterId,
                ItemId = Items.id
            });
        }
        
        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            await _characterService.AddNewBackpack(backpack);
            scope.Complete();
        }


        return Created("api/backpacks", backpack.Select(b => new 
        {
            b.Amount,
            b.ItemId,
            b.CharacterId
        }));
    }*/
    [HttpPost("{characterId}/backpacks")]
    public async Task<IActionResult> AddNewBackPack(int characterId, AddBackpackDTO newBackpacksDto)
    {
        if (!await _characterService.DoesCharacterExist(characterId))
            return NotFound($"Character with given ID - {characterId} doesn't exist");

        foreach (var ItemId in newBackpacksDto.ItemsList)
        {
            if (!await _characterService.DoesItemExist(ItemId))
                return NotFound($"Item with given ID - {ItemId} doesn't exist");
        }

        Characters character = await _characterService.GetCharacterById(characterId);
        var ItemsList = new List<Items>();

        foreach (var ItemId in newBackpacksDto.ItemsList)
        {
            var item = await _characterService.GetItemById(ItemId);
            ItemsList.Add(item);
            if (character.CurrentWeight + item.Weight > character.MaxWeight)
            {
                return BadRequest($"Character hasn't enough free weight for new item");
            }
        }

        var backpackList = new List<Backpacks>(); // Инициализация backpackList
        foreach (var item in ItemsList)
        {
            var backpack = new Backpacks
            {
                Amount = 1,
                CharacterId = characterId,
                ItemId = item.id
            };
            backpackList.Add(backpack);
        }

        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            foreach (var backpack in backpackList)
            {
                await _characterService.AddNewBackpack(backpack);
            }
            scope.Complete();
        }

        return Created("api/backpacks", backpackList.Select(b => new 
        {
            b.Amount,
            b.ItemId,
            b.CharacterId
        }));
    }

}