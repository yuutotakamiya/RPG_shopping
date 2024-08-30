using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_shopping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int money = 1000; // 初期の所持金
            bool continueShopping = true;

            while (continueShopping && money > 0)
            {
                Console.WriteLine($"現在の所持金: {money}G");
                Console.WriteLine("購入したいアイテムを選択してください:");
                Console.WriteLine("1. ポーション (200G)");
                Console.WriteLine("2. エーテル (300G)");
                Console.WriteLine("3. エリクサー (500G)");
                Console.WriteLine("0. 0で買い物をやめる");


                Console.WriteLine("0. 0で買い物をやめる");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        if (money >= 200)
                        {
                            money -= 200;
                            Console.WriteLine("ポーションを購入しました。");
                        }
                        else
                        {
                            Console.WriteLine("所持金が足りません。");
                        }
                        break;

                    case "2":
                        if (money >= 300)
                        {
                            money -= 300;
                            Console.WriteLine("エーテルを購入しました。");
                        }
                        else
                        {
                            Console.WriteLine("所持金が足りません。");
                        }
                        break;

                    case "3":
                        if (money >= 500)
                        {
                            money -= 500;
                            Console.WriteLine("エリクサーを購入しました。");
                        }
                        else
                        {
                            Console.WriteLine("所持金が足りません。");
                        }
                        break;

                    case "4":
                        continueShopping = false;
                        Console.WriteLine("0で買い物を終了します。");
                        break;

                    default:
                        Console.WriteLine("無効な選択です。もう一度選んでください。");
                        break;
                }

                Console.WriteLine();
            }

            Console.WriteLine("所持金がなくなりました。買い物を終了します。");
        }
    }
}
