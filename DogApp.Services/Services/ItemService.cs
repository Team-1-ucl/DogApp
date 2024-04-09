using DogApp.Data.EntityModels;
using DogApp.Repository;
using DogApp.Services.InterfaceService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogApp.Services.Services
{
    public class ItemService(IItemRepo itemRepo) : IItemService
    {
        private readonly IItemRepo _itemrepo = itemRepo ?? throw new ArgumentNullException(nameof(itemRepo));
        public async Task CreateItem(Item item)
        {
            ArgumentNullException.ThrowIfNull(item);
            await _itemrepo.AddAsync(item);
        }

        public async Task<List<Item>> GetAllItems()
        {
            return await _itemrepo.GetAllAsync();
        }
    }
}
