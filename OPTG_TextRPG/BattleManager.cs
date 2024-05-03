using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OPTG_TextRPG
{
    public class BattleManager
    {
        List<MonsterData> monsters = new List<MonsterData>();
        DungeonEvent dungeonEvent = new DungeonEvent();
        DungeonManager stageDungeon = new DungeonManager();
        PlayerData player;
        MonsterData monster;
        public BattleManager()
        {

        }

        public void BatteleStart(PlayerData player)
        {
            int choice = -1;
            dungeonEvent.FootPrint();
            while (choice < 0)
            {
                Console.Clear();
                Console.WriteLine($"\nBattle start!!");
                Console.WriteLine($"스테이지[{stageDungeon.stage}]\n");
                List<MonsterData> monsters = stageDungeon.SpawnMonster();
                foreach (var monster in monsters)
                {
                    Console.WriteLine($"Lv.{monster.Lv} {monster.Name} HP {monster.Hp}");
                }
                Console.WriteLine("\n[내정보]");
                Console.WriteLine($"Lv.{player.Level} {player.Name} {player.Job}");
                Console.WriteLine($"HP {player.Hp}/{player.MaxHp}\n");
                Console.WriteLine("1. 공격\n");
                choice = ConsoleUtility.PromptMenuChoice(1, 1);
                switch (choice)
                {
                    case 1:
                        Fight(player);
                        break;
                }
                break;
            }
        }
        private void Fight(PlayerData player)
        {
            do
            {
                int monsterChoice;

                Console.Clear();
                Console.WriteLine($"\nBattle start!!");
                Console.WriteLine($"스테이지[{stageDungeon.stage}]\n");
                for (int i = 0; i < monsters.Count; i++)
                {
                    if (monsters[i].IsDead)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    Console.WriteLine($"[{i + 1}] Lv.{monsters[i].Lv} {monsters[i].Name}  HP {monsters[i].Hp} {(monsters[i].IsDead ? "[Dead]" : "")}");
                    Console.ResetColor();
                }
                Console.WriteLine("\n[내정보]");
                Console.WriteLine($"Lv.{player.Level} {player.Name} {player.Job}");
                Console.WriteLine($"HP {player.Hp}/{player.MaxHp}\n");
                Console.WriteLine("0. 취소\n");
                Console.WriteLine("대상을 선택해주세요.");
                Console.Write(">> ");
                monsterChoice = ConsoleUtility.PromptMenuChoice(0, 1);

                for (int index = 0; index < monsters.Count; index++)
                {
                    MonsterData battleMonster = monsters[index];
                    while (player.Hp > 0 && !battleMonster.IsDead)
                    {
                        do
                        {

                            PlayerTurn(player, monsterChoice);
                            MonstersTurn();
                        }
                        while (true);
                    }
                    if (player.Hp <= 0 || monsters.All(monster => monster.IsDead))
                        break;
                }
                if (player.Hp <= 0 || monsters.All(monster => monster.IsDead))
                    break;

            } while (true);
        }
   





        public void PlayerTurn(PlayerData player,int monsterChoice)
        {
            MonsterData selectedMonster = monsters[monsterChoice - 1];
            while (monsterChoice < 0 || monsterChoice > monsters.Count)
            {
                if (monsterChoice == 0) break;
                if (selectedMonster.IsDead)
                {
                    Console.WriteLine("죽은 몬스터를 선택하였습니다. 다시 선택하세요.");
                    Thread.Sleep(1000);
                    continue;
                }
            }
            Console.WriteLine($"{player.Name}의 공격!");
            int playerAttack = PlayerAttack(player);
            this.ApplyPlayerDamage(playerAttack);
            Console.WriteLine($"Lv.{monster.Lv} {monster.Name}에게 -{playerAttack}데미지!!");

            foreach (var monster in monsters)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($" Lv.{monster.Lv} {monster.Name}");
                Console.WriteLine($" HP {monster.Hp} -> Dead");
                Console.ResetColor();
            }
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
            if (monsters.All(monster => monster.IsDead)) ;
        }
        public void MonstersTurn()
        {
            foreach (MonsterData monster in monsters)
            {
                if (!monster.IsDead)
                {
                    Console.WriteLine($"{monster.Name}의 공격!");
                    this.ApplyMonstersDamage(monster.Atk);
                    Console.WriteLine($"{player.Name}에게 -{monster.Atk}데미지!!\n");
                    if (player.Hp <= 0) break;
                }
            }
        }
        private int PlayerAttack(PlayerData player)
        {
            float attack = player.Atk;
            double minAttack = attack * 0.9;
            double maxAttack = attack * 1.1;
            return (int)Math.Ceiling(new Random().NextDouble() * (maxAttack - minAttack) + minAttack);
        }
        private void ApplyPlayerDamage(int Damage)
        {
            monster.Hp -= Damage;

            // HP가 0 이하로 떨어진 경우, 0으로 설정
            if (monster.Hp < 0)
            {
                monster.Hp = 0;
            }
        }
        private void ApplyMonstersDamage(int Damage)
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
