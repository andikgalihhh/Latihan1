﻿using DataAccess.Models;

namespace DataAccess.Repositories
{
    public abstract class Repository<T> where T : BaseEntity
    {
        protected readonly List<T> _items = new List<T>();

        public T? GetById(Guid id)
        {
            return _items.FirstOrDefault(item => item.Id == id);
        }

        public void Delete(T item)
        {
            var itemToDelete = GetById(item.Id);
            
            if (itemToDelete == null)
                return;

            _items.Remove(itemToDelete);
        }

        public void Save(T itemToSave)
        {
            var index = _items.IndexOf(itemToSave);
            
            if(index == -1)
                _items.Add(itemToSave);
            else
                _items[index] = itemToSave;
        }

        public void Update(T itemToUpdate)
        {
            var existingItem = GetById(itemToUpdate.Id);

            // If the item exists, update it
            if (existingItem != null)
            {
                var index = _items.IndexOf(existingItem);
                _items[index] = itemToUpdate;
            }
            else
            {
                throw new Exception("Item not found");
            }

        } 
    }
}
