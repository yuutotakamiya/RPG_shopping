using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_shopping
{
    internal class Item
    {
        /// <summary>
        ///  アイテムのIDを管理するフィールド
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// アイテムの名前管理するフィールド
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 価格を管理するフィールド
        /// </summary>
        public int Price { get; set; }

        public Item(int id, string name, int price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
