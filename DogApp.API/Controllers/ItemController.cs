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
                // Map other properties as needed
            }).ToList();

            // Return the list of ItemDto objects
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
}
