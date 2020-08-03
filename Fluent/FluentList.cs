using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluent
{
	public static class FluentList
	{
		public static List<T> AddAnd<T>(this List<T> list, T a)
		{
			list.Add(a);
			return list;
		}
		public static List<T> AddRangeAnd<T>(this List<T> list, IEnumerable<T> a)
		{
			list.AddRange(a);
			return list;
		}
		public static List<T> ClearAnd<T>(this List<T> list)
		{
			list.Clear();
			return list;
		}
		

		public static List<T> RemoveAnd<T>(this List<T> list, T item, bool bException = false)
		{
			if (!list.Remove(item))
			{
				if (bException)
				{
					throw new InvalidOperationException("No Items removed");
				}
			}
			return list;

		}

		public static List<T> RemoveAtAnd<T>(this List<T> list, int index)
		{
			if ((list.Count > index)
				&& (index >= 0))
			{
				list.RemoveAt(index);
			}
			return list;

		}
		public static List<T> RemoveRangeAnd<T>(this List<T> list, int index, int count)
		{
			var ei = index + count;
			if (list.Count > ei)
			{
				count = list.Count - index;
			}
			if ((count > 0)
				&& (index >= 0))
			{
				list.RemoveRange(index, count);
			}
			return list;
		}
	
		
		public static List<T> ReverseAnd<T>(this List<T> list)
		{
			list.Reverse();
			return list;
		}
		public static List<T> SortAnd<T>(this List<T> list, Comparison<T> comparison)
		{
			list.Sort(comparison);
			return list;
		}
		

		public static List<T> ForEachAnd<T> (this List<T> list, Action<T> action)
		{
			list.ForEach(action);
			return list; 

		}
		
		
		
		public static List<T> Trim<T>(this List<T> list, Predicate<T> match)
		{
			return list.TrimEnd(match).TrimStart(match); 
			
		}
		public static List<T> TrimEnd<T>(this List<T> list, Predicate<T> match)
		{
			int st = 0;
			for (var i = list.Count-1; i>=0; i--)
			{
				if (!match(list[i]))
				{
					st = i;
					break;
				}
			}
			
			return list.CutPositions(0,st);
			
		}
		public static List<T> TrimStart<T>(this List<T> list, Predicate<T> match)
		{
			int st = 0; 
			for (var i = 0; i < list.Count; i++)
			{
				if (!match(list[i]))			
				{
					st = i; 
					break; 
				}
			}
			return list.CutPositions (st,list.Count -1);
		}


		public static List<T> CutPositions<T> (this List<T> list, int fistIndex, int lastindex)
		{
			return list.GetRange(fistIndex,lastindex - fistIndex+1);			
		}

		public static List<T> DoAnd<T>(this List<T> list, Action<List<T>> a)
        {
			a(list);
			return list;
        }
		public static List<T> ToList<T>(this T V)
		{
			return new List<T>().AddAnd(V);
		}
		public static List<T> ToList<T>(this T[] V)
		{
			return new List<T>().AddRangeAnd (V);
		}
	}

}