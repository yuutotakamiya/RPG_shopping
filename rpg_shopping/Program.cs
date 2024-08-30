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
            // 購入可能なアイテムリストを初期化
            List<Item> itemList = new List<Item>()
            {
                new Item(1, "ポーション", 200),
                new Item(2, "エーテル", 300),
                new Item(3, "エリクサー", 500)
            };

            int money = 1000; // 初期の所持金

            // 購入したアイテムを記録するリスト
            Dictionary<Item, int> purchaseHistory = new Dictionary<Item, int>();

            bool continueShopping = true;// 買い物を続けるかどうかのフラグ

            Console.WriteLine("へい！いらっしゃい！！！！");
            Console.ReadLine();

            Console.Clear();// 画面をクリア
            Console.WriteLine("なにを買っていくんだぁ？");
            Console.ReadLine();

            while (continueShopping && money > 0)
            {
                Console.Clear();// 画面をクリア

                // 所持アイテムの表示
                Console.WriteLine("現在の所持アイテム:");
                if (purchaseHistory.Count > 0)
                {
                    foreach (var entry in purchaseHistory)
                    {
                        Console.WriteLine($"{entry.Key.Name}: {entry.Value}個");
                    }
                }
                else
                {
                    Console.WriteLine("アイテムなし\n");// 何も購入していない場合の表示
                }

                //現在の所持金額の表示
                Console.WriteLine($"現在の所持金: {money}G");

                //購入可能なアイテムの表示
                Console.WriteLine("購入したいアイテムを選択してください:");

                foreach (var item in itemList)
                {
                    Console.WriteLine($"{item.Id}. {item.Name} ({item.Price}G)");
                }

                Console.WriteLine("4. 0で買い物をやめる");// 買い物を終了するオプション

                if (int.TryParse(Console.ReadLine(), out int itemId))
                {
                    if (itemId == 0)//「0」が選ばれたら買い物を終了
                    {
                        continueShopping = false;
                        Console.WriteLine("買い物を終了します。");
                    }
                    else
                    {
                        var selectedItem = itemList.Find(i => i.Id == itemId);

                        if (selectedItem != null) // 選択されたアイテムが有効なら
                        {
                            if (money >= selectedItem.Price)// 所持金が足りている場合
                            {
                                money -= selectedItem.Price;
                                Console.WriteLine($"{selectedItem.Name}を購入しました。");

                                // 購入履歴に追加または更新
                                if (purchaseHistory.ContainsKey(selectedItem))
                                {
                                    purchaseHistory[selectedItem]++; // 既に購入したアイテムなら個数を増やす
                                }
                                else
                                {
                                    purchaseHistory[selectedItem] = 1;// 初めて購入するアイテムを追加
                                }

                                // 所持アイテムの表示
                                Console.WriteLine("現在の所持アイテム:");
                                foreach (var entry in purchaseHistory)
                                {
                                    Console.WriteLine($"{entry.Key.Name}: {entry.Value}個");
                                }
                                
                            }
                            else
                            {
                                Console.WriteLine("所持金が足りません。");// 所持金が足りない場合の表示
                            }
                        }
                        
                        else
                        {
                            Console.WriteLine("無効なアイテムです。もう一度選んでください。");// 無効な選択肢の場合の表示
                        }
                    }
                }
                else
                {
                    Console.WriteLine("無効な入力です。数字を入力してください。");// 入力が数値でない場合の表示
                }

                //Enterキーの続行
                Console.WriteLine("Enterキーを押して続行...");
                Console.ReadLine();
            }

            Console.Clear();//画面クリア
            Console.WriteLine("買い物が終了しました。所持金がなくなったか、買い物を終了しました。");


            // 購入履歴の表示
            if (purchaseHistory.Count > 0)
            {
                Console.WriteLine("購入したアイテム:");
                foreach (var entry in purchaseHistory)
                {
                    Console.WriteLine($"{entry.Key.Name}: {entry.Value}個");
                }
            }
            else
            {
                Console.WriteLine("アイテムは購入されませんでした。");//アイテムが購入されなかった場合の表示
            }
        }
    }
    
}
