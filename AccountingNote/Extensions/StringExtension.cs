using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountingNote.Extensions
{
    public static class StringExtension
    {
        public static Guid ToGuid(this string guidText)
        {

            if (Guid.TryParse(guidText, out Guid tempGuid))
                return tempGuid;
            else
                return Guid.Empty;
        }
    }
}
