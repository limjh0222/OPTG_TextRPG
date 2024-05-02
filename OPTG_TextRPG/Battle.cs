using OPTG_TextRPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Battle
{
    private List<Monster> monsters = new List<Monster>();
    private Dungeon dungeon;
    private Random random = new Random();
    private int stage;
    public Battle(Dungeon dungeon)
    {
        this.dungeon = dungeon;
        this.monsters = new List<Monster>();
    }

    public void StartDungeon(Player player)
    {
        dungeon.NextStage(); // 스테이지를 업데이트합니다.
        stage = dungeon.GetStage(); // 업데이트된 스테이지를 가져옵니다.

        monsters.Clear();

        if (stage % 5 == 0)
        {
            monsters.Add(dungeon.RandomBossMonster());
        }
        else
        {
            int numMonsters = random.Next(1, 5);
            for (int i = 0; i < numMonsters; i++)
            {
                Monster monster = dungeon.RandomNormalMonster();
                if (monster != null)
                {
                    monsters.Add(monster);
                }
            }
        }
        Console.Clear();

        Console.WriteLine("던전에 진입하였습니다!\n");
        Console.WriteLine($"Stage {stage}에 진입하였습니다!\n");

        Console.WriteLine("\n1. 전투 시작");
        Console.WriteLine("2. 던전 나가기");
        int choice = ConsoleUtility.PromptMenuChoice(1, 2);
        if (choice == 1)
        {
            do
            {
                for (int index = 0; index < monsters.Count; index++)
                {
                    Monster battleMonster = monsters[index];

                    while (player.Hp > 0 && !battleMonster.IsDead)
                    {
                        Console.Clear();
                        Console.WriteLine("**Battle!!**\n");

                        Console.WriteLine("몬스터 목록:");
                        for (int i = 0; i < monsters.Count; i++)
                        {
                            if (monsters[i].IsDead)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                            }
                            Console.WriteLine($"[{i + 1}] {monsters[i].Name} Lv.{monsters[i].Lv} HP {monsters[i].Hp} {(monsters[i].IsDead ? "Dead" : "")}");
                            Console.ResetColor();
                        }

                        Console.WriteLine("\n[내정보]");
                        Console.WriteLine($"{player.Name} Lv.{player.Level} ({player.Job})");
                        Console.WriteLine($"HP {player.MaxHp}/{player.Hp}\n");

                        Console.WriteLine("0. 취소\n");

                        Console.WriteLine("대상을 선택해주세요.");
                        int monsterChoice = ConsoleUtility.PromptMenuChoice(0, monsters.Count);

                        if (monsterChoice == 0)
                            break;

                        Monster selectedMonster = monsters[monsterChoice - 1];

                        if (selectedMonster.IsDead)
                        {
                            Console.WriteLine("죽은 몬스터를 선택하였습니다. 다시 선택하세요.");
                            Thread.Sleep(1000); // 1초 딜레이
                            continue;
                        }

                        Console.WriteLine();
                        Console.WriteLine($"{player.Name}의 공격!");
                        float damage = Player.PlayerAttack(player.Atk);
                        selectedMonster.Hp -= (int)Math.Floor(damage);

                        Console.WriteLine($"{selectedMonster.Name}을(를) 맞췄습니다. [데미지 : {(int)Math.Floor(damage)}]");

                        if (selectedMonster.Hp <= 0)
                        {
                            selectedMonster.Hp = 0;
                            selectedMonster.IsDead = true;
                            Console.WriteLine($"{selectedMonster.Name}을(를) 처치했습니다!\n");
                        }
                        else
                        {
                            Console.WriteLine($"{selectedMonster.Name}\nHP {selectedMonster.Hp} -> {(selectedMonster.IsDead ? "Dead" : selectedMonster.Hp.ToString())}\n");
                        }

                        Console.WriteLine("\n0. 다음");
                        ConsoleUtility.PromptMenuChoice(0, 0);

                        if (monsters.All(monster => monster.IsDead))
                            break;

                        // 몬스터가 플레이어를 공격
                        foreach (Monster monster in monsters)
                        {
                            if (!monster.IsDead)
                            {
                                Console.WriteLine($"{monster.Name}의 공격!");
                                float monsterDamage = Monster.MonsterAttack(monster.Atk);
                                player.Hp -= (int)Math.Floor(monsterDamage);

                                Console.WriteLine($"{monster.Name}이(가) {player.Name}을(를) 공격했습니다. [데미지 : {(int)Math.Floor(monsterDamage)}]\n");
                                Thread.Sleep(1000); // 1초 딜레이
                                Console.WriteLine($"{player.Name}\nHP {player.Hp} -> {(player.Hp > 0 ? player.Hp.ToString() : "Dead")}\n");

                                if (player.Hp <= 0)
                                {
                                    Console.WriteLine("0. 다음");
                                    ConsoleUtility.PromptMenuChoice(0, 0);
                                    break;
                                }
                            }
                        }

                        if (player.Hp <= 0)
                            break;
                    }

                    if (player.Hp <= 0 || monsters.All(monster => monster.IsDead))
                        break;
                }

                if (player.Hp <= 0 || monsters.All(monster => monster.IsDead))
                    break;

            } while (true);

            if (player.Hp > 0)
            {
                Console.Clear();
                Console.WriteLine("**Battle!! - Result**\n");
                Console.WriteLine("**Victory**\n");
                Console.WriteLine($"던전에서 모든 몬스터를 잡았습니다.\n");
                Console.WriteLine($"{player.Name}\nHP {player.MaxHp} -> {player.Hp}\n");

                Console.WriteLine("\n0. 다음");

                return;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("**Battle!! - Result**\n");
                Console.WriteLine("**You Lose**\n");
                Console.WriteLine($"{player.Name}\nHP {player.MaxHp} -> 0\n");

                Console.WriteLine("\n0. 다음");
                ConsoleUtility.PromptMenuChoice(0, 0);
            }
        }
        else
        {
            // 던전 나가기
        }
    }
}
