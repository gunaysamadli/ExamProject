﻿using Exam.DAL.DataContext;
using Exam.DAL.Repositories.Contracts;
using Exams.DAL.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.DAL.Repositories
{
   public class EfCoreRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly AppDbContext _context;

        public EfCoreRepository(AppDbContext context)
        {
            _context = context;
        }
        public async virtual Task AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async virtual Task DeleteAsync(T entity)
        {
            
        }

        public async virtual Task<IList<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }


        public async virtual Task<T> GetAsync(int? id)
        {
            if (id is null) throw new Exception();

            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async virtual Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async virtual Task CompletelyDeleteAsync(int? id)
        {
            if (id is null) throw new Exception();

            var deletedEntity = await _context.Set<T>().FindAsync(id);

            if (deletedEntity is null) throw new Exception();

            _context.Set<T>().Remove(deletedEntity);
            await _context.SaveChangesAsync();
        }
    }
}
