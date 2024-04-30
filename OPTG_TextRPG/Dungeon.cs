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
        Random random = new Random();
        int stage = 1;
        private DataManager dataManager;

        private Dungeon(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        //던전을 생성하는 정적 매서드
        public static Dungeon CreateDungeon()
        {
            DataManager dataManager = DataManager.Instance;
            return new Dungeon(dataManager);
        }

        public List<Monster> SpawnMonstersForStage()
        {
            List<Monster> monsters = new List<Monster>();

            // 랜덤한 수의 몬스터 생성
            int numMonsters = random.Next(1, 5); // 1부터 4 사이의 랜덤한 수
            for (int i = 0; i < numMonsters; i++)
            {
                monsters.Add(domMonster());
            }

            return monsters;
        }

        private Monster domMonster()
        {
            // 데이터 매니저에서 몬스터 정보를 가져와서 랜덤하게 선택
            List<Monster> randomMonsters = new List<Monster>(dataManager.MonsterDB.Values);
            Monster selectedMonster = randomMonsters[random.Next(randomMonsters.Count)];

            // 스테이지에 따라 몬스터 스탯을 조정
            int stageHp = selectedMonster.Hp + (stage - 1) * 5;
            int stageAtk = selectedMonster.Atk + (stage - 1) * 2;

            // 조정된 스탯으로 몬스터 생성
            return new Monster(selectedMonster.Name, stage, stageHp, stageAtk);
        }
        // 스테이지 진행
        public void ProceedToNextStage()
        {
            stage++;
        }
    }
}
