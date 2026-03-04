using KASHOP.DAL.Data;
using KASHOP.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.DAL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationeDbContext _context;
        public GenericRepository(ApplicationeDbContext context)
        {
            _context = context;
        }

        public async Task<T> CreateAsync(T category)
        {
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<List<T>> GetAllAsync(string[]? includes=null)
        {
            IQueryable<T> query = _context.Set<T>();
            if(includes != null)
            foreach (var include in includes)
                    query= query.Include(include); 
            return await query.ToListAsync();

        }
        public async Task<T> GetOneAsync(Expression<Func<T,bool>> filter,string[]? includes = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if(includes != null)
            foreach (var include in includes)
                    query= query.Include(include);
            var cat= await query.FirstOrDefaultAsync(filter);
            
            return cat;

        }
    }
}
