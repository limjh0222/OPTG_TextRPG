using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPTG_TextRPG
{
    public class Monster
    {
        string Name { get; }
        int Lv { get; }
        int Hp { get; }
        int Atk { get; }
        //atk가 없는이유는 과제에 몬스터 atk표기가 없고
        //공격할때 데미지를 표기가 될 예정 입니다.

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
