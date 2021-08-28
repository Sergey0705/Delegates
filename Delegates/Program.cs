using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<double, double, double> calculateTotalPriceOfGoodWithTax = (price, tax) => price + (price * tax);

            Action<int, string, int, double> displayGoodDates = (arg1, arg2, arg3, arg4) => Console.WriteLine($"Id: {arg1}{Environment.NewLine}Name: {arg2}{Environment.NewLine}Price: {arg3}{Environment.NewLine}PriceWithTax:{arg4}");

            List<Good> goods = new List<Good>();

            goods.Add(new Good { Id = 1, Name = "Apples", Price = 100, PriceWithTax = calculateTotalPriceOfGoodWithTax(100, 0.13) });
            goods.Add(new Good { Id = 2, Name = "Banana", Price = 120, PriceWithTax = calculateTotalPriceOfGoodWithTax(120, 0.13) });
            goods.Add(new Good { Id = 3, Name = "Potato", Price = 50, PriceWithTax = calculateTotalPriceOfGoodWithTax(50, 0.13) });
            goods.Add(new Good { Id = 4, Name = "Carrot", Price = 80, PriceWithTax = calculateTotalPriceOfGoodWithTax(80, 0.13) });

            //List<Good> goodsFiltered = goods.FilterGoods(g => g.Price < 100);
            List<Good> goodsFiltered = goods.Where(g => g.Price >= 100).ToList();

            foreach (var good in goodsFiltered)
            {
                displayGoodDates(good.Id, good.Name, good.Price, good.PriceWithTax);
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }

    public static class Extensions
    {
        public static List<Good> FilterGoods(this List<Good> goods, Predicate<Good> predicate)
        {
            List<Good> goodsFiltered = new List<Good>();

            foreach (var good in goods)
            {
                if (predicate(good))
                {
                    goodsFiltered.Add(good);
                }
            }

            return goodsFiltered;
        }
    }

    public class Good
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public double PriceWithTax { get; set; }
    }
}
