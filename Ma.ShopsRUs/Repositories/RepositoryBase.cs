using Ma.ShopsRUs.Data;
using Ma.ShopsRUs.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ma.ShopsRUs.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly ApplicationContext _context;

        public RepositoryBase(ApplicationContext context)
        {
            _context = context;
        }
        public void Create(T entity) => _context.Set<T>().Add(entity);

        public IQueryable<T> FindAll(bool trackChanges) =>
            trackChanges ? _context.Set<T>() : _context.Set<T>().AsNoTracking();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            trackChanges ? _context.Set<T>().Where(expression) :
            _context.Set<T>().Where(expression).AsNoTracking();

        public void Update(T entity) => _context.Set<T>().Update(entity);
    }
}
