using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPTG_TextRPG
{
    public class MonsterData
    {
        public string Name { get; }
        public int Lv { get; }
        public int Atk { get; }
        public float Hp { get; set; }
        public bool IsDead { get; set; }

        public MonsterData() { }
        public MonsterData(string name, int lv, int atk, int hp)
        {
            Name = name;
            Lv = lv;
            Atk = atk;
            Hp = hp;

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
