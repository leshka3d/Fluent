using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluent
{
  public static class FluentLinkedList
    {
        public static LinkedList<T> AddAfterAnd<T>(this LinkedList<T> list, LinkedListNode<T>  a, LinkedListNode<T> b)
        {
            list.AddAfter(a,b);
            return list;
        }
        public static LinkedList<T> AddBeforeAnd<T>(this LinkedList<T> list, LinkedListNode<T> a, LinkedListNode<T> b)
        {
            list.AddBefore(a, b);
            return list;
        }

        public static LinkedList<T> AddFirstAnd<T>(this LinkedList<T> list, LinkedListNode<T> a)
        {
            list.AddFirst(a);
            return list;
        }

        public static LinkedList<T> AddLastAnd<T>(this LinkedList<T> list, LinkedListNode<T> a)
        {
            list.AddLast(a);
            return list;
        }

        public static LinkedList<T> ClearAnd<T>(this LinkedList<T> list)
        {
            list.Clear();
            return list;
        }
        public static LinkedList<T> RemoveAnd<T>(this LinkedList<T> list, LinkedListNode<T> a)
        {
            list.Remove(a);
            return list;
        }
        public static LinkedList<T> RemoveFirstAnd<T>(this LinkedList<T> list)
        {
            list.RemoveFirst();
            return list;
        }

        public static LinkedList<T> RemoveLastAnd<T>(this LinkedList<T> list)
        {
            list.RemoveLast();
            return list;
        }
        public static LinkedList<T> DoAnd<T>(this LinkedList<T> list, Action<LinkedList<T>> a)
        {
            a(list);
            return list;
        }
        public static LinkedList<T> ToLinkedList<T>(this T v)
        {
            return new LinkedList<T>().AddFirstAnd(new LinkedListNode<T> (v));
        }
        public static LinkedList<T> ToLinkedList<T>(this T[] v)
        {
            var list = new LinkedList<T>();
            foreach (var i in v)
            {
                list.AddLast(new LinkedListNode<T> (i));
            }
            return list;
        }
    }
}
