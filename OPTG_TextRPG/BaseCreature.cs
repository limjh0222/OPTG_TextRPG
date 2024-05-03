using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPTG_TextRPG
{
    internal class BaseCreature
    {
        public string Name { get; }
        public string Job { get; }
        public int Level { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }

        private int hp;
        public int Hp
        {   // 최대값을 100으로 제한
            get { return hp; }
            set { hp = Math.Min(value, 100); } //Math.min() 함수는 주어진 숫자들 중 가장 작은 값을 반환
        }
        public int MaxHp { get; }
        public int Mp { get; set; }
        public int Gold { get; set; }
        public bool IsDead { get; set; }
    }


    public void Monster()
}
