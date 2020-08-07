using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluent
{
   public static  class FluentSortedList
    {
        public static SortedList<K, V> AddAnd<K, V>(this SortedList<K, V> slst, K TKey, V TValue)
        {
            slst.Add(TKey, TValue);
            return slst;
        }
        public static SortedList<K, V> RemoveAnd<K, V>(this SortedList<K, V> slst, K TKey)
        {
            slst.Remove(TKey);
            return slst;
        }

        public static SortedList<K, V> ClearAnd<K, V>(this SortedList<K, V> slst)
        {
            slst.Clear();
            return slst;

        }

        public static SortedList<K, V> DoAnd<K, V>(this SortedList<K, V> slst, Action<SortedList<K, V>> a)
        {
            a(slst);
            return slst;
        }
	}
}
