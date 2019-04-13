using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figgle;
using System.Threading;
using System.Media;

namespace Zames_veka
{
    class Program
    {
        //Персонажи используемые в игре
        public static Enemy dvornyaga = new Enemy();
        public static Enemy bomj = new Enemy();
        public static Enemy gopnik = new Enemy();
        public static Player fighter = new Player();
        //Саундтрек играющий всю игру
        public static SoundPlayer track = new SoundPlayer(Properties.Resources._04_Stage_1___Monsters_in_My_House);
        //Саунтрек, играющий в случае победы
        public static SoundPlayer victoryTrack = new SoundPlayer(Properties.Resources.gendalf);
        //Саундтрек, играющий в случае смерти
        public static SoundPlayer dimon = new SoundPlayer(Properties.Resources.dimon);

        static void Main(string[] args)
        {

            startIntro();
            Game.chooseyourComplexity();
            Thread.Sleep(5000);
            Console.WriteLine("You walked in the forest and saw:");
            Thread.Sleep(3000);
            Console.WriteLine(Figgle.FiggleFonts.Standard.Render("                                 Dvornyaga"));
            Game.Fight(dvornyaga, fighter);
            //Проверка на смерть 1 персонажа
            if (dvornyaga.defeated == true)
            {
                Console.Clear();
                Console.WriteLine(Figgle.FiggleFonts.Standard.Render("                                          Victory!"));
                Thread.Sleep(3000);
                Console.Clear();
                Console.WriteLine("You went on walking and you saw:");
                Thread.Sleep(3000);
                Console.WriteLine(Figgle.FiggleFonts.Standard.Render("                                           Bomj"));
                Game.Fight(bomj, fighter);
                //Проверка на смерть 2 персонажа
                if (bomj.defeated == true)
                {
                    Console.Clear();
                    Console.WriteLine(Figgle.FiggleFonts.Standard.Render("                                          Victory!"));
                    Thread.Sleep(3000);
                    Console.Clear();
                    Console.WriteLine("You went home and you saw:");
                    Thread.Sleep(3000);
                    Console.WriteLine(Figgle.FiggleFonts.Standard.Render("                                       Gopnik"));
                    Game.Fight(gopnik, fighter);
                    //Проверка на смерть 3 персонажа

                    if (gopnik.defeated == true)
                    {
                        //Награда за победу
                        track.Stop();
                        victoryTrack.PlayLooping();
                        while (true)
                        {
                           Console.Clear();
                           Console.ForegroundColor = ConsoleColor.Red;
                           Console.WriteLine(Figgle.FiggleFonts.Standard.Render("                                          Victory!"));
                           Thread.Sleep(500);
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                           Console.WriteLine(Figgle.FiggleFonts.Standard.Render("                                          Victory!"));
                           Thread.Sleep(500);
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                           Console.WriteLine(Figgle.FiggleFonts.Standard.Render("                                          Victory!"));
                            Thread.Sleep(500);
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(Figgle.FiggleFonts.Standard.Render("                                          Victory!"));
                            Thread.Sleep(500);
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine(Figgle.FiggleFonts.Standard.Render("                                          Victory!"));
                            Thread.Sleep(500);
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(Figgle.FiggleFonts.Standard.Render("                                          Victory!"));
                            Thread.Sleep(500);
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine(Figgle.FiggleFonts.Standard.Render("                                          Victory!"));
                            Thread.Sleep(500);

                        }


                    }
                }
            }
            Console.ReadLine();
        }
        //Метод запускающий интро
        public static void startIntro()
        {
            
            System.Media.SoundPlayer introSound = new System.Media.SoundPlayer(Properties.Resources.Heart_Of_A_Coward___Shade__promusic_me_);
            introSound.Play();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                                             The company shitGames presents:");
            Thread.Sleep(4500);
            Console.WriteLine("                                            The best fighting, you ever seen ");
            Thread.Sleep(4500);
            Console.WriteLine("                                                     Are you ready? ");
            Thread.Sleep(2000);
            Console.WriteLine(Figgle.FiggleFonts.Standard.Render("                                 Zames veka"));
            Thread.Sleep(7000);
            //Проверка на нажатие enter. В случае если пользователь не выполнил условие, то его выкинут :)
            Console.WriteLine("                                               Press ENTER to start");
            string press = Console.ReadLine();
            if(press == "")
            {
                Game.pressedStart = true;
            }
            else
            {
                Console.WriteLine("Hey dude! You play not by the rules! Get out here!");
                Thread.Sleep(3000);
                Environment.Exit(0);
            }
        }
        public static class Game
        {
            //Наличие нажатой кнопки enter
            public static bool pressedStart = false;
            //Основной саундтрек будет играть во время игры в другом потоке
            public static Thread soundtracks = new Thread(Playlist);
            //Переменная нужная для обработки варианта атаки
            static string choice;

