using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluent
{
   public static class FluentQueue
    {


        public static Queue<T> ClearAnd<T>(this Queue<T> q)
        {
            q.Clear();
            return q;
        }

        public static Queue<T> EnqueueAnd<T>(this Queue<T> q, T a)
        {
            q.Enqueue(a);
            return q;
        }

        public static Queue<T> DoAnd<T>(this Queue<T> q, Action<Queue<T>> a)
        {
            a(q);
            return q;
        }
        public static Queue<T> ToQueue<T>(this T v)
        {
            return new Queue<T>().EnqueueAnd(v);
        }
        public static Queue<T> ToQueue<T>(this T[] V)
        {
            var q = new Queue<T>();
            foreach (var item in V)
            {
                     q.Enqueue(item);      
            }

            return q;
        }
    }
}
