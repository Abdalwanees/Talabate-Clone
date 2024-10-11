using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabate.Clone.Core.Entites;
using Talabate.Clone.Core.Specifications;

namespace Talabate.Clone.Repository.Specifications
{
    internal static class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {

        public static IQueryable<TEntity> GetQuary(IQueryable<TEntity> innerQuery , ISpecification<TEntity> specification) 
        {
            var Query=innerQuery;
            if(specification.Criteria is not null)
            {
               Query= Query.Where(specification.Criteria);
                //Quary = _DbContext.Set<BaseEntity>.Where(x=>x.Id=id)
            }
            Query=specification.Includes.Aggregate(Query,(currentQuary,includeExpression)=>currentQuary.Include(includeExpression));
            return Query;
        }

    }

}