            public static void chooseyourComplexity()
            {
                if (pressedStart == true)
                {

                    bool choosedComplexity = false;
                    Console.Clear();
                    soundtracks.Start();
                    Console.WriteLine("So guy, let's start!");
                    Thread.Sleep(2000);
                    Console.WriteLine("Firstly you need to choose your complexity");
                    Thread.Sleep(1500);
                    Console.WriteLine("1.I'm too young to die\n2.Hurt me plenty\n3.Nightmare");
                    //Определение имен врагов
                    dvornyaga.name = "dvornyaga";
                    dvornyaga.HP = 50;
                    dvornyaga.constHp = 50;
                    bomj.name = "bomj";
                    bomj.HP = 75;
                    bomj.constHp = 75;
                    gopnik.name = "gopnik";
                    gopnik.HP = 100;
                    gopnik.constHp = 100;
                    //Далее идет непосредственно выбор сложности
                    choice = Console.ReadLine();
                    while (true)
                    {
                        if (choosedComplexity == false)
                        {
                            if (choice == "1")
                            {
                                fighter.maxatatckDamage = 45;
                                fighter.manaAddition = 30;                                
                                dvornyaga.manaAddition = 0;
                                dvornyaga.maxatatckDamage = 15;
                                gopnik.manaAddition = 15;
                                gopnik.maxatatckDamage = 25;
                                bomj.manaAddition = 10;
                                bomj.maxatatckDamage = 20;
                                choosedComplexity = true;
                                continue;
                            }
                            if (choice == "2")
                            {
                                fighter.maxatatckDamage = 30;
                                fighter.manaAddition = 20;
                                dvornyaga.manaAddition = 10;
                                dvornyaga.maxatatckDamage = 20;
                                gopnik.manaAddition = 20;
                                gopnik.maxatatckDamage = 30;
                                bomj.manaAddition = 15;
                                bomj.maxatatckDamage = 25;
                                choosedComplexity = true;
                                continue;
                            }
                            if (choice == "3")
                            {
                                fighter.maxatatckDamage = 15;
                                fighter.manaAddition = 10;
                                dvornyaga.manaAddition = 20;
                                dvornyaga.maxatatckDamage = 25;
                                gopnik.manaAddition = 25;
                                gopnik.maxatatckDamage = 35;
                                bomj.manaAddition = 20;
                                bomj.maxatatckDamage = 30;
                                choosedComplexity = true;
                                continue;
                            }
                            if (choice != "1" && choice != "2" && choice != "3")
                            {
                                Console.WriteLine("There is no complexity with this number");
                                choice = Console.ReadLine();
                                continue;
                            }
                        }
                        Console.WriteLine("Ok, you choosed your complexity");
                        Console.WriteLine("Now type the name of your fighter");
                        choice = Console.ReadLine();
                        fighter.name = choice;
                        Console.WriteLine($"Ok, the name of your fighter is {fighter.name} \nThe adventures are starting");
                        Thread.Sleep(3000);
                        Console.Clear();
                        break;
                    }

                }

            } 
            //Метод, играющий мелодию во втором потоке
            public static void Playlist()
            {                            
                track.PlayLooping(); 
            }
            public static void Fight(Enemy enemy, Player player)
            {
                startingofFight();
                refreshData(enemy,player);
                choice = Console.ReadLine();
                while (true)
                {
                    if(player.move == true && player.HP != 0 && player.HP > 0)
                    {                        
                        
                        
                        //Выбор 1 атаки
                        if (choice == "1")
                        {
                            player.Atack(enemy);
                            enemy.mana += enemy.manaAddition;
                            player.move = false;  
                            refreshData(enemy,player);                                                                                                     
                            continue;
                        }
                        //Выбор 1 атаки
                        if (choice == "2")
                        {
                            while (true)
                            {
                                if(player.mana >= 50)
                                {
                                    player.mana -= 50;
                                    enemy.HP -= 50;
                                    enemy.mana += enemy.manaAddition;
                                    player.move = false;  
                                    refreshData(enemy, player);                                                                                                            
                                    break;
                                    
                                }
                                else
                                {
                                    Console.WriteLine("Sorry, but you haven't got such a quantity of mana");                                   
                                    choice = Console.ReadLine();
                                    break;

                                }
                            }
                        }
                        //Выбор 1 атаки
                        if (choice == "3")
                        {
                            while (true)
                            {
                                if (player.mana >= 100)
                                {
                                    player.mana -= 100;
                                    enemy.HP -= enemy.HP;
                                    enemy.mana += enemy.manaAddition;
                                    player.move = false;
                                    refreshData(enemy, player);                                                                        
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Sorry, but you haven't got such a quantity of mana");                                   
                                    choice = Console.ReadLine();
                                    break;

                                }
                            }
                        }
                        
                        if(choice !="1" && choice != "2" && choice != "3")
                        {
                            
                            Console.WriteLine("There is no attack with this number");                            
                            choice = Console.ReadLine();
                            continue;
                        }

                    }
                    //В случае смерти игрока
                    if(player.HP <= 0)
                    {
                        Console.Clear();
                        Thread.Sleep(4000);
                        Console.WriteLine(Figgle.FiggleFonts.Standard.Render("                                  You lose!"));
                        track.Stop();
                        dimon.Play();
                        Thread.Sleep(13000);
                        track.Play();
                        enemy.mana = 0;
                        enemy.HP = enemy.constHp;
                        player.HP = 100;
                        player.mana = 0;
                        player.move = true;
                        refreshData(enemy, player);
                        continue;
                    }
                    if (player.move == false && enemy.HP != 0 && enemy.HP > 0)
                    {
                       
                        if(enemy.mana < 50 && enemy.mana < 100)
                        {
                            enemy.Atack(player);
                            player.mana += player.manaAddition;
                            player.move = true;
                            refreshData(enemy, player);
                            if(player.HP != 0 && player.HP > 0)
                            {
                              choice = Console.ReadLine();
                              continue;
                            }
                            else
                            {
                                continue;
                            }
                           
                        }
                        if(enemy.mana >= 50&&enemy.mana < 100)
                        {
                            enemy.mana -= 50;
                            player.HP -= 50;
                            player.mana += player.manaAddition;
                            player.move = true;
                            refreshData(enemy, player);
                            if (player.HP != 0 && player.HP > 0)
                            {
                                choice = Console.ReadLine();
                                continue;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        if(enemy.mana >= 100)
                        {
                            enemy.mana -= 100;
                            player.HP -= player.HP;
                            player.mana += player.manaAddition;
                            player.move = true;
                            refreshData(enemy, player);
                            if(player.HP != 0 && player.HP > 0)
                            {
                              choice = Console.ReadLine();
                              continue;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    if (enemy.HP <= 0 )
                    {
                        enemy.defeated = true;
                        player.mana = 0;
                        player.HP = 100;
                        player.move = true;
                        break;
                    }
                    
                }
            }
            static void refreshData(Enemy enemy,Player fighter)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{fighter.name}:{fighter.HP}");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"\t{fighter.name}'s mana:{fighter.mana}");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"\t\t{enemy.name}:{enemy.HP}");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"\t{enemy.name}'s mana:{enemy.mana}");
                
                if(fighter.move == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nYour attacks:\n1.Simple kick - needs 0 mana and it's quite simple. It damages your enemy form 0 to {fighter.maxatatckDamage}\n" +
                    $"2.Vertushka = needs 50 mana and damages your enemy from 0 to 50\n" +
                    $"3.Progib - needs 100 mana and your enemy will cry and suffer");

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine($"\nYour attacks:\n1.Simple kick - needs 0 mana and it's quite simple. It damages your enemy form 0 to {fighter.maxatatckDamage}\n" +
                    $"2.Vertushka = needs 50 mana and damages your enemy from 0 to 50\n" +
                    $"3.Progib - needs 100 mana and your enemy will cry and suffer");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Thread.Sleep(3000);

                }




            }
            static void startingofFight()
            {
                Thread.Sleep(3000);
                Console.Clear();
                Console.WriteLine(Figgle.FiggleFonts.Standard.Render("                                           Fight!"));
                Thread.Sleep(3000);
                Console.Clear();
            }
        }
    }
}
