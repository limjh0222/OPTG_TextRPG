

using OPTG_TextRPG;

class DataManager
{   // 싱글톤
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
    
    public List<Item> ItemDB = new List<Item>();
    public Dictionary<int, PlayerData> JobDB = new Dictionary<int, PlayerData>();
    public Dictionary<int, MonsterData> MonsterDB = new Dictionary<int, MonsterData>();
    public Dictionary<int, MonsterData> BossMonsterDB = new Dictionary<int, MonsterData>();

    public void InitJob(string name)
    {
        JobDB.Add(1, new PlayerData  (name, "전사", 1, 30, 30, 100, 100, 30, 1500, SkillManager.Instance.GetSkillsForJob(1)));
        JobDB.Add(2, new PlayerData(name, "마법사", 1, 10, 10, 100, 100, 100, 1500, SkillManager.Instance.GetSkillsForJob(2)));
        JobDB.Add(3, new PlayerData  (name, "도적", 1, 25, 15, 100, 100, 60, 1500, SkillManager.Instance.GetSkillsForJob(3)));
        JobDB.Add(4, new PlayerData  (name, "궁수", 1, 20, 20, 100, 100, 80, 1500, SkillManager.Instance.GetSkillsForJob(4)));
    }
    public void InitMonster()
    {
        MonsterDB.Add(0, new MonsterData("슬라임", 2, 3, 23));
        MonsterDB.Add(1, new MonsterData("고블린", 3, 5, 25));
        MonsterDB.Add(2, new MonsterData("오크", 5, 7, 28));
        MonsterDB.Add(3, new MonsterData("미믹", 5, 5, 35));
        MonsterDB.Add(4, new MonsterData("골렘", 6, 8, 42));
        MonsterDB.Add(5, new MonsterData("오우거", 8, 10, 50));

        BossMonsterDB.Add(0, new MonsterData("바실리스크", 15, 15, 100));
    }
    public void InitItem()
    {
        ItemDB.Add(new Item("낡은 검", "흔한 낡은 검.", ItemType.WEAPON, 2, 0, 0, 1000));
        ItemDB.Add(new Item("단단한 도끼", "무겁고 치명적인 무기.", ItemType.WEAPON, 9, -2, 0, 3000));
        ItemDB.Add(new Item("검과 방패", "공격과 방어를 동시에!", ItemType.WEAPON, 4, 4, 0, 3500));

        ItemDB.Add(new Item("허름한 가운", "누군가 버린 가운.", ItemType.ARMOR, 0, 0, 10, 500));
        ItemDB.Add(new Item("가벼운 갑옷", "돌격에 용이!", ItemType.ARMOR, 2, 3, 0, 2500));
        ItemDB.Add(new Item("무쇠 갑옷", "튼튼한 갑옷.", ItemType.ARMOR, 0, 6, 0, 3000));
    }
}