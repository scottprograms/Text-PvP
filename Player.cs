using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Player
    {
        private string name;
        private int health;
        private int damage;
        private Item[] inventory;

        private Item _longSword;
        private Item _dagger;

        public Player()
        {
            inventory = new Item[3];
            damage = 25;
            health = 100;

        }
        public Player(string name, int valHealth, int valDamage, int inventorySize)
        {
            damage = 25;
            health = 100;
            inventory = new Item[inventorySize];
        }
        public void AddItemToInventory(Item item, int index)
        {
            inventory[index] = item;
        }
        public void EqupiItem(int itemIndex)
        {
            damage = inventory[itemIndex].statBoost;
        }
        






    }
}