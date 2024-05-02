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
    public class StageBattle
    {
        List<Monster> monsters = new List<Monster>();
        DungeonEvent dungeonEvent = new DungeonEvent();
        StageDungeon stageDungeon = new StageDungeon();
        Player player;
        Monster monster;
        public StageBattle()
        {

        }

        public void BatteleStart(Player player)
        {
            int choice = -1;
            dungeonEvent.FootPrint();
            while (choice < 0)
            {
                Console.Clear();
                Console.WriteLine($"\nBattle start!!");
                Console.WriteLine($"스테이지[{stageDungeon.stage}]\n");
                List<Monster> monsters = stageDungeon.SpawnMonster();
                foreach (var monster in monsters)
                {
                    Console.WriteLine($"Lv.{monster.Lv} {monster.Name} HP {monster.Hp}");
                }
                Console.WriteLine("\n[내정보]");
                Console.WriteLine($"Lv.{player.Level} {player.Name} {player.Job}");
                Console.WriteLine($"HP {player.Hp}/{player.MaxHp}\n");
                Console.WriteLine("1. 공격\n");
                choice = ConsoleUtility.PromptBattleChoice(1, 1);
                switch (choice)
                {
                    case 1:
                        Fight();
                        break;
                }
            }        
        }
        private void Fight()
        {
            Console.Clear();
            Console.WriteLine("기다려");
            Console.ReadLine();
        }
        





        private void PlayerTun()
        {
            Console.WriteLine($"{player.Name}의 공격!");
            int playerAttack = PlayerAttack(player);
            this.PlayerDamage(playerAttack);
            Console.WriteLine($"Lv.{monster.Lv} {monster.Name}에게 -{playerAttack}데미지!!");
            foreach (var monster in monsters)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($" Lv.{monster.Lv} {monster.Name}");
                Console.WriteLine($" HP {monster.Hp} -> Dead");
                Console.ResetColor();
            }
        }
        private void MonstersTun()
        {
            foreach (Monster monster in monsters)
            {
                if (!monster.IsDead)
                {
                    Console.WriteLine($"{monster.Name}의 공격!");
                    float monsterDamage = monster.MonsterAttack(monster.Atk);
                    this.MonstersDamage(monster.Atk);
                    Console.WriteLine($"{player.Name}에게 -{monster.Atk}데미지!!\n");
                }
            }
        }
        private int PlayerAttack(Player player)
        {
            float attack = player.Atk;
            double minAttack = attack * 0.9;
            double maxAttack = attack * 1.1;
            return (int)Math.Ceiling(new Random().NextDouble() * (maxAttack - minAttack) + minAttack);
        }
        private void PlayerDamage(int Damage)
        {
            monster.Hp -= Damage;

            // HP가 0 이하로 떨어진 경우, 0으로 설정
            if (monster.Hp < 0)
            {
                monster.Hp = 0;
            }
        }
        private void MonstersDamage(int Damage)
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
