using System;
using System.Collections.Generic;
using System.Linq;

namespace Fluent
{
    public static class FluentStack
    {
        public static Stack<T> ClearAnd<T>(this Stack<T> stack)
        {
            stack.Clear();
            return stack;
        }
        public static Stack<T> MoveUpAnd<T>(this Stack<T> stack, int n)
        {
            for (var i = 0; i < n; i++)
            {
                if (stack.Count > 0)
                {
                    stack.Pop();
                }
            }
            return stack;
        }
        public static Stack<T> PushAnd<T>(this Stack<T> stack, T a)
        {
            stack.Push(a);
            return stack;
        }
    
        public static Stack<T> ReverseAnd<T>(this Stack<T> stack)
        {
            stack.Reverse();
            return stack;
        }

        public static Stack<T> DoAnd<T>(this Stack<T> stack, Action<Stack<T>> a)
        {
            a(stack);
            return stack;
        }
        public static Stack<T> ToStack<T>(this T v)
        {
            return new Stack<T>().PushAnd(v);
        }
        public static Stack<T> ToStack<T>(this T[] v)
        {
            var st = new Stack<T>(); 
            foreach (var i in v)
            {
                st.Push(i);
            }
            return st;
        }


    }
}
