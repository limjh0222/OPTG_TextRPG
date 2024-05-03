using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OPTG_TextRPG
{

    public class DungeonManager
    {
        Dictionary<int, MonsterData> monsterDB = new Dictionary<int, MonsterData>();
        Dictionary<int, MonsterData> bossMonsterDB = new Dictionary<int, MonsterData>();
        List<MonsterData> monsters = new List<MonsterData>();
        Random random = new Random();
        public int stage;

        public DungeonManager()
        {
            stage = 1;
            monsterDB = DataManager.Instance.MonsterDB;
            bossMonsterDB = DataManager.Instance.BossMonsterDB;
        }

        public List<MonsterData> SpawnMonster()
        {
            monsters.Clear(); //몬스터 초기화
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

        private MonsterData RandomNormalMonster()
        {
            //몬스터 정보를 랜덤하게 섞어줌
            return new MonsterData(monsterDB[random.Next(monsterDB.Count)]);
        }
        public MonsterData RandomBossMonster()
        {
            //보스몬스터 선택
            return new MonsterData(bossMonsterDB[0]);
        }
        // 스테이지 진행
        public void NextStage()
        {
            stage++;
            //if (stage < 6) //현재 스테이지는 5까지 구현
            //{
            //    stage++;
            //}
        }
    }
}
