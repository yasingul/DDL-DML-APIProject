using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeLayer.Data
{
    public class IGenericRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;

        public IGenericRepository(AppDbContext context)
        {
            _dbSet = context.Set<T>();
        }

        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
    }
}