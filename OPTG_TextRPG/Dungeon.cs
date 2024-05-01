using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace OPTG_TextRPG
{

    public class Dungeon
    {
        Dictionary<int,Monster> monsterDB = new Dictionary<int, Monster>();
        Dictionary<int, Monster> bossMonsterDB = new Dictionary<int, Monster>();
        List<Monster> monsters = new List<Monster>();
        Random random = new Random();
        public int stage = 1;


        public Dungeon()
        {
            monsterDB = DataManager.Instance.MonsterDB;
            bossMonsterDB = DataManager.Instance.BossMonsterDB;
        }

        public List<Monster> SpawnMonster()
        {
            monsters.Clear(); //몬스터 초기화
            stage = 5;
            //스테이지별 몬스터 생성 방식
            if (stage % 5 == 0) //스테이지가 5단위 마다 보스 몬스터 생성
            {    
                monsters.Add(RandomBossMonster());
            }
            else //그 외일때 1~4마리 사이 랜덤한 몬스터 생성
            {
                int numMonsters = random.Next(1, 5);
                for (int i = 0; i < numMonsters; i++)
                {    
                    monsters.Add(RandomNormalMonster());
                }
            }

            return monsters;
        }
        
        
        private Monster RandomNormalMonster()
        {
            //몬스터 정보를 랜덤하게 섞어줌
            return monsterDB[random.Next(monsterDB.Count)];
        }
        public Monster RandomBossMonster()
        {
            //보스몬스터 선택
            return bossMonsterDB[0];
        }
        // 스테이지 진행
        public void NextStage()
        {
            if(stage < 6) //현재 스테이지는 5까지 구현
            {
                stage++;
            }
        }
    }
}
