using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGameTogether
{
    class MeetTheWitch
    {
        Player player = new Player();
        private int pos;
        private const int INVENTORY = -1;

        Room hauntedHouse = new Room();
        Room jungle = new Room();
        Room cave = new Room();
        Room nityaHouse = new Room();
        Room treeHouse = new Room();
        Room volcanoCore = new Room();
        Room cursedLake = new Room();
        Room heaven = new Room();

        Room[] map = new Room[6];

        Item[] items;

        public void makeRooms()
        {
            hauntedHouse.setName("Haunted house");
            jungle.setName("Jungle");
            cave.setName("Cave");
            nityaHouse.setName("Nitya's house");
            treeHouse.setName("Tree house");
            volcanoCore.setName("Core of a volcano");
            cursedLake.setName("Cursed Lake");

            hauntedHouse.setDesc("A hundred year old haunted, smelly place.");
            jungle.setDesc("A deep jungle with tall trees.");
            cave.setDesc("A dark cave with a small amount of light from the opening.");
            nityaHouse.setDesc("A small hut with barely any room for more than two people.");
            treeHouse.setDesc("A small tree house high above the ground where the witch stores his victims!");
            cursedLake.setDesc("A black lake which is cursed by the witch.");

            hauntedHouse.setExits(-1, -1, 1, -1); //get lamp
            jungle.setExits(-1, 4, -1, 0); // get ladder
            cave.setExits(1, -1, -1, -1); //combine lamp and matchstick //see new exit //get key
            nityaHouse.setExits(-1, -1, -1, 4); //must have key //get hat
            treeHouse.setExits(-1, -1, -1, 1); //must have ladder //get matchstick
            cursedLake.setExits(0, -1, 4, -1); //must combine lamp matchstick //get cape

            map[0] = hauntedHouse;
            map[1] = jungle;
            map[2] = treeHouse;
            map[3] = cursedLake;
            map[4] = cave;
            map[5] = nityaHouse;
        }

        public void Intro()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            string title = @"
                 ______  __ __    ___      __    __  ____  ______   __  __ __ 
                |      ||  |  |  /  _]    |  |__|  ||    ||      | /  ]|  |  |
                |      ||  |  | /  [_     |  |  |  | |  | |      |/  / |  |  |
                |_|  |_||  _  ||    _]    |  |  |  | |  | |_|  |_/  /  |  _  |
 __  __  __       |  |  |  |  ||   [_     |  `  '  | |  |   |  |/   \_ |  |  |
|  ||  ||  |      |  |  |  |  ||     |     \      /  |  |   |  |\     ||  |  |
|__||__||__|      |__|  |__|__||_____|      \_/\_/  |____|  |__| \____||__|__|                               
                                                                 ";
            Console.WriteLine(title);
        }

        public void setUpGame()
        {
           //Console.WindowHeight = Console.LargestWindowHeight - 30;
           //Console.WindowWidth = Console.LargestWindowWidth - 116;
           Console.Title = "... The Witch";

            pos = 0;
            player.setLoc(pos);

            Console.ForegroundColor = ConsoleColor.Cyan;

            String playerName;
            Console.Write("Enter in a name for your player: ");
            playerName = Console.ReadLine();

            player.setDesc("an old sketchy witch who is looking for some blood!!!");
            Console.Write("\n" + playerName + " is " + player.getDesc());
            Console.ReadLine();

            Console.WriteLine(playerName + " is currently in the haunted house. The goal is to complete your outfit by finding your cape, hat and broomstick.");
            howToPlay();
            Console.WriteLine("Press any key to continue!");
            Console.ReadKey();

            makeRooms();
            setUpItems();
        }

        public void howToPlay()
        {
            String howToPlay = "";
            howToPlay = @"Use N, E, S, W to move, T and D to take and drop items (make sure to take all items, you never know when you'll need them), C to combine, I to show inventory Q to quit and H to recall how to play!";
            Console.ForegroundColor = ConsoleColor.Gray;
            Typewrite(howToPlay);
            Console.ReadLine();
        }

        public void Typewrite(string message)
        {
            for (int i = 0; i < message.Length; i++)
            {
                Console.Write(message[i]);
                System.Threading.Thread.Sleep(60);
            }

        }

        public void setUpItems()
        {
            items = new Item[7]; //holds 6 items

            items[0] = new Item();
            items[0].setName("key");
            items[0].setDesc("a large old-fashioned brass");
            items[0].setLoc(4); //put into room 4

            items[1] = new Item();
            items[1].setName("lamp");
            items[1].setDesc("a old coal-oil");
            items[1].setLoc(0);

            items[2] = new Item();
            items[2].setName("broom");
            items[2].setDesc("a dusty stinky");
            items[2].setLoc(5);

            items[3] = new Item();
            items[3].setName("ladder");
            items[3].setDesc("a long wooden");
            items[3].setLoc(1);

            items[4] = new Item();
            items[4].setName("hat");
            items[4].setDesc("a concical crown with a wide brim");
            items[4].setLoc(4);

            items[5] = new Item();
            items[5].setName("matchstick");
            items[5].setDesc("a small");
            items[5].setLoc(2);

            items[6] = new Item();
            items[6].setName("cape");
            items[6].setDesc("a long red");
            items[6].setLoc(3);
        }
        public void win()
        {
            if (items[6].getLoc() == INVENTORY && items[4].getLoc() == INVENTORY && items[2].getLoc() == INVENTORY)
            {
                String win = "";
                win = @"Yay, you have successfully completed your journey!!";
                Console.ForegroundColor = ConsoleColor.DarkRed;
                //Console.WriteLine("Yay, you have successfully completed your journey!!");
                Typewrite(win);
                Console.ReadKey();
                quitGame();
            }
        }
        public void askForCommand()
        {
            win();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("What do you want to do? ");
            String command = Console.ReadLine().ToUpper();

            String[] commandList = command.Split(' ');

            doCommand(commandList);
        }

        public void doCommand(String[] s)
        {
            //Console.WriteLine("doCommand called");
            //s[0] holds the command
            //s[1] holds the 
            switch (s[0])
            {
                case "N":
                case "S":
                case "E":
                case "W": move(s[0]); break;
                case "L": look(); break;
                case "D": dropItem(s[1]); break;
                case "T": takeItem(s[1]); break;
                case "Q": quitGame(); break;
                case "C": combine(s[1] , s[2]); break;
                case "I": showInventory(); break;
                default:
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You can't do that."); break;
                    }
            }
            askForCommand();
        }

        public void move(string dir)
        {
            if (items[0].getLoc() == INVENTORY)
            {
                treeHouse.setExits(-1, 5, -1, 1);
                cave.setExits(1, -1, 5, -1);
            }

            if (items[3].getLoc() == INVENTORY)
            {
                jungle.setExits(-1, 4, 2, 0);
                nityaHouse.setExits(0, -1, -1, 4);
            }

            //if (pos == 5)
            //    items[0].setLoc(5);
            //if (pos == 2)
            //    items[3].setLoc(2);
            int newRoom = -1;

            switch (dir)
            {
                case "N": newRoom = map[pos].getN(); break;
                case "S": newRoom = map[pos].getS(); break;
                case "E": newRoom = map[pos].getE(); break;
                case "W": newRoom = map[pos].getW(); break;
                default:
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You can't go that way."); break;
                    }
            }
            
            if (newRoom != -1)
            {
                pos = newRoom;
                player.setLoc(pos);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You can't go that direction... no no no!");
            }
            look();
            if (pos == 2)
                items[3].setLoc(pos);
        }

        public void look()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nLocation: " + map[player.getLoc()].getName());
            Console.WriteLine("Description: " + map[player.getLoc()].getDesc());

            Console.WriteLine();

            checkForItems();
            showInventory();

            askForCommand();
        }

        public void combine(String item1,String item2)
        {
            item1 = item1.ToUpper();
            item2 = item2.ToUpper();

            switch (item1)
            {
                case "MATCHSTICK":
                    {
                        if (item2.Equals("LAMP"))
                        {
                            if (pos == 4)
                                lightLamp();
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("You can't do that!");
                            }
                        }
                    } break;
                case "LAMP":
                    {
                        if (item2.Equals("MATCHSTICK"))
                        {
                            if (pos == 4)
                                lightLamp();
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("You can't do that!");
                            }
                        }
                    } break;
                    
            }
        }

        public void lightLamp()
        {
            cave.setExits(1, -1, 5, 3);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("You can now see a new exit to the west!");
            items[5].setLoc(pos);
            items[1].setLoc(pos);
        }

        public void dropItem(String item)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].getName().ToUpper().Equals(item))
                    if (items[i].getLoc() == INVENTORY)
                    {
                        items[i].setLoc(player.getLoc());
                        Console.WriteLine(items[i].getName() + " dropped!");
                    }
            }
            showInventory();
            //askForCommand();
        }

        public void takeItem(String s)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].getName().ToUpper().Equals(s))
                    if (items[i].getLoc() == pos)
                    {
                        items[i].setLoc(INVENTORY);
                        Console.WriteLine(items[i].getName() + " took!");
                    }
            } Console.WriteLine();
            showInventory();
        }

        public void showInventory()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].getLoc() == INVENTORY)
                {
                    Console.WriteLine("Inventory: " + items[i].getDesc() + " " + items[i].getName());
                }
                
            }if(items[0].getLoc() != INVENTORY && items[1].getLoc() != INVENTORY && items[2].getLoc() != INVENTORY && items[3].getLoc() != INVENTORY && items[4].getLoc() != INVENTORY && items[5].getLoc() != INVENTORY && items[6].getLoc() != INVENTORY)
                {
                    Console.WriteLine("Inventory is empty!");
                }
            Console.WriteLine();
            //askForCommand();
        }

        public void quitGame()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Goodbyeee...come back again!!");
            Console.ReadKey();
            Environment.Exit(0);
        }

        public void checkForItems()
        {
            if (pos == 5)
                items[0].setLoc(5);
            if (pos == 2)
                items[3].setLoc(2);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            for (int i = 0; i < items.Length; i++)
            {
                if (pos == items[i].getLoc())
                {
                    Console.WriteLine("The room has " + items[i].getDesc() + " " + items[i].getName());
                }
            } //Console.WriteLine();
        }
    }
        

}
