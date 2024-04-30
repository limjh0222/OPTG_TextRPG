using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPTG_TextRPG
{
    public class Dungeon
    {
        Stage stage { get; set; }
        Player player { get; set; }

        //테스트용 몬스터(나중에 지워야함)
        Monster dummy = new Monster("더미", 1, 1, 1);
        
        int stageLv {  get; set; }
        
        
        
        List<Monster> monsterList = new List<Monster>();

        //몬스터 생성방식을 정하고 스테이지에 저장
        public Dungeon(Player player, List<Monster> monsterDB)
        {
            this.player = player;

            //데이터매니저에서 몬스터를 받아와서 랜덤으로 몬스터리스트 넣기
            //몬스터 수 정하기 1~4
            //몬스터 종류 정하기(역량에따라 중복가능)
            //스테이지 레벨에 따라 몬스터 레벨 조정
            //만든 몬스터를 리스트에 저장(montserList.Add(몬스터객체); )

            stage = new Stage(monsterList, player, stageLv);
        }
    }
}
