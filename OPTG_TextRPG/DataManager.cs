

using OPTG_TextRPG;

class DataManager
{
    // 싱글톤

    private static DataManager instance = null;

    public static DataManager Instance 
    {  
        get
        { 
            if(instance == null)
            {
                instance = new DataManager();
            }
            return instance; 
        } 
    }

    // 플레이어 정보, 직업 정보, 스킬 정보

    public Dictionary<int, Player> JobDB = new Dictionary<int, Player>();
    // public Dictionary<int, Player> SkillDB = new Dictionary<int, Player>(); // 추가기능 - 스킬 만들기

    public void InitJob(string name)
    {
        JobDB.Add(1, new Player(name, "전사", 1, 25, 15, 120, 1500));
        JobDB.Add(2, new Player(name, "마법사", 1, 15, 10, 80, 1500));
        JobDB.Add(3, new Player(name, "도적", 1, 20, 12, 90, 1500));
        JobDB.Add(4, new Player(name, "궁수", 1, 18, 18, 100, 1500));
    }

    public Player GetJob(int index)
    {
        if (JobDB.ContainsKey(index))
        {
            return JobDB[index];
        }
        else
            Console.WriteLine("DataManager: 해당하는 플레이어 데이터가 없습니다.");
        return null;
    }

    // 몬스터정보
    // 구성의 사용편의성을 위해서 key값을 int형으로 변경
    // 보스몬스터의 사용편의성을 위해 BossMonsterDB 별도로 생성
    public Dictionary<int, Monster> MonsterDB = new Dictionary<int, Monster>();
    public Dictionary<int, Monster> BossMonsterDB = new Dictionary<int, Monster>();
    public void InitMonster()
    {
        MonsterDB.Add(0, new Monster("슬라임", 2, 10, 23));
        MonsterDB.Add(1, new Monster("고블린", 3, 12, 25));
        MonsterDB.Add(2, new Monster("오크", 5, 18, 28));
        MonsterDB.Add(3, new Monster("미믹", 5, 15, 35));
        MonsterDB.Add(4, new Monster("골렘", 6, 22, 55));
        MonsterDB.Add(5, new Monster("오우거", 8, 25, 60));

        BossMonsterDB.Add(0, new Monster("바실리스크", 15, 30, 150));
    }

    public Monster GetMonster(int index)
    {
        if (MonsterDB.ContainsKey(index))
        {
            return MonsterDB[index];
        }
        else
            Console.WriteLine("DataManager: 해당하는 몬스터가 없습니다.");
        return null;
    }

    // 아이템 정보 - 리스트

    private List<Item> ItemDB;

    public void ItemList()
    {

        ItemDB = new List<Item>();

        ItemDB.Add(new Item("무쇠갑옷", "튼튼한 갑옷", ItemType.ARMOR, 0, 5, 0, 500));
        ItemDB.Add(new Item("낡은 검", "낡은 검", ItemType.WEAPON, 2, 0, 0, 1000));
        ItemDB.Add(new Item("골든 헬름", "희귀한 투구", ItemType.ARMOR, 0, 9, 0, 2000));
        ItemDB.Add(new Item("가벼운 갑옷", "돌격에 용이", ItemType.ARMOR, 2, 3, 0, 500));
        ItemDB.Add(new Item("단단한 도끼", "무겁고 치명적인 무기", ItemType.WEAPON, 9, -2, 0, 1500));
        ItemDB.Add(new Item("검과 방패", "공격과 방어를 동시에", ItemType.WEAPON, 4, 4, 0, 2000));
    }


    // 기타 정보
}