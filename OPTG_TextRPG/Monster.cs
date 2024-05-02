using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPTG_TextRPG
{
    public class Monster
    {
        public string Name { get; }
        public int Lv { get; }
        public int Atk { get; }
        public float Hp { get; set; }
        public bool IsDead { get; set; }

        public Monster() { }
        public Monster(string name, int lv, int atk, int hp)
        {
            Name = name;
            Lv = lv;
            Atk = atk;
            Hp = hp;

        }

        // 몬스터 정보 출력을 위한 ToString 메서드 수정
        public override string ToString()
        {
            return $"Lv.{Lv} {Name} HP: {Hp} 공격력: {Atk}";
        }

        public void CheckDead()
        {
            if (Hp <= 0)
            {
                IsDead = true;
            }
        }

        public int MonsterAttack(float attack)
        {
            double minAttack = attack * 0.9;
            double maxAttack = attack * 1.1;

            return (int)Math.Ceiling(new Random().NextDouble() * (maxAttack - minAttack) + minAttack);
        }
    }
}
