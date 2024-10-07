using EXamination.Core;
using EXamination.Core.Data;
using EXamination.Core.RepositoriesInterFaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXamination.Repository.Repositories
{
    public class GenaricRepository<TEntity, TKey> : IGenaricRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly ExaminationContext _context;

        public GenaricRepository(ExaminationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
           

            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
        public async Task<int> AddAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync();

        }

        public async Task<int> Update(TEntity entity)
        {
            _context.Update(entity);
            return await _context.SaveChangesAsync();

        }

        public async Task<int> Delete(TKey id)
        {
            var entity =await GetByIdAsync(id);
            _context.Remove(entity);
            return await _context.SaveChangesAsync();

        }



    }
}
