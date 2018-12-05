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



		public static  List<KeyValuePair<K,V>>  ToKeyValueList<K, V>(this Dictionary<K,V> d)
		{
			return new List<KeyValuePair<K, V>>(); 
		}
		public static List<V> ToValueList<K, V>(this Dictionary<K,V> d)
		{
			return new List<V>();
		}
		public static List<K> ToKeyList<K, V>(this Dictionary<K, V> d)
		{
			return new List<K>();
		}

		public static Dictionary<K, V> ToDictionary<K, V>(this IEnumerable<V> ie, Func<V, K> GetKey)
		{
			var d = new Dictionary<K, V>();
			foreach (var e in ie)
			{
				d.Add(GetKey(e), e);
			}
			return d;
		}



	}
}
