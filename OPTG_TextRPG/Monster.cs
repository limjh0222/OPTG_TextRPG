using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPTG_TextRPG
{
    public class Monster
    {
        string name { get; }
        int lv { get; }
        int hp { get; }
        int atk { get; }

        public Monster(string name, int lv, int hp, int atk)
        {
            this.name = name;
            this.lv = lv;
            this.hp = hp;
            this.atk = atk;
        }

        public override string ToString()
        {
            return $"Lv.{lv} {name} HP {hp}";
        }
    }
}
