﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace OPTG_TextRPG
{
    public class DungeonEvent
    {
        List<Item> itemDB;
        private GameManager gameManager;
        Random random = new Random();

        string input;

        public DungeonEvent() { }
        public DungeonEvent(GameManager Manager)
        {
            gameManager = Manager;
        }
        public Item Randomitem()
        {
            itemDB = DataManager.Instance.ItemDB;
            return itemDB[random.Next(DataManager.Instance.ItemDB.Count)];
        }

        public void DungeonBox()
        {
            Console.Clear();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n앗! 수상해보이는 낡은 상자를 발견했다!\n");
                Console.WriteLine("상자를 살펴보니 자물쇠로 잠겨 있지만");
                Console.WriteLine("많이 낡아있어서 쉽게 열릴것만 같다.\n");
                Console.WriteLine("상자를 열어볼까?\n");
                Console.WriteLine("1. 조심스럽게 열어본다.");
                Console.WriteLine("0. 무서우니까 돌아간다.");
                Console.Write(">> ");

                string input = Console.ReadLine();
                if (int.TryParse(input, out int Select))
                {
                    int probability = random.Next(1, 101);
                    switch (Select)
                    {
                        case 0:
                            FootPrint();
                            return;
                        case 1:
                            if (probability <= 50)
                            {
                                if (probability <= 20)
                                {
                                    //인벤토리에 생성된 아이템을 넣음
                                    Item newItem = Randomitem();
                                    GameManager.Instance.inventory.Add(newItem);
                                    Console.WriteLine("\n쓸만해 보이는 물건이 들어있다.");
                                    Console.WriteLine($"[{newItem.Name}]을(를) 획득했다!");
                                    Console.WriteLine("\n1. 다음\n");
                                    Console.Write(">> ");
                                    while (!int.TryParse(Console.ReadLine(), out int fightChoice) || fightChoice != 1)
                                    {
                                        ConsoleUtility.PrintColor(Color.RED, "잘못된 입력입니다.");
                                        Thread.Sleep(400);
                                        Console.SetCursorPosition(0, Console.CursorTop - 2);
                                        Console.WriteLine("                                                  ");
                                        Console.WriteLine("                                                  ");
                                        Console.SetCursorPosition(0, Console.CursorTop - 2);
                                        Console.Write(">> ");
                                    }
                                }
                                else if (probability > 20 && probability <= 50)
                                {
                                    GameManager.Instance.player.Hp += 50;
                                    GameManager.Instance.player.Mp += 50;
                                    Console.WriteLine("\n몸에서 알수없는 기운이 느껴진다.");
                                    Console.WriteLine("체력과 마력이 [50 회복] 되었다!");
                                    Console.WriteLine("\n1. 다음\n");
                                    Console.Write(">> ");
                                    while (!int.TryParse(Console.ReadLine(), out int fightChoice) || fightChoice != 1)
                                    {
                                        ConsoleUtility.PrintColor(Color.RED, "잘못된 입력입니다.");
                                        Thread.Sleep(400);
                                        Console.SetCursorPosition(0, Console.CursorTop - 2);
                                        Console.WriteLine("                                                  ");
                                        Console.WriteLine("                                                  ");
                                        Console.SetCursorPosition(0, Console.CursorTop - 2);
                                        Console.Write(">> ");
                                    }
                                }
                                else
                                {
                                    GameManager.Instance.player.Hp -= 15;
                                    Console.WriteLine("\n앗! 상자속에서 함정이 튀어나왔다!");
                                    Console.WriteLine("HP가 [-15 감소] 했다!");
                                    Console.WriteLine("\n1. 다음\n");
                                    Console.Write(">> ");
                                    while (!int.TryParse(Console.ReadLine(), out int fightChoice) || fightChoice != 1)
                                    {
                                        ConsoleUtility.PrintColor(Color.RED, "잘못된 입력입니다.");
                                        Thread.Sleep(400);
                                        Console.SetCursorPosition(0, Console.CursorTop - 2);
                                        Console.WriteLine("                                                  ");
                                        Console.WriteLine("                                                  ");
                                        Console.SetCursorPosition(0, Console.CursorTop - 2);
                                        Console.Write(">> ");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("\n이런! 상자가 부서져버렸다!");
                                Console.WriteLine("부서진 상자속에 아무것도 찾을 수 없었다.");
                                Console.WriteLine("\n1. 다음\n");
                                Console.Write(">> ");
                                while (!int.TryParse(Console.ReadLine(), out int fightChoice) || fightChoice != 1)
                                {
                                    ConsoleUtility.PrintColor(Color.RED, "잘못된 입력입니다.");
                                    Thread.Sleep(400);
                                    Console.SetCursorPosition(0, Console.CursorTop - 2);
                                    Console.WriteLine("                                                  ");
                                    Console.WriteLine("                                                  ");
                                    Console.SetCursorPosition(0, Console.CursorTop - 2);
                                    Console.Write(">> ");
                                }
                            }
                            FootPrint();
                            return;
                    }
                }
                ConsoleUtility.PrintColor(Color.RED, "잘못된 입력입니다.");
                Thread.Sleep(500);
            }
        }

        public void DungeonSanctuary()
        {
            Console.Clear();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n수상해 보이는 구조물을 발견했다!\n");
                Console.WriteLine("가까이 다가가니 낡은 여신상이 서있었다.");
                Console.WriteLine("여신상의 얼굴은 형태를 알아볼 수 없었고");
                Console.WriteLine("기묘한 기운만이 흘러나오고 있었다.\n");
                Console.WriteLine("어떻게 할까?\n");
                Console.WriteLine("1. 여신상에 손을 대본다.");
                Console.WriteLine("0. 불길하니 지나간다.");
                Console.Write(">> ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int Select))
                {
                    int probability = random.Next(1, 101);
                    switch (Select)
                    {
                        case 0:
                            FootPrint();
                            return;
                        case 1:
                            if (probability <= 50)
                            {
                                GameManager.Instance.player.Hp = GameManager.Instance.player.MaxHp;
                                GameManager.Instance.player.Mp = GameManager.Instance.player.MaxMp;
                                Console.WriteLine("\n여신상에서 따뜻한 기운이 느껴진다.");
                                Console.WriteLine("체력과 마력이 전부 회복되었다!!");
                                Console.WriteLine("\n1. 다음\n");
                                Console.Write(">> ");
                                while (!int.TryParse(Console.ReadLine(), out int fightChoice) || fightChoice != 1)
                                {
                                    ConsoleUtility.PrintColor(Color.RED, "잘못된 입력입니다.");
                                    Thread.Sleep(400);
                                    Console.SetCursorPosition(0, Console.CursorTop - 2);
                                    Console.WriteLine("                                                  ");
                                    Console.WriteLine("                                                  ");
                                    Console.SetCursorPosition(0, Console.CursorTop - 2);
                                    Console.Write(">> ");
                                }
                            }
                            else
                            {
                                GameManager.Instance.player.Hp -= 30;

                                if (GameManager.Instance.player.Hp < 0)
                                {
                                    GameManager.Instance.player.Hp = 0;
                                }
                                Console.WriteLine("\n여신상에서 불길한 기운이 느껴진다.");
                                Console.WriteLine("체력이 [-30 감소] 되었다!!");
                                Console.WriteLine("\n1. 다음\n");
                                Console.Write(">> ");
                                while (!int.TryParse(Console.ReadLine(), out int fightChoice) || fightChoice != 1)
                                {
                                    ConsoleUtility.PrintColor(Color.RED, "잘못된 입력입니다.");
                                    Thread.Sleep(400);
                                    Console.SetCursorPosition(0, Console.CursorTop - 2);
                                    Console.WriteLine("                                                  ");
                                    Console.WriteLine("                                                  ");
                                    Console.SetCursorPosition(0, Console.CursorTop - 2);
                                    Console.Write(">> ");
                                }
                            }
                            FootPrint();
                            return;

                    }    
                }
                ConsoleUtility.PrintColor(Color.RED, "잘못된 입력입니다.");
                Thread.Sleep(500);
            }

        }

        public void FootPrint()
        {
            Console.Clear();
            FootPrint1();
            FootPrint2();
            FootPrint3();
            Thread.Sleep(500);
            Console.Clear();
        }

        public void FootPrint1()
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
            Console.WriteLine("\t\t\t\t ==");
            Console.WriteLine("\t\t\t\t#@@#");
            Console.WriteLine("\t\t\t\t%@@@");
            Console.WriteLine("\t\t\t\t+@@@");
            Console.WriteLine("\t\t\t\t:@@*");
            Console.WriteLine("\t\t\t\t*@@");
            Console.WriteLine("\t\t\t\t@@@");
            Console.WriteLine("\t\t\t\t#%*");
            Thread.Sleep(300);
            Console.Clear();
        }
        public void FootPrint2()
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n\n");
            Console.WriteLine("\t\t\t  ==");
            Console.WriteLine("\t\t\t #@@+");
            Console.WriteLine("\t\t\t:@@@#.");
            Console.WriteLine("\t\t\t:@@@+");
            Console.WriteLine("\t\t\t #@@-");
            Console.WriteLine("\t\t\t -@@+");
            Console.WriteLine("\t\t\t -@@%");
            Console.WriteLine("\t\t\t  #@#\n");
            Console.WriteLine("\t\t\t\t ==");
            Console.WriteLine("\t\t\t\t#@@#");
            Console.WriteLine("\t\t\t\t%@@@");
            Console.WriteLine("\t\t\t\t+@@@");
            Console.WriteLine("\t\t\t\t:@@*");
            Console.WriteLine("\t\t\t\t*@@");
            Console.WriteLine("\t\t\t\t@@@");
            Console.WriteLine("\t\t\t\t#%*");
            Thread.Sleep(300);
            Console.Clear();
        }
        public void FootPrint3()
        {
            Console.WriteLine("\n\t\t\t\t ==");
            Console.WriteLine("\t\t\t\t#@@#");
            Console.WriteLine("\t\t\t\t%@@@");
            Console.WriteLine("\t\t\t\t+@@@");
            Console.WriteLine("\t\t\t\t:@@*");
            Console.WriteLine("\t\t\t\t*@@");
            Console.WriteLine("\t\t\t\t@@@");
            Console.WriteLine("\t\t\t\t#%*\n");
            Console.WriteLine("\t\t\t  ==");
            Console.WriteLine("\t\t\t #@@+");
            Console.WriteLine("\t\t\t:@@@#.");
            Console.WriteLine("\t\t\t:@@@+");
            Console.WriteLine("\t\t\t #@@-");
            Console.WriteLine("\t\t\t -@@+");
            Console.WriteLine("\t\t\t -@@%");
            Console.WriteLine("\t\t\t  #@#\n");
            Console.WriteLine("\t\t\t\t ==");
            Console.WriteLine("\t\t\t\t#@@#");
            Console.WriteLine("\t\t\t\t%@@@");
            Console.WriteLine("\t\t\t\t+@@@");
            Console.WriteLine("\t\t\t\t:@@*");
            Console.WriteLine("\t\t\t\t*@@");
            Console.WriteLine("\t\t\t\t@@@");
            Console.WriteLine("\t\t\t\t#%*");
        }

        public void Bonfire()
        {
            Console.WriteLine("\t                   .~");
            Console.WriteLine("\t                    :.");
            Console.WriteLine("\t                   .*=");
            Console.WriteLine("\t                *.=:!~*:=.*");
            Console.WriteLine("\t                   .=!");
            Console.WriteLine("\t                    ;!.");
            Console.WriteLine("\t                     ~=");
            Console.WriteLine("\t                     :=");
            Console.WriteLine("\t##   #  ###  ##  #   ;,     ####  #### #### ####");
            Console.WriteLine("\t##   # ##  # ##  #   ;*     ## ##  ##  ##   ## ##");
            Console.WriteLine("\t ## #  ##  # ##  #    *.    ##  #  ##  ##   ##  #");
            Console.WriteLine("\t  ##   ##  # ##  #    :     ##  #  ##  #### ##  #");
            Console.WriteLine("\t  ##   ##  # ##  #    ,.    ##  #  ##  ##   ##  #");
            Console.WriteLine("\t  ##   ##  # ##  #    !;    ## ##  ##  ##   ## ##");
            Console.WriteLine("\t  ##    ###   ###     :,    ####  #### #### ####");
            Console.WriteLine("\t                      -*.");
            Console.WriteLine("\t                      :*.");
            Console.WriteLine("\t                       ~");
            Console.WriteLine("\t                     . ,");
            Console.WriteLine("\t                          .");
            Console.WriteLine("\t                - ~    ,; , :!");
            Console.WriteLine("\t               ~ ~,  ;,,:;: :-!");
            Console.WriteLine("\t               ;!!*=*! .-.=:~==");
            Console.WriteLine("\t             ;.=**;, =-.  -,*** !");
            Console.WriteLine("\t             !**=*!!;:,, ,-;*!;**");
            Console.WriteLine("\t          :~!*=****!=!! .~;!;!!*!;:");
            Console.WriteLine("\t      ~~;!!!====*!!**=**!**=!==**!!;~:.");
            Console.WriteLine("\t  ::!****!*!***!***=*-***!;*!!*****!****;;");
            Console.WriteLine("\t  .-:===***======*!!=****!!=***********=:.");
            Console.WriteLine("\t     .-~===****=========****======***==.");
        }
    }
}

