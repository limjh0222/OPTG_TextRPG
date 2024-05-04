

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
    public Dictionary<int, MonsterData> NormalMonsterDB = new Dictionary<int, MonsterData>();
    public Dictionary<int, MonsterData> AdvancedMonsterDB = new Dictionary<int, MonsterData>();
    public Dictionary<int, MonsterData> BossMonsterDB = new Dictionary<int, MonsterData>();

    public PlayerData InitJob(string name,int job)
    {




        //직업전체를 불러오는게 아니라 선택할때만 그 해당하는 직업만 불러옴
        switch (job)
        {
            case 1:
                return new PlayerData(name, "전사", 1, 30, 35, 200, 50, 1500,SkillManager.Instance.GetSkillsForJob(1)));
            case 2:
                return new PlayerData(name, "마법사", 1, 15, 15, 100, 200, 1500, SkillManager.Instance.GetSkillsForJob(2)));
            case 3:
                return new PlayerData(name, "도적", 1, 20, 25, 180, 60, 1500, SkillManager.Instance.GetSkillsForJob(3)));
            case 4:
                return new PlayerData(name, "궁수", 1, 25, 20, 1, 100, 1500, , SkillManager.Instance.GetSkillsForJob(4)));
            default: //테스트용.
                return new PlayerData(name, "[GM]", 999, 999, 999, 999, 999, 9999);
        }

    }
    public void InitMonster() // 이름, 레벨, 공격력, 체력
    {
        NormalMonsterDB.Add(0, new MonsterData("슬라임", 2, 3, 23));
        NormalMonsterDB.Add(1, new MonsterData("고블린", 3, 5, 25));
        NormalMonsterDB.Add(2, new MonsterData("구울", 4, 5, 28));
        NormalMonsterDB.Add(3, new MonsterData("미믹", 5, 5, 35));
        NormalMonsterDB.Add(4, new MonsterData("골렘", 6, 8, 42));
        NormalMonsterDB.Add(5, new MonsterData("스켈레톤", 8, 10, 50));
        NormalMonsterDB.Add(6, new MonsterData("오우거", 8, 10, 50));
        NormalMonsterDB.Add(7, new MonsterData("가고일", 8, 10, 50));
        NormalMonsterDB.Add(8, new MonsterData("리자드맨", 8, 10, 50));
        NormalMonsterDB.Add(9, new MonsterData("맹독충", 8, 10, 50));

        AdvancedMonsterDB.Add(0, new MonsterData("스켈레톤 나이트", 8, 10, 50));
        AdvancedMonsterDB.Add(1, new MonsterData("스켈레톤 워리어", 8, 10, 50));
        AdvancedMonsterDB.Add(2, new MonsterData("앨드리치", 8, 10, 50));
        AdvancedMonsterDB.Add(3, new MonsterData("바실리스크", 8, 10, 50));
        AdvancedMonsterDB.Add(4, new MonsterData("다크 엘프", 8, 10, 50));
        AdvancedMonsterDB.Add(5, new MonsterData("미노타우르스", 8, 10, 50));
        AdvancedMonsterDB.Add(6, new MonsterData("뱀파이어", 8, 10, 50));
        AdvancedMonsterDB.Add(7, new MonsterData("사라맨더", 8, 10, 50));
        AdvancedMonsterDB.Add(8, new MonsterData("서큐버스", 8, 10, 50));
        AdvancedMonsterDB.Add(9, new MonsterData("와이번", 8, 10, 50));

        BossMonsterDB.Add(0, new MonsterData("탐욕의 바르실", 15, 15, 100));
        BossMonsterDB.Add(1, new MonsterData("오만의 카시엘", 15, 15, 100));
        BossMonsterDB.Add(2, new MonsterData("폭식의 레이든", 15, 15, 100));
        BossMonsterDB.Add(3, new MonsterData("질투의 시드라", 15, 15, 100));
        BossMonsterDB.Add(4, new MonsterData("나태의 게르멜", 15, 15, 100));
        BossMonsterDB.Add(5, new MonsterData("분노의 베르제르프", 15, 15, 100));
        BossMonsterDB.Add(6, new MonsterData("색욕의 루드벨라", 15, 15, 100));
    }
    public void InitItem()
    {
        ItemDB.Add(new Item("낡은 검", "흔한 낡은 검.", ItemType.WEAPON, 2, 0, 0, 1000));
        ItemDB.Add(new Item("단단한 도끼", "무겁고 치명적인 무기.", ItemType.WEAPON, 9, -2, 0, 3000));
        ItemDB.Add(new Item("검과 방패", "공격과 방어를 동시에!", ItemType.WEAPON, 4, 4, 0, 3500));

        ItemDB.Add(new Item("허름한 가운", "누군가 버린 가운.", ItemType.ARMOR, 0, 0, 10, 500));
        ItemDB.Add(new Item("가벼운 갑옷", "돌격에 용이!", ItemType.ARMOR, 2, 3, 0, 2500));
        ItemDB.Add(new Item("무쇠 갑옷", "튼튼한 갑옷.", ItemType.ARMOR, 0, 6, 0, 3000));

        //ItemDB.Add(new Item("HP 포션", "체력을 회복시켜 주는 물약.", ItemType.PORTION, 0, 0, 10, 100));
        // ItemDB.Add(new Item("MP 포션", "마나를 회복시켜 주는 물약", ItemType.PORTION, 0, 0, 10, 100));
    }
}