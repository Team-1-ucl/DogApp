using DogApp.API.Dto;
using DogApp.Data.EntityModels;
using DogApp.Services.InterfaceService;
using Microsoft.AspNetCore.Mvc;

namespace DogApp.API.Controllers
{
    public class ItemController(IItemService itemService) : Controller
    {
        private readonly IItemService _itemService = itemService;
        
        
        
        
        [HttpGet("GetAllItems")]
        public async Task<IActionResult> GetAllItems()
        {
            if(_itemService == null)
            {
                throw new InvalidOperationException();
            }
            try
            {
                var items = await _itemService.GetAllItems();

                var itemDtos = new List<ItemDto>();

                foreach (var item in items)
                {
                    itemDtos.Add(new ItemDto(item.Id, item.Name,  item.Description, item.Image));
                }
                return Ok(itemDtos);
            }
            catch (Exception)
            {
                // Hvis der opstår en fejl, returner et 500 Internal Server Error-svar
                return StatusCode(500, "Der opstod en fejl under hentning af baner.");           
            }
        }
    }
}
