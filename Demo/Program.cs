using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fluent; 
namespace Demo
{
	class Program
	{
		static void Main(string[] args)
		{
			var a =
			0.ToList().AddAnd(1).AddAnd(3).AddAnd(6).AddAnd(7)
			 .ReverseAnd().SortAnd((x, y) => x - y).Take(3).ToList()
			 .Where(x => x > 1).ToList()
			 ._ifContains(6, list => { Console.WriteLine("Contains 6!"); return list; }, list1 => { Console.WriteLine("Added!"); return list1.AddAnd(6); })
			 .DoAddAnd(me=>me.Max()).Distinct ().ToList()
			 .DoAddAnd(me => me.Aggregate((x, y) => x + y)).ForEachAnd(x => { Console.WriteLine(x); });
			Console.ReadLine(); 

			
		}
	}
}
