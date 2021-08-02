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

    }
}