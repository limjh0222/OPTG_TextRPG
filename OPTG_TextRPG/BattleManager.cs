using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace OPTG_TextRPG
{
    public class BattleManager
    {
        List<MonsterData> monsterAppeared = new List<MonsterData>();
        DungeonEvent dungeonEvent = new DungeonEvent();
        DungeonManager dungeonManager = new DungeonManager();
        Random random = new Random();
        PlayerData player;

        public BattleManager() { }
        
        public void BattleStart()
        {
            bool isExit = false;
            dungeonEvent.FootPrint();
            player = GameManager.Instance.player; //참조
            monsterAppeared = dungeonManager.SpawnMonster();
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"\nBattle start!!");
                Console.WriteLine($"스테이지[{dungeonManager.stage}]\n");
                foreach (var monster in monsterAppeared)
                {
                    Console.WriteLine($"Lv.{monster.Lv} {monster.Name} HP {monster.Hp}");
                }
                Console.WriteLine("\n[내정보]");
                Console.WriteLine($"Lv.{player.Level} {player.Name} {player.Job}");
                Console.WriteLine($"HP {player.Hp}/{player.MaxHp}\n");
                Console.WriteLine("1. 공격\n");
                Console.Write(">> ");
                string input = Console.ReadLine();
                int attackChoice;
                if (int.TryParse(input, out attackChoice) && attackChoice == 1)
                {
                    isExit = Fight();
                    if(isExit)
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(500);
                    continue;
                }
            }
        }

        public bool Fight()
        {

            int initialPlayerHp = player.Hp;

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"\nBattle start!!");
                Console.WriteLine($"스테이지[{dungeonManager.stage}]\n");
                for (int i = 0; i < monsterAppeared.Count; i++)
                {
                    MonsterData monster = monsterAppeared[i];
                    Console.WriteLine($"[{i + 1}] Lv.{monster.Lv} {monster.Name} HP {(monster.IsDead ? "Dead" : monster.Hp.ToString())}");
                }
                Console.WriteLine("\n[내정보]");
                Console.WriteLine($"Lv.{player.Level} {player.Name} {player.Job}");
                Console.WriteLine($"HP {player.Hp}/{player.MaxHp}\n");
                Console.WriteLine("0. 취소\n");
                Console.Write(">> ");
                string input = Console.ReadLine();
                int fightChoice;
                if (int.TryParse(input,out fightChoice))
                {
                    if (fightChoice == 0)
                    {
                        break;
                    }
                    else if((fightChoice <= 0 || fightChoice > monsterAppeared.Count))
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        Thread.Sleep(400);
                        continue;
                    }
                }

                MonsterData selectedMonster = monsterAppeared[fightChoice - 1];

                if (selectedMonster.IsDead)
                {
                    Console.WriteLine("죽은 몬스터 입니다.");
                    Thread.Sleep(400);
                    continue;
                }
                PlayerTurn(selectedMonster);
                if (monsterAppeared.All(monster => monster.IsDead))
                {
                    Console.Clear();
                    Console.WriteLine("\nBattle!! - Result\n");
                    Console.WriteLine("Victory\n");
                    Console.WriteLine($"던전에서 몬스터를 {monsterAppeared.Count}마리를 잡았습니다.\n");
                    Console.WriteLine($"Lv.{player.Level} {player.Name}");
                    Console.WriteLine($"HP {initialPlayerHp} -> {player.Hp}\n");
                    Console.WriteLine("눈 앞에 올라갈 수 있는 계단이 보인다. 어떻게 할까?\n");
                    Console.WriteLine("1. 새로운 모험을 위해 올라간다.");
                    Console.WriteLine("0. 포기하고 마을로 돌아간다.\n");
                    Console.Write(">> ");
                    string nextInput = Console.ReadLine();
                    switch (nextInput)
                    {
                        case "1":
                            dungeonEvent.FootPrint();
                            int dungeonEventChance = random.Next(1, 101);
                            if (dungeonEventChance <= 20)
                            {
                                dungeonEvent.DungeonBox();
                                dungeonManager.NextStage();
                                monsterAppeared = dungeonManager.SpawnMonster();
                                continue;
                            }
                            else if (dungeonEventChance > 20 && dungeonEventChance <= 40)
                            {
                                dungeonEvent.DungeonSanctuary();
                                dungeonManager.NextStage();
                                monsterAppeared = dungeonManager.SpawnMonster();
                                continue;
                            }
                            else
                            {
                                dungeonManager.NextStage();
                                monsterAppeared = dungeonManager.SpawnMonster();
                                continue;
                            }
                        case "0":
                            return true;
                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            Thread.Sleep(400);
                            break;
                    }
                }
                Console.WriteLine("1. 다음\n");
                Console.Write(">> ");
                while (!int.TryParse(Console.ReadLine(),out fightChoice) || fightChoice != 1)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(400);
                    Console.SetCursorPosition(0, Console.CursorTop - 2);
                    Console.WriteLine("                                                  ");
                    Console.WriteLine("                                                  ");
                    Console.SetCursorPosition(0, Console.CursorTop - 2);
                    Console.Write(">> ");
                }
                MonstersTurn();

                int remainingPlayerHp = player.Hp; // 전투 종료 후 플레이어 체력 기록
                int lostHp = initialPlayerHp - remainingPlayerHp; // 손실된 체력 계산

                if (player.Hp <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("\nBattle!! - Result\n");
                    Console.WriteLine("You Lose\n");
                    Console.WriteLine($"Lv.{player.Level} {player.Name}");
                    Console.WriteLine($"HP {initialPlayerHp} -> {player.Hp}\n");
                    Console.WriteLine("눈앞이 캄캄하다. 여기서 죽는걸까..?");
                    Console.WriteLine(">> Press any key...\n");
                    Console.Write(">> ");
                    Console.ReadLine();
                    return true;
                }
            }
            return false;
        }
        
        public void PlayerTurn(MonsterData selectedMonster)
        {
            Console.Clear();
            Console.WriteLine($"\nBattle start!!");
            Console.WriteLine($"\n{player.Name} 의 공격!");
            int playerAttack = PlayerAttack();
            float currentMonsterHp = selectedMonster.Hp;
            DamageMonster(selectedMonster, playerAttack);
            Console.WriteLine($"Lv.{selectedMonster.Lv} {selectedMonster.Name} 을(를) [데미지 : {playerAttack}]\n");
            Console.WriteLine($"Lv.{selectedMonster.Lv} {selectedMonster.Name}");
            Console.ResetColor(); // 색상 초기화

            if (selectedMonster.Hp <= 0)
            {
                selectedMonster.Hp = 0;
                selectedMonster.IsDead = true;
                Console.WriteLine($"HP {currentMonsterHp} -> {(selectedMonster.IsDead ? "Dead" : selectedMonster.Hp.ToString())}\n");
            }
            else
            {
                Console.WriteLine($"HP {currentMonsterHp} -> {(selectedMonster.IsDead ? "Dead" : selectedMonster.Hp.ToString())}\n");
            }
        }

        public void MonstersTurn()
        {
            foreach (MonsterData monster in monsterAppeared)
            {
                if (!monster.IsDead)
                {
                    Console.Clear();
                    Console.WriteLine($"\nBattle start!!");
                    Console.WriteLine($"\nLv.{monster.Lv} {monster.Name} 의 공격!");
                    int currentPlayerHp = player.Hp;
                    DamagerPlayer(player, monster.Atk);
                    Console.WriteLine($"{player.Name} 을(를) 맞췄습니다. [데미지 : {monster.Atk}]\n");
                    Console.WriteLine($"Lv.{player.Level} {player.Name}");
                    Console.WriteLine($"HP {currentPlayerHp} -> {player.Hp}\n");
                    Console.WriteLine("1. 다음\n");
                    Console.Write(">> ");
                    while (!int.TryParse(Console.ReadLine(), out int fightChoice) || fightChoice != 1)
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        Thread.Sleep(400);
                        Console.SetCursorPosition(0, Console.CursorTop - 2);
                        Console.WriteLine("                                                  ");
                        Console.WriteLine("                                                  ");
                        Console.SetCursorPosition(0, Console.CursorTop - 2);
                        Console.Write(">> ");
                    }
                    if (player.Hp <= 0)
                    {
                        return;
                    }

                }
            }
        }

        private int PlayerAttack()
        {
            float attack = player.Atk;
            double minAttack = attack * 0.9;
            double maxAttack = attack * 1.1;
            return (int)Math.Ceiling(new Random().NextDouble() * (maxAttack - minAttack) + minAttack);

        }

        private void DamageMonster(MonsterData monster,int Damage)
        {
            monster.Hp -= Damage;

            // HP가 0 이하로 떨어진 경우, 0으로 설정
            if (monster.Hp <= 0)
            {
                monster.Hp = 0;
                monster.IsDead = true;
            }
        }

        private void DamagerPlayer(PlayerData player,int Damage)
        {
            player.Hp -= Damage;

            // HP가 0 이하로 떨어진 경우, 0으로 설정
            if (player.Hp < 0)
            {
                player.Hp = 0;
            }
        }
    }
}
