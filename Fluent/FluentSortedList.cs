using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluent
{
   public static  class FluentSortedList
    {
        public static SortedList<k, v> AddAnd<k, v>(this SortedList<k, v> slst, k TKey, v TValue)
        {
            slst.Add(TKey, TValue);
            return slst;
        }
        public static SortedList<k, v> RemoveAnd<k, v>(this SortedList<k, v> slst, k TKey)
        {
            slst.Remove(TKey);
            return slst;
        }

        public static SortedList<k, v> ClearAnd<k, v>(this SortedList<k, v> slst)
        {
            slst.Clear();
            return slst;

        }

        public static SortedList<k, v> DoAnd<k, v>(this SortedList<k, v> slst, Action<SortedList<k, v>> a)
        {
            a(slst);
            return slst;
        }
	}
}
