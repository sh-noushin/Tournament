using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Tournament.API.Domain.Core.Extentions
{
    public static class IQueryableExtentions
    {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> expression)
          where T : class
        {
            if (condition)
            {
                query = query.Where(expression);
            }
            return query;
        }

        public static IQueryable<T> PageBy<T>(this IQueryable<T> query, int skipCount = 0, int maxResultCount = 10)
            where T : class
        {
            return query.Skip(skipCount).Take(maxResultCount);

        }
    }
}
