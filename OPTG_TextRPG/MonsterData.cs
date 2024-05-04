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
        public int DropGold { get; set; }

        public MonsterData() { }
        public MonsterData(string name, int lv, int atk, int hp, int dropGold)
        {
            Name = name;
            Lv = lv;
            Atk = atk;
            Hp = hp;
            DropGold = dropGold;
        }

        //깊은복사 생성자*
        public MonsterData(MonsterData data)
        {
            Name = data.Name;
            Lv = data.Lv;
            Atk = data.Atk;
            Hp = data.Hp;
            DropGold = data.DropGold;
        }
    }
}
