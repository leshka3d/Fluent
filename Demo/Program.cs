
using System.Linq;
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
			 .Where(x => x > 1).ToList();			 			 
			

			new[] { 1, 2, 3 }.ToList().AddAnd(4).AddAnd(5).DoAnd (x => x.Add(0)).AddAnd (-1);


			
		}
	}
}
