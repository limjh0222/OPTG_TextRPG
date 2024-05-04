using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OPTG_TextRPG
{

    public class DungeonManager
    {
        Dictionary<int, MonsterData> NormalMonsterDB = new Dictionary<int, MonsterData>();
        Dictionary<int, MonsterData> AdvancedMonsterDB = new Dictionary<int, MonsterData>();
        Dictionary<int, MonsterData> BossMonsterDB = new Dictionary<int, MonsterData>();
        List<MonsterData> monsters = new List<MonsterData>();
        Random random = new Random();
        public int stage;

        public DungeonManager()
        {
            stage = 1;
            NormalMonsterDB = DataManager.Instance.NormalMonsterDB;
            AdvancedMonsterDB = DataManager.Instance.AdvancedMonsterDB;
            BossMonsterDB = DataManager.Instance.BossMonsterDB;
        }

        public List<MonsterData> SpawnMonster()
        {
            monsters.Clear(); //몬스터 초기화

            //스테이지별 몬스터 생성 방식
            if (stage % 5 == 0) //스테이지가 5단위 마다 보스 몬스터 생성
            {
                monsters.Add(RandomBossMonster());
            }
            else if (stage <= 4) //스테이지가 4이하일때 노말몬스터 1~3마리 생성
            {
                int normalMonsters = random.Next(1, 3);
                for (int i = 0; i < normalMonsters; i++)
                {
                    monsters.Add(RandomNormalMonster());
                }
            }
            else if(stage >= 6)//6이상부터 어드밴스드 몬스터 1~4마리 생성
            {
                int AdvancedMonsters = random.Next(1, 4);
                for (int i = 0; i < AdvancedMonsters; i++)
                {
                    monsters.Add(RandomAdvancedMonster());
                }
            }

            return monsters;
        }



        //각 몬스터 묶음마다 랜덤하게 섞어줌
        private MonsterData RandomNormalMonster()
        {
            return new MonsterData(NormalMonsterDB[random.Next(NormalMonsterDB.Count)]);
        }
        private MonsterData RandomAdvancedMonster()
        {
            return new MonsterData(AdvancedMonsterDB[random.Next(AdvancedMonsterDB.Count)]);
        }
        public MonsterData RandomBossMonster()
        {
            return new MonsterData(BossMonsterDB[random.Next(BossMonsterDB.Count)]);
        }
        // 스테이지 진행
        public void NextStage()
        {
            stage++;
        }
    }
}
