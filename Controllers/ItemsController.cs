using Microsoft.AspNetCore.Mvc;
using Catalog.Repositories;
using System.Collections.Generic;
using Catalog.Models;
using System;
using System.Linq;
using Catalog.Dtos;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepo repo;

        public ItemsController(IItemsRepo repo)
        {
            this.repo = repo;
        }

        // GET "/items"
        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items = repo.GetItems().Select( item => new ItemDto());
            return items;
        }

        // GET "/items/{id}"
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = repo.GetItem(id);

            if (item is null) 
            {
                return NotFound();
            }

            return item.AsDto();
        }

        // POST "/items"
        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
        {
            Item item = new() 
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price =  itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            repo.CreateItem(item);

            return CreatedAtAction(nameof(GetItem), new { id = item.Id}, item.AsDto());
        }

        // PUT "/items"
        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto)
        {
            var exisitingItem = repo.GetItem(id);

            if (exisitingItem is null)
            {
                return NotFound();
            }

            Item updatedItem = exisitingItem with 
            {
                Name = itemDto.Name,
                Price = itemDto.Price
            };

            repo.UpdateItem(updatedItem);

            return NoContent();
        }

    }
}