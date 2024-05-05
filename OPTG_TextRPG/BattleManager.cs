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
        int initialPlayerHp;

        public BattleManager() { }
        
        public void BattleStart()
        {
            bool isExit = false;
            dungeonEvent.FootPrint();
            player = GameManager.Instance.player; //참조
            monsterAppeared = dungeonManager.SpawnMonster();
            //dungeonManager.stage = 1; 던전 초기화 트리거
            initialPlayerHp = player.Hp;
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"\nBattle start!!");
                Console.WriteLine($"스테이지[{dungeonManager.stage}]\n");
                foreach (var monster in monsterAppeared)
                {
                    Console.WriteLine($"Lv.{monster.Lv} {monster.Name} HP {(monster.IsDead ? "Dead" : monster.Hp.ToString())}");
                }
                Console.WriteLine("\n[내정보]");
                Console.WriteLine($"Lv.{player.Level} {player.Name} {player.Job}");
                Console.WriteLine($"HP {player.Hp}/{player.MaxHp}\n");
                Console.WriteLine("1. 공격");
                Console.WriteLine("2. 스킬\n");
                Console.Write(">> ");
                string input = Console.ReadLine();
                int attackChoice;
                if (int.TryParse(input, out attackChoice) && (attackChoice == 1 || attackChoice == 2))
                {
                    isExit = Fight(attackChoice);
                    if (isExit)
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

        public bool Fight(int attackChoice)
        {
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
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(400);
                    continue;
                }
                MonsterData selectedMonster = monsterAppeared[fightChoice - 1];

                if (selectedMonster.IsDead)
                {
                    Console.WriteLine("죽은 몬스터 입니다.");
                    Thread.Sleep(400);
                    continue;
                }

                bool isContinue = PlayerTurn(selectedMonster, attackChoice);
                if (!isContinue)
                {
                    return false;
                }

                if (monsterAppeared.All(monster => monster.IsDead))
                {

                    int remainingPlayerHp = player.Hp;

                    Console.WriteLine("1. 다음\n");
                    Console.Write(">> ");
                    while (!int.TryParse(Console.ReadLine(), out  fightChoice) || fightChoice != 1)
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        Thread.Sleep(400);
                        Console.SetCursorPosition(0, Console.CursorTop - 2);
                        Console.WriteLine("                                                  ");
                        Console.WriteLine("                                                  ");
                        Console.SetCursorPosition(0, Console.CursorTop - 2);
                        Console.Write(">> ");
                    }

                    Console.Clear();

                    Console.WriteLine("\nBattle!! - Result\n");
                    Console.WriteLine("Victory\n");
                    Console.WriteLine($"던전에서 몬스터를 {monsterAppeared.Count}마리를 잡았습니다.\n");
                    Console.WriteLine($"Lv.{player.Level} {player.Name}");
                    Console.WriteLine($"HP {initialPlayerHp} -> {remainingPlayerHp}\n");
                    Console.WriteLine("눈 앞에 올라갈 수 있는 계단이 보인다. 어떻게 할까?\n");
                    Console.WriteLine("1. 새로운 던전에 도전한다.");
                    Console.WriteLine("0. 포기하고 마을로 돌아간다.\n");
                    Console.Write(">> ");
                    string nextInput = Console.ReadLine();
                    switch (nextInput)
                    {
                        case "1":
                            dungeonEvent.FootPrint();
                            initialPlayerHp = player.Hp;
                            int dungeonEventChance = random.Next(1, 101);
                            if (dungeonEventChance <= 20)
                            {
                                dungeonEvent.DungeonBox();
                                dungeonManager.NextStage();
                                monsterAppeared = dungeonManager.SpawnMonster();
                                return false;
                            }
                            else if (dungeonEventChance > 20 && dungeonEventChance <= 40)
                            {
                                dungeonEvent.DungeonSanctuary();
                                dungeonManager.NextStage();
                                monsterAppeared = dungeonManager.SpawnMonster();
                                return false;
                            }
                            else
                            {
                                dungeonManager.NextStage();
                                monsterAppeared = dungeonManager.SpawnMonster();
                                return false;
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

                if (player.Hp <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("\nBattle!! - Result\n");
                    Console.WriteLine("You Lose\n");
                    Console.WriteLine($"Lv.{player.Level} {player.Name}");
                    Console.WriteLine($"HP {initialPlayerHp} -> {player.Hp}\n");
                    Console.WriteLine("눈앞이 캄캄하다. 여기서 죽는걸까..?");
                    Console.WriteLine("\tPress any key...\n");
                    Console.ReadKey();
                    Console.Clear();
                    dungeonEvent.Bonfire();
                    Thread.Sleep(2000);
                    return true;
                }
                return false;
            }
            return false;
        }

        public bool PlayerTurn(MonsterData selectedMonster,int isSkillFight)
        {
            int playerAttack;
            Console.Clear();
            Console.WriteLine($"\n========== {player.Name}의 턴 ==========");

            if(isSkillFight == 2)
            {
                playerAttack = PlayerSkillAttack(); //함수이름(인자)
                if(playerAttack == -1)
                {
                    return false;
                }
            }
                
            else
                playerAttack = PlayerBaseAttack();

            float currentMonsterHp = selectedMonster.Hp;
            DamageMonster(selectedMonster, playerAttack);
            Console.WriteLine($"\nLv.{selectedMonster.Lv} {selectedMonster.Name} 을(를) 맞췄습니다! [데미지 : {playerAttack}]\n");
            Console.WriteLine($"Lv.{selectedMonster.Lv} {selectedMonster.Name}");

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
            return true;
        }

        public void MonstersTurn()
        {
            Console.Clear();
            Console.WriteLine($"\n========== 몬스터 턴 ==========");
            foreach (MonsterData monster in monsterAppeared)
            {
                if (!monster.IsDead)
                {
                    Console.WriteLine($"\nLv.{monster.Lv} {monster.Name} 의 공격!");
                    int currentPlayerHp = player.Hp;
                    int monsterActualAttack = monster.Atk - (int)(player.Def * 0.5);
                    if (monsterActualAttack < 0)
                    {
                        monsterActualAttack = 0;
                    }

                    DamagerPlayer(player, monsterActualAttack);

                    Console.WriteLine($"{player.Name} 을(를) 맞췄습니다. [데미지 : {monsterActualAttack}]\n");
                    Console.WriteLine($"Lv.{player.Level} {player.Name}");
                    Console.WriteLine($"HP {currentPlayerHp} -> {player.Hp}\n");
                    Thread.Sleep(300);
                    if (player.Hp <= 0)
                    {
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
                        return;
                    }
                }
            }
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
        }

        private int PlayerBaseAttack()
        {
            Console.WriteLine($"\n{player.Name} 의 공격!");
            float attack = player.Atk;
            double minAttack = attack * 0.9;
            double maxAttack = attack * 1.1;
            int hitRate = random.Next(1, 101);
            if (hitRate < 20)
            {
                Console.WriteLine("\n[ 약점 발견!! ]");
                return (int)(1.8 * Math.Ceiling(new Random().NextDouble() * (maxAttack - minAttack) + minAttack));
            }
            else if(hitRate >= 20 && hitRate < 30)
            {
                Console.WriteLine("\n[ 앗! 손이 미끄러졌다!! ]");
                return (int)(0.5 * Math.Ceiling(new Random().NextDouble() * (maxAttack - minAttack) + minAttack));
            }
            else
                return (int)Math.Ceiling(new Random().NextDouble() * (maxAttack - minAttack) + minAttack);
        }

        private int PlayerSkillAttack()
        {
            SkillData skill;

            Console.WriteLine("[스킬 목록]\n");
            foreach (var Skill in player.Skills)
            {
                Console.WriteLine($"{Skill.Key}. {Skill.Value.Name} 데미지: {Skill.Value.Damage}, [소모 MP: {Skill.Value.MpCost}]");
            }
            Console.WriteLine("\n스킬을 선택해주세요.\n");
            Console.WriteLine("0. 뒤로");
            Console.Write(">> ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int skillChoice))
                {
                    if (skillChoice == 0)
                        return -1;
                    else if (!player.Skills.ContainsKey(skillChoice))
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        Thread.Sleep(400);
                        Console.SetCursorPosition(0, Console.CursorTop - 2);
                        Console.WriteLine("                                                  ");
                        Console.WriteLine("                                                  ");
                        Console.SetCursorPosition(0, Console.CursorTop - 2);
                        Console.Write(">> ");
                        continue;
                    }
                    else
                    {
                        skill = player.Skills[skillChoice];
                        if (player.Mp < skill.MpCost)
                        {
                            Console.WriteLine("마나가 부족하여 스킬을 사용할 수 없습니다!");
                            Thread.Sleep(400);
                            return -1;
                        }
                        player.Mp -= skill.MpCost;
                        Console.Clear();
                        Console.WriteLine($"\n스킬! [{player.Name}]의 [{skill.Name}]!!");
                        return skill.Damage;
                    }

                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(400);
                    Console.SetCursorPosition(0, Console.CursorTop - 2);
                    Console.WriteLine("                                                  ");
                    Console.WriteLine("                                                  ");
                    Console.SetCursorPosition(0, Console.CursorTop - 2);
                    Console.Write(">> ");
                    continue;
                }
            }
        }

        private void DamageMonster(MonsterData monster, int Damage)
        {
            monster.Hp -= Damage;

            // HP가 0 이하로 떨어진 경우, 0으로 설정
            if (monster.Hp <= 0)
            {
                monster.Hp = 0;
                monster.IsDead = true;
            }
        }

        private void DamagerPlayer(PlayerData player, int Damage)
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


