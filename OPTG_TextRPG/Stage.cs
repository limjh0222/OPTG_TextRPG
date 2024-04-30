using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPTG_TextRPG
{
    internal class Stage
    {
        List<Monster> monsterList { get; set; }
        Player player { get; set; }
        int stageLv { get; }
        
        //전투에 필요한 정보를 받아옴
        public Stage(List<Monster> monsterList, Player player, int stageLv)
        {
            this.monsterList = monsterList;
            this.player = player;
            this.stageLv = stageLv;
        }
        
        //전투 시작화면
        public void PrintStage()
        {
            Console.WriteLine($"Battle!! Stage {stageLv}\n");
            
            foreach ( var monster in monsterList )
            { 
                Console.WriteLine(monster.ToString() );
            }
            Console.WriteLine("\n\n");

            Console.WriteLine("[내정보]");
            Console.WriteLine($"Lv.{player.Level} {player.Name} ({player.Job})");
            Console.WriteLine($"HP {player.Hp}\n"); //maxHP 없음
            Console.WriteLine("1. 공격\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
        }
    }
}
