using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OPTG_TextRPG
{
    public class StageBattle
    {
        List<Monster> monsters = new List<Monster>();
        Player player;
        Monster monster;
        StageDungeon StageDungeon;
        public StageBattle() { }
        public StageBattle(Player player, Monster monster)
        {
            this.player = player;
            this.monster = monster;
        }

        public void BatteleStart()
        {
            Console.WriteLine($"\nBattle start!! 현재 스테이지{StageDungeon.stage}");
            StageDungeon.SpawnMonster();
            Console.WriteLine("\n\n");
            Console.WriteLine("[내정보]");
            Console.WriteLine($"Lv.{player.Level} {player.Name} {player.Job}");
            Console.WriteLine($"HP {player.hp}/{player.MaxHp}\n");
            Console.WriteLine("1. 공격\n");
            int backchoice = ConsoleUtility.PromptMenuChoice(1, 1);
            switch (backchoice) { case 1: Fight(); break; }
        }

        public void Fight()
        {
            
        }

        public void PlayerTun()
        {
            int playerAttack = PlayerAttack(player);
            this.PlayerDamage(playerAttack);
            Console.WriteLine($"{player.Name}의 공격!");
            
            for (int i = 0; i < monsters.Count; i++)
            {
                if (monsters[i].IsDead)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
                Console.WriteLine($"[{i + 1}] {monsters[i].Name} Lv.{monsters[i].Lv} HP {monsters[i].Hp} {(monsters[i].IsDead ? "Dead" : "")}");
                Console.ResetColor();
            }
        }

        
        public void MonstersTun()
        {

        }

        private int PlayerAttack(Player player)
        {
            float attack = player.Atk;
            double minAttack = attack * 0.9;
            double maxAttack = attack * 1.1;
            return (int)Math.Ceiling(new Random().NextDouble() * (maxAttack - minAttack) + minAttack);
        }


        public void PlayerDamage(int Damage)
        {
            monster.Hp -= Damage;

            // HP가 0 이하로 떨어진 경우, 0으로 설정
            if (monster.Hp < 0)
            {
                monster.Hp = 0;
            }
        }
        public void MonstersDamage(int Damage)
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
