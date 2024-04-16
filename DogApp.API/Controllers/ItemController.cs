using DogApp.API.Dto;
using DogApp.Data.EntityModels;
using DogApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DogApp.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemController(IItemService itemService) : Controller
{
    private readonly IItemService _itemService = itemService;




    [HttpGet("GetAllItems")]
    public async Task<IActionResult> GetAllItems()
    {
        try
        {
            var items = await _itemService.GetAllItems();

            // Map the items to ItemDto objects
            var itemDtos = items.Select(item => new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Category = item.Category,
                IsSign = item.IsSign
            }).ToList();

            return Ok(itemDtos);
        }
        catch (Exception)
        {
            // If an error occurs, return a 500 Internal Server Error response
            return StatusCode(500, "An error occurred while fetching items.");
        }
    }

    [HttpGet("GetItemById")]
    public async Task<IActionResult> GetItemByIdAsync(int id)
    {
        try
        {
            var item = await _itemService.GetItemById(id);

            return Ok(item);

        }
        catch(Exception)
        {
            return StatusCode(500, "Der opstod en fejl under hentning af baner.");
        }
        

        
    }
    [HttpPost("UpdateItemById")]
    public async Task UpdateItemByAsync(ItemDto itemDto)
    {
        try
        {

            var item = new Item
            {
                Name = itemDto.Name,
                Description = itemDto.Description,
                Image = itemDto.Image
            };

            await _itemService.UpdateItemById(item);

        }
        catch(Exception)
        {
            Console.WriteLine("kunne ikk finde det element");
        }
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> CreateItemAsync(ItemDto itemDto)
    {
        var item = new Item
        {
            Name = itemDto.Name,
            Description = itemDto.Description,
            Image = itemDto.Image
        };
        try
        {

            await _itemService.CreateItem(item);
            return Ok("Element oprettet succesfuldt");
        }
        catch (Exception)
        {
            // Hvis der opstår en fejl, logges den eller håndteres på anden vis
            // Returner et 500 Internal Server Error-svar, hvis der opstår en fejl
            return StatusCode(500, "Der opstod en fejl under oprettelsen af elementet.");
        }
    }
}
