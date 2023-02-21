using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B10910066_李東益_1A2B_LINQ修正版
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            char n = ' ';
            do
            {
                int ancerA = 0;
                int ancerB = 0;
                Console.WriteLine("歡迎來到 1A2B 猜數字的遊戲～");
                Random dice = new Random();
                int firstNum = dice.Next(1, 10);
                list.Add(firstNum);
                int secondNum = dice.Next(1, 10);
                while (firstNum == secondNum)
                {
                    secondNum = dice.Next(1, 10);
                }
                list.Add(secondNum);
                int thirdNum = dice.Next(1, 10);
                while (thirdNum == secondNum || thirdNum == firstNum)
                {
                    thirdNum = dice.Next(1, 10);
                }
                list.Add(thirdNum);
                int fourthNum = dice.Next(1, 10);
                while (fourthNum == thirdNum || fourthNum == secondNum || fourthNum == firstNum)
                {
                    fourthNum = dice.Next(1, 10);
                }
                list.Add(fourthNum);
//                Console.WriteLine($"{firstNum}{secondNum}{thirdNum}{fourthNum}");
                while (ancerA != 4)
                {
                    ancerA = 0;
                    ancerB = 0;
                    Console.WriteLine("------");
                    Console.Write("請輸入 4 個數字：");
                    int playerNum = Convert.ToInt32(Console.ReadLine());
                    if (playerNum / 1000 < 1 || playerNum / 1000 >= 10)
                    {
                        Console.WriteLine("請輸入剛好4個數字!不可多不可少!請重新輸入!");
                    }
                    else
                    {
                        int j = 1000;
                        int k = 10000;
                        for (int i = playerNum; list1.Count != 4; i %= k)
                        {
                            list1.Add(i / j);
                            j /= 10;
                            k /= 10;
                        }
                        int numNum = 0;
                        foreach (int i in list)
                        {
                            if (i == list1[0] || i == list1[1] || i == list1[2] || i == list1[3])
                            {
                                if (i == list1[numNum])
                                {
                                    ancerA++;
                                    numNum++;
                                }
                                else
                                {
                                    ancerB++;
                                    numNum++;
                                }
                            }
                            else
                            {
                                numNum++;
                            }
                        }
                        /*                      86~102行註解為失敗作法,到現在都找不到原因
                        int num = 0;
                        foreach (int i in list)
                        {
                            bool result = list1.Any((x) => x == i);
                            if (result)
                            {
                                ancerB++;
                            }
                            if (i == list1[i])
                            {
                                ancerA++;
                                ancerB--;
                                num++;
                            }
                        }
                        */
                        Console.WriteLine($"判定結果是 {ancerA}A{ancerB}B");
                        list1.Clear();
                    }
                }
                Console.WriteLine("恭喜你！猜對了！！\r\n");
                Console.WriteLine("------");
                Console.Write("你要繼續玩嗎？(y/n)");
                n = Convert.ToChar(Console.ReadLine());
                list.Clear();
            } while (n == 'y');
            Console.WriteLine("遊戲結束，下次再來玩喔～");
        }
    }
}
