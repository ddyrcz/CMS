using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSDatabaseAccess
{
    static class SqlHelper
    {
        public static DateTime? GetNullableDatetime(object row)
        {
            if(row is DBNull)
            {
                return null;
            }

            return (DateTime)row;
        }
    }
}
