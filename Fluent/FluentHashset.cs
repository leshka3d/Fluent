using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluent
{
    public static class FluentHashset
    {
        public static HashSet<T> AddAnd<T>(this HashSet<T> hset, T a)
        {
            hset.Add(a);
            return hset;
        }

        public static HashSet<T> ClearAnd<T>(this HashSet<T> hset)
        {
            hset.Clear();
            return hset;
        }
        public static HashSet<T> RemoveAnd<T>(this HashSet<T> hset, T a)
        {
            hset.Remove(a);
            return hset;
        }
        public static HashSet<T> RemoveWhereAnd<T>(this HashSet<T> hset, Predicate<T> a)
        {
            hset.RemoveWhere(a);
            return hset;
        }

        public static HashSet<T> DoAnd<T>(this HashSet<T> hset, Action<HashSet<T>> a)
        {
            a(hset);
            return hset;
        }
        public static HashSet<T> ToHashSet<T>(this T V)
        {
            return new HashSet<T>().AddAnd(V);
        }
        public static HashSet<T> ToHashSet<T>(this T[] v)
        {
            var hset = new HashSet<T>();
            foreach (var i in v)
            {
                hset.Add(i);
            }
            return hset;
        }

    }
}
