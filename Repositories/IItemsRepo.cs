using System;
using System.Collections.Generic;
using Catalog.Models;

namespace Catalog.Repositories
{
    public interface IItemsRepo
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
        void CreateItem(Item item);
        void UpdateItem(Item item);
    }

}