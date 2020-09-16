using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    //Create a turn based PvP game. It should have a battle loop where both players
    //must fight until one is dead. The game should allow players to upgrade their stats
    //using items. Both players and items should be defined as structs. 


    struct Item
    {
        public int statBoost;
    }


    class Game
    {
        bool _gameOver = false;
        Player _player1;
        Player _player2;
        Item longSword;
        Item dagger;

        //Run the game
        public void Run()
        {
            _player1 = new Player();
            Start();

            while(_gameOver == false)
            {
                Update();
            }

            End();

        }
        public Player CreateCharacter()
        {
            Console.WriteLine("What do you go by?");
            string name = Console.ReadLine();
            Player player = new Player(name, 100,  25);
            SelectItems(player);
           return player;
        }     
        

       
        

        public void InitializeItems()
        {
            longSword.statBoost = 15;
            dagger.statBoost = 10;
        }

        //Displays two options to the player. Outputs the choice of the two options
        public void GetInput(out char input, string option1, string option2, string query)
        {
            //Print description to console
            Console.WriteLine(query);
            //print options to console
            Console.WriteLine("1." + option1);
            Console.WriteLine("2." + option2);
            Console.Write("> ");

            input = ' ';
            //loop until valid input is received
            while (input != '1' && input != '2')
            {
                input = Console.ReadKey().KeyChar;
                if(input != '1' && input != '2')
                {
                    Console.WriteLine("Invalid Input");
                }
            }
        }

        //Equip items to both players in the beginning of the game
        public void SelectItems(Player player)
        {
            //Get input for player one
            char input;
            GetInput(out input, "Longsword", "Dagger", "Welcome! Player one please choose a weapon.");
            //Equip item based on input value
            if (input == '1')
            {
                player.AddItemToInventory(longSword,0);
            }
            else if (input == '2')
            {
                player.AddItemToInventory(dagger,0);
            }
            Console.WriteLine("Player 1");
            PrintStats(_player1);

           
        }

        public void ClearScreen()
        {
            Console.WriteLine("Press any key to continue");
            Console.Write("> ");
            Console.ReadKey();
            Console.Clear();
        }

        public void StartBattle()
        {
            ClearScreen();
            Console.WriteLine("Now GO!");

            while(_player1.health > 0 && _player2.health > 0)
            {
                //print player stats to console
                Console.WriteLine("Player1");
                PrintStats(_player1);
                Console.WriteLine("Player2");
                PrintStats(_player2);
                //Player 1 turn start
                //Get player input
                char input;
                GetInput(out input, "Attack", "NO", "Your turn Player 1");

                if(input == '1')
                {
                    _player2.health -= _player1.damage;
                    Console.WriteLine("Player 2 took " + _player1.damage + " damage!");
                }
                else
                {
                    Console.WriteLine("NO!!!!!");
                }

                GetInput(out input, "Attack", "NO", "Your turn Player 2");

                if (input == '1')
                {
                    _player1.health -= _player2.damage;
                    Console.WriteLine("Player 1 took " + _player2.damage + " damage!");
                }
                else
                {
                    Console.WriteLine("NO!!!!!");
                }
                Console.Clear();
            }
            if(_player1.health > 0)
            {
                Console.WriteLine("Player 1 wins!!1!1!!11!11?");
            }
            else
            {
                Console.WriteLine("Player 2 wins??????????");
            }
            ClearScreen();
            _gameOver = true;
        }


        //Prints players stats to the console
        public void PrintStats(Player player)
        {
            Console.WriteLine("Health: " + player.health);
            Console.WriteLine("Damage: " + player.damage);
        }

        //Performed once when the game begins
        public void Start()
        {
            InitializeItems();
        }

        //Repeated until the game ends
        public void Update()
        {
            SelectItems();
            StartBattle();
        }

        //Performed once when the game ends
        public void End()
        {
            
        }
    }
}
