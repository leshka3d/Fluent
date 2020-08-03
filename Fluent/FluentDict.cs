using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Fluent
{

	public static class FluentDict
	{
		public static Dictionary<K, V> AddAnd<K, V>(this Dictionary<K, V> dict, K TKey, V TValue)
		{
			dict.Add(TKey, TValue);
			return dict;
		}
		public static Dictionary<K, V> RemoveAnd<K, V>(this Dictionary<K, V> dict, K TKey)
		{
			dict.Remove(TKey);
			return dict;
		}
		

		public static Dictionary<K, V> ClearAnd<K, V>(this Dictionary<K, V> dict)
		{
			dict.Clear();
			return dict;
			
		}

		

	}
}
