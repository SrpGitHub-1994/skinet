using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
          public StoreContext Context { get; set; }
        public GenericRepository(StoreContext context)
        {
            this.Context = context;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
           return await Context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetEntityWithSpec(ISpecification<T> specification)
        {
           return await ApplySpecification(specification).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification)
        {
           return await ApplySpecification(specification).ToListAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> Spec)
        {
            return SpecificationEvaluator<T>.GetQuery(Context.Set<T>().AsQueryable(), Spec);
        }
    }
}