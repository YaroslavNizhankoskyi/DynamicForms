using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Calls.Forms.Filters
{
    internal static class GetPublicFormsFilter
    {
        public static IQueryable<Form> GetPublic(this IQueryable<Form> query, Visibility visibility) 
        {
            return query.Where(x => x.Visibility == visibility);
        }
    }
}
