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
        public int Hp { get; private set; }
        public int Atk { get; }

        public Monster() { }
        public Monster(string name, int lv, int hp, int atk)
        {
            this.Name = name;
            this.Lv = lv;
            this.Hp = hp;
            this.Atk = atk;
        }

        //몬스터 객체를 출력
        public override string ToString()
        {
            return $"Lv.{Lv} {Name} HP {Hp}";
        }
    }
}
