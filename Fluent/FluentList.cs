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
		public static T GetOrNull<T>(this List<T> list, Predicate<T> match, bool Exception = false )
		{
			var r = list.FindIndex(match);
			if (r == -1)
			{
				if (Exception)
				{
					throw new InvalidOperationException("No Items found");
				}
			}
			return list[r];
		}

		public static List<T> RemoveOrNot<T>(this List<T> list, T item, bool Exception = false)
		{
			if (!list.Remove(item))
			{
				if (Exception)
				{
					throw new InvalidOperationException("No Items removed");
				}
			}
			return list;

		}
		public static List<T> RemoveAllOrNot<T>(this List<T> list, Predicate<T> match, bool Exception = false)
		{
			if (list.RemoveAll(match) == 0)
			{
				if (Exception)
				{
					throw new InvalidOperationException("No Items removed");
				}
			}
			return list;
		}

		public static List<T> RemoveAtOrNot<T>(this List<T> list, int index)
		{
			if ((list.Count > index)
				&& (index >= 0))
			{
				list.RemoveAt(index);
			}
			return list;

		}
		public static List<T> RemoveRangeOrNot<T>(this List<T> list, int index, int count)
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
		public static List<T> TrimExcessAnd<T>(this List<T> list)
		{
			list.TrimExcess();
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
		
		

		//// IF
		
		public static List<T> _ifContains<T>(this List<T> list, T o, Func <List<T>,List<T>> _true, Func<List<T>, List<T>> _false = null)
		{

			if (list.Contains (o))
			{
				return _true(list); 
			}

			if (_false == null)
			{
				return list;
			}
			else
			{
				return _false (list); 
			}
		}

		public static List<T> _ifExist<T>(this List<T> list, Predicate<T> match, Func<List<T>, List<T>> _true, Func<List<T>, List<T>> _false = null)
		{
			if (list.Exists(match))
			{
				return _true(list);
			}

			if (_false == null)
			{
				return list;
			}
				return _false(list);
			
		}

		public static List<T> _ifAll<T>(this List<T> list, Predicate<T> match, Func<List<T>, List<T>> _true, Func<List<T>, List<T>> _false = null)
		{
			if (list.All (x=> match (x)))

			{
				return _true(list);
			}

			if (_false == null)
			{
				return list;
			}
			
			return _false(list);
			
		}

		public static List<T> _ifFirst<T>(this List<T> list, Predicate<T> match, Func<List<T>, List<T>> _true, Func<List<T>, List<T>> _false = null)
		{
			if (match (list[0]))
			{
				return _true(list);
			}

			if (_false == null)
			{
				return list;
			}

			return _false(list);
		}

		public static List<T> _ifLast<T>(this List<T> list, Predicate<T> match, Func<List<T>, List<T>> _true, Func<List<T>, List<T>> _false = null)
		{
			if (match(list[list.Count-1]))
			{
				return _true(list);
			}

			if (_false == null)
			{
				return list;
			}

			return _false(list);
		}

		public static List<T> _ifN<T>(this List<T> list, Predicate<T> match, int n, Func<List<T>, List<T>> _true, Func<List<T>, List<T>> _false = null)
		{
			if (match (list[n] ))
			{
				return _true(list);
			}

			if (_false == null)
			{
				return list;
			}

			return _false(list);
		}

		public static List<T> _ifEmpty<T>(this List<T> list, int n, Func<List<T>, List<T>> _true, Func<List<T>, List<T>> _false = null)
		{
			if (list[n] == null)
			{
				return _true(list);
			}

			if (_false == null)
			{
				return list;
			}

			return _false(list);
		}


		public static List<T> _ifCount<T>(this List<T> list, Predicate<int> match, Func<List<T>, List<T>> _true, Func<List<T>, List<T>> _false = null)
		{
			if (match (list.Count))
			{
				return _true(list);
			}

			if (_false == null)
			{
				return list;
			}

			return _false(list);
		}
		
		public static List<T> ToList<T> (this T V)
		{
			return new List<T>().AddAnd(V); 
		}
		
		
		public static List<T> DoAddAnd<T>  (this List<T> list, Func <List<T>,T> fn)
		{
			var r = fn(list);
			return list.AddAnd(r);			
		}

		public static Tuple<T,List<T>> GetHead<T> (this List<T> list)
		{
			return new Tuple<T, List<T>>(list[0], list.GetRange (1,list.Count -1));
		}
		public static Tuple<List<T>, List<T>> GetHead<T> (this List<T> list, int x)
		{

			return new Tuple<List<T>, List<T>>  (list.GetRange(0, x), list.GetRange(x, list.Count - x-1)) ;
		}

		public static  List<T> CallWhile<T> (this List<T> list, Func<List<T>, List<T>> fn, Func<List<T>, bool> wh, bool mod = true)
		{			
			var l = fn(list);
			while (wh(l))
			{ l = fn(l); }
			if (mod){ return l; }
			return list;
		}
		public static List<T> CallWhileNotNull<T>(this List<T> list, Func<List<T>, List<T>> fn)
		{			
			var l = fn(list);
			while (l != null)
			{ l = fn(l); }
			return list;
		}
		///  Linq
		/*
		 * Aggregate
		 * Average
		 * ElementAt
		 * ElementAtOrDefault
		 * Max
		 * Min
		 * Sum
		 * ==
		 * Hash
		 * Median
		 */
		// действие над всеми элементами 


	}

}