using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabate.Clone.Core.Entites;

namespace Talabate.Clone.Core.Specifications
{
    public class BaseSpecifications<T> : ISpecification<T> where T : BaseEntity

    {
        public Expression<Func<T, bool>> Criteria { get; set; }

        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> OrderBy { get; set; }
        public Expression<Func<T, object>> OrderByDesc { get; set; }
        public Expression<Func<T, object>> ThenBy { get; set; }
        public Expression<Func<T, object>> ThenByDesc { get; set; }
        public int Take { get ; set ; }// defalut 0
        public int Skip { get ; set ; }// default 0
        public bool IsPaginationEnables { get; set; } = false;

        public BaseSpecifications() { }
        public BaseSpecifications(Expression<Func<T, bool>> criteriaExpression)
        {
            Criteria = criteriaExpression;
        }
        //Method just only for set values
        public void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }
        public void AddOrderByDesc(Expression<Func<T, object>> orderbyDescExpression)
        {
            OrderByDesc = orderbyDescExpression;
        }
        public void AddThenBy(Expression<Func<T, object>> thenByExpression)
        {
            ThenBy = thenByExpression;
        }
        public void AddThenByDesc(Expression<Func<T, object>> thenbyDescExpression)
        {
            ThenByDesc = thenbyDescExpression;
        }
        public void ApplyPagination(int take ,int skip)
        {
            IsPaginationEnables = true;
            Take = take;
            Skip = skip;
        }


    }
}
