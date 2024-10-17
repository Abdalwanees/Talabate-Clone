using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabate.Clone.Core.Entites;

namespace Talabate.Clone.Core.Specifications
{
    public interface ISpecification<T> where T :BaseEntity
    {
        public Expression<Func<T,bool>> Criteria { get; set; } //
        public List<Expression<Func<T,object>>> Includes { get; set; }
        public Expression<Func<T,object>> OrderBy { get; set; }
        public Expression<Func<T,object>> OrderByDesc { get; set; }
        public Expression<Func<T,object>> ThenBy { get; set; }
        public Expression<Func<T,object>> ThenByDesc { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
        public bool IsPaginationEnables { get; set; }
    }
}
