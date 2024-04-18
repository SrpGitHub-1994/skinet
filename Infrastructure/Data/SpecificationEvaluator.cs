using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Core.Specification;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputquery,
        ISpecification<TEntity> specification)
        {
            var query=inputquery;
            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

            query=specification.Includes.Aggregate(query, (current, include) =>
            {
                return current.Include(include);
            });

            return query;
        }
    }
}