using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics.CodeAnalysis;

namespace B10910066_李東益_product暫定做法
{
    class ReadingCSV
    {
        static void Main(string[] args)
        {
            var reader = new StreamReader(File.OpenRead(@"C:\Users\zack\Downloads\product.csv"));
            List<string> list = new List<string>();
            //            int i;
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    foreach (var v in values)
                    {
                        list.Add(v);
                    }
                }
                //                i = 0;
                //                foreach (var coloumn1 in listA)
                //                {
                //                    Console.Write($"{coloumn1} ");
                //                    i++;
                //                    if (i == 5)
                //                    {
                //                        Console.WriteLine();
                //                        i = 0;
                //                    }
                //                }
                Console.WriteLine("第一小題 計算所有商品的總價格");
                int num = 0;
                int num_price;
                for (int i = 8; i <= list.Count; i = i + 5)
                {
                    num_price = Convert.ToInt32(list[i]);
                    num += num_price;
                }
                Console.WriteLine($"所有商品的總價格為{num}");
                Console.WriteLine("第二小題 計算所有商品的平均價格");
                num = 0;
                num_price = 0;
                decimal num_averge_price;
                int num_count = 0;
                for (int i = 8; i <= list.Count; i = i + 5)
                {
                    num_price = Convert.ToInt32(list[i]);
                    num += num_price;
                    num_count++;
                }
                num_averge_price = num / num_count;
                Console.WriteLine($"所有商品的總價格平均為{num_averge_price}");
                Console.WriteLine("第三小題 計算商品的總數量");
                int count = 0;
                int count_num = 0;
                for (int i = 7; i <= list.Count; i = i + 5)
                {
                    count = Convert.ToInt32(list[i]);
                    count_num += count;
                }
                Console.WriteLine($"商品的總數量為{count_num}");
                Console.WriteLine("第四小題 計算商品的平均數量");
                count = 0;
                count_num = 0;
                decimal count_num_averge = 0;
                num_count = 0;
                for (int i = 7; i <= list.Count; i = i + 5)
                {
                    count = Convert.ToInt32(list[i]);
                    count_num += count;
                    num_count++;
                }
                count_num_averge = count_num / num_count;
                Console.WriteLine($"商品的平均數量為{count_num_averge}");
                Console.WriteLine("第五小題 找出哪一項商品最貴");
                List<string> list5 = new List<string>();
                for (int i = 8; i <= list.Count; i = i + 5)
                {
                    list5.Add(list[i]);
                }
                var maxNumPrice = list5.Max((x) => x);
                var maxNum = list.IndexOf(maxNumPrice);
                Console.WriteLine($"最貴的商品為{list[maxNum - 2]}");
                Console.WriteLine("第六小題 找出哪一項商品最便宜");
                List<string> list6 = new List<string>();
                for (int i = 8; i <= list.Count; i = i + 5)
                {
                    list6.Add(list[i]);
                }
                var minNumPrice = list6.Min((x) => x);
                var minNum = list.IndexOf(minNumPrice);
                Console.WriteLine($"最便宜的商品為{list[minNum - 2]}");
                Console.WriteLine("第七小題 計算產品類別為 3C 的商品總價");
                List<string> list7 = new List<string>();

                //                var price_3C = list7.Min((x) => x);

                var price_3C = list.IndexOf("3C");
                //                Console.WriteLine($"3C商品總價格為{list[price_3C-1]}");
            }

        }
    }
}