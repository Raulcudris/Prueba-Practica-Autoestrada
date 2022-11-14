﻿using Microsoft.EntityFrameworkCore;
using Producto.Core.Entities;
using Producto.Core.Interfaces;
using Producto.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producto.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ProductoApiContext _context;
        protected readonly DbSet<T> _entities;

        public BaseRepository(ProductoApiContext  context)
        {
            _context = context;
            _entities = context.Set<T>();
        }


        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }
        public async Task Add(T entity)
        {
           await _entities.AddAsync(entity);
        }   

        public void Update(T entity)
        {
            _entities.Update(entity);
        }
        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            _entities.Remove(entity);
        }

      
    }
}
