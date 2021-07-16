using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace FinalProject.Erp.Common.Extensions
{
    public static class QueryableExt
    {
        public static IQueryable<T> MyInclude<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes)
            where T : class
        {
            if (includes != null)
                query = includes.Aggregate(query, (a, b) => a.Include(b));

            return query;
        }
    }
}