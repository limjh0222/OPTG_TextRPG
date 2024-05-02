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
        private Dictionary<int, Monster> monsterDB = new Dictionary<int, Monster>();
        private Dictionary<int, Monster> bossMonsterDB = new Dictionary<int, Monster>();
        private List<Monster> monsters = new List<Monster>();
        private Random random = new Random();
        public int stage = 1;


        public Dungeon()
        {
            monsterDB = DataManager.Instance.MonsterDB;
            bossMonsterDB = DataManager.Instance.BossMonsterDB;

        }



        public Monster RandomNormalMonster()
        {
            if (monsterDB.Count == 0)
                return null;

            // 몬스터 키를 리스트로 저장
            List<int> keys = new List<int>(monsterDB.Keys);

            // 이미 선택된 몬스터를 제외하고 몬스터 선택
            int randomIndex = random.Next(keys.Count);
            Monster selectedMonster = monsterDB[keys[randomIndex]];

            // 선택된 몬스터를 몬스터 목록에서 삭제
            monsterDB.Remove(keys[randomIndex]);

            return selectedMonster;
        }

        public Monster RandomBossMonster()
        {
            return bossMonsterDB[0];
        }

        public int GetStage()
        {
            return stage;
        }
        public void NextStage()
        {

            if (stage < 6)
            {

                stage++;


            }
        }


    }
}
