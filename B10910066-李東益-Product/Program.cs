using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.IO.Pipes;
using System.Diagnostics;

namespace B10910066_李東益_Product
{
    class ReadingCSV
    {
        static void Main(string[] args)
    {
            var list1 = CreateList();
            Console.WriteLine("1. 計算所有商品的總價格");
            int priceTotal = list1.Sum((x) => x.price);
            Console.WriteLine($"所有商品的總價格為{priceTotal}");
            Console.WriteLine();
            Console.WriteLine("2. 計算所有商品的平均價格");
            double priceAverge = list1.Average(x => x.price);
            Console.WriteLine($"所有商品的平均價格為{priceAverge}");
            Console.WriteLine();
            Console.WriteLine("3. 計算商品的總數量");
            int quantityCount = list1.Sum(x => x.quantity);
            Console.WriteLine($"商品的總數量為{quantityCount}");
            Console.WriteLine();
            Console.WriteLine("4. 計算商品的平均數量");
            double quantityAverge = list1.Average(x => x.quantity);
            Console.WriteLine($"商品的平均數量為{quantityAverge}");
            Console.WriteLine();
            Console.WriteLine("5. 找出哪一項商品最貴");
            var maxPrice = list1.Max(x => x.price);
            var maxPriceName = list1.First(x => x.price == maxPrice);
            Console.WriteLine($"最貴的商品為{maxPriceName.Name}");
            Console.WriteLine();
            Console.WriteLine("6. 找出哪一項商品最便宜");
            int minPrice = list1.Min(x => x.price);
            var minPriceName = list1.First(x => x.price == minPrice);
            Console.WriteLine($"最便宜的商品為{minPriceName.Name}");
            Console.WriteLine();
            Console.WriteLine("7. 計算產品類別為 3C 的商品總價");
            int price3CTotal = list1.Where(x=> x.category == "3C").Sum(x => x.price);
            Console.WriteLine($"類別為 3C 的商品總價{price3CTotal}");
            Console.WriteLine();
            Console.WriteLine("8. 計算產品類別為飲料及食品的商品總價");
            int foodAndDrinckPriceTotal = list1.Where(x => x.category == "食品").Sum(x => x.price) + list1.Where(x => x.category == "飲料").Sum(x => x.price);
            Console.WriteLine($"產品類別為飲料及食品的商品總價為{foodAndDrinckPriceTotal}");
            Console.WriteLine();
            Console.WriteLine("9. 找出所有商品類別為食品，而且商品數量大於 100 的商品");
            var list9 = list1.Where((x) => x.quantity > 100).Where((x) => x.category == "食品").ToList();
            Console.Write("類別為食品，而且商品數量大於 100 的商品為:");
            foreach (var item in list9)
            {
                Console.Write($"{item.Name} ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("10. 找出各個商品類別底下有哪些商品的價格是大於 1000 的商品");
            var list10 = list1.GroupBy((x) => x.category);
            foreach (var item in list10)
            {
                Console.WriteLine($"{item.Key}:");
                foreach (var v in item)
                {
                    if( v.price > 1000)
                    {
                        Console.Write($"{v.Name} ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("11. 呈上題，請計算該類別底下所有商品的平均價格");
            int numAveragePrice;
            int numCount = 0;
            int vPriceTotal = 0;
            foreach (var item in list10)
            {
                Console.Write($"{item.Key}的平均價格為:");
                foreach (var v in item)
                {
                    numCount++;
                    vPriceTotal+= v.price;
                }
                numAveragePrice = vPriceTotal/numCount;
                Console.WriteLine($"{numAveragePrice} ");
                numCount = 0;
                vPriceTotal = 0;
            }
            Console.WriteLine();
            Console.WriteLine("12. 依照商品價格由高到低排序");
            List<MyData> list12_1 = new List<MyData>();
            List<MyData> list12_2 = new List<MyData>();
            foreach ( var v in list1)
            {
                list12_1.Add(v);
            }
            while(list12_1.Count > 0)
            {
                priceTotal = list12_1.Max( x => x.price );
                list12_2.Add(list12_1.First(x => x.price == priceTotal));
                list12_1.Remove(list12_1.First(x => x.price == priceTotal));
            }            
            foreach(var v in list12_2)
            {
                Console.Write($"{v.Name} ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("13. 依照商品數量由低到高排序");
            List<MyData> list13_1 = new List<MyData>();
            List<MyData> list13_2 = new List<MyData>();
            foreach (var v in list1)
            {
                list13_1.Add(v);
            }
            while (list13_1.Count > 0)
            {
                priceTotal = list13_1.Min(x => x.quantity);
                list13_2.Add(list13_1.First(x => x.quantity == priceTotal));
                list13_1.Remove(list13_1.First(x => x.quantity == priceTotal));
            }
            foreach (var v in list13_2)
            {
                Console.Write($"{v.Name} ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("14. 找出各商品類別底下，最貴的商品");
            var list14 = list1.GroupBy(x => x.category);
            int maxPriceCategory;
            foreach (var v in list14)
            {
                Console.Write($"{v.Key}: ");
                maxPriceCategory = v.Max(x => x.price);
                var w = v.First(x => x.price == maxPriceCategory);
                Console.WriteLine(w.Name);
            }
            Console.WriteLine();
            Console.WriteLine("15. 找出各商品類別底下，最便宜的商品");
            var list15 = list1.GroupBy(x => x.category);
            int minPriceCategory;
            foreach (var v in list15)
            {
                Console.Write($"{v.Key}: ");
                minPriceCategory = v.Min(x => x.price);
                var w = v.First(x => x.price == minPriceCategory);
                Console.WriteLine(w.Name);
            }
            Console.WriteLine();
            Console.WriteLine("16. 找出價格小於等於 10000 的商品");
            List<MyData> list16 = new List<MyData>();
            list16 = list1.Where(x => x.price <= 10000).ToList();
            Console.Write("價格價格小於等於 10000 的商品有");
            foreach(var v in list16)
            {
                Console.Write($"{v.Name} ");
            }
            Console.WriteLine("");
            Console.WriteLine();
            Console.WriteLine("17. 製作一頁 4 筆總共 5 頁的分頁選擇器");
            Console.Write("請輸入(1~5)頁碼:");
            char num = Convert.ToChar(Console.ReadLine());
            int i = 0;
            switch (num)
            {
                case '1':
                    foreach(var v in list1)
                    {
                        if(i < 4)
                        {
                            Console.WriteLine($"商品編號:{v.num} 商品名稱:{v.Name} 商品數量:{v.quantity} 價格:{v.price} 商品類別:{v.category}");
                        }
                        i++;
                    }
                    break;
                case '2' :
                    foreach (var v in list1)
                    {
                        if (i >= 4 && i < 8)
                        {
                            Console.WriteLine($"商品編號:{v.num} 商品名稱:{v.Name} 商品數量:{v.quantity} 價格:{v.price} 商品類別:{v.category}");
                        }
                        i++;
                    }
                    break;
                case '3':
                    foreach (var v in list1)
                    {
                        if (i >= 8 && i < 12)
                        {
                            Console.WriteLine($"商品編號:{v.num} 商品名稱:{v.Name} 商品數量:{v.quantity} 價格:{v.price} 商品類別:{v.category}");
                        }
                        i++;
                    }
                    break;
                case '4':
                    foreach (var v in list1)
                    {
                        if (i >= 12 && i < 16)
                        {
                            Console.WriteLine($"商品編號:{v.num} 商品名稱:{v.Name} 商品數量:{v.quantity} 價格:{v.price} 商品類別:{v.category}");
                        }
                        i++;
                    }
                    break;
                case '5':
                    foreach (var v in list1)
                    {
                        if (i >= 16 && i < list1.Count)
                        {
                            Console.WriteLine($"商品編號:{v.num} 商品名稱:{v.Name} 商品數量:{v.quantity} 價格:{v.price} 商品類別:{v.category}");
                        }
                        i++;
                    }
                    break;
                default: 
                    Console.WriteLine("數字輸入錯誤!");
                    break;
            }

        }
        static List<MyData> CreateList()
    {
        var reader = new StreamReader(File.OpenRead(@"C:\Users\zack\Downloads\product.csv"));
        List<string> list = new List<string>();
        while (!reader.EndOfStream)
        {
             var line = reader.ReadLine();
             var values = line.Split(',');
             foreach (var v in values)
             {
                 list.Add(v);
             }
        }
        List<MyData> list1 = new List<MyData>();
            for( int i = 5; i < list.Count; i += 5)
            {
                list1.Add(new MyData { num = list[i], Name = list[i + 1], quantity = Convert.ToInt32(list[i+2]), price = Convert.ToInt32(list[i + 3]), category = list[i + 4] });
            }
            return new List<MyData>(list1);


}
    }
    
    
}