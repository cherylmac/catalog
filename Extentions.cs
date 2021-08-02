using Catalog.Dtos;
using Catalog.Models;

namespace Catalog
{
    public static class Extentions
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto
            {
              Id = item.Id,
              Name = item.Name,
              Price = item.Price,
              CreatedDate = item.CreatedDate
            };
        }
    }
}

