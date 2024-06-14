using Kol2.DTO;
using Kol2.Service;
using Microsoft.AspNetCore.Mvc;

namespace Kol2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CharactersController : ControllerBase
{
    private readonly ICharacterService _characterService;
    public CharactersController(ICharacterService characterService)
    {
        _characterService = characterService;
    }

    [HttpGet("${characterId}")]
    public async Task<IActionResult> GetCharactersData(int characterId)
    {
        var characters = await _characterService.GetCharactersData(characterId);

        return Ok(characters.Select(e => new GetCharactersDTO()
        {
            FirstName = e.FirstName,
            LastName = e.LastName,
            CurrentWeight = e.CurrentWeight,
            MaxWeight = e.MaxWeight,
            backpackItems = e.Backpacks.Select(p => new GetBackpacksDTO
            {
                ItemName = p.Item.Name,
                ItemWeight = p.Item.Weight,
                Amount = p.Amount
            }).ToList(),
            titles = e.CharacterTitels.Select(p => new GetCharacterTitlesDTO
            {
                Title = p.Title.Name,
                AcquiredAt = p.AcquiredAt
            }).ToList()
        }));

    }
}