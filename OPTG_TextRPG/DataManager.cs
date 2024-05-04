﻿

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
    // 플레이어 정보, 직업 정보, 스킬 정보
    // public Dictionary<int, Player> SkillDB = new Dictionary<int, Player>(); // 추가기능 - 스킬 만들기
    public List<Item> ItemDB = new List<Item>();
    public Dictionary<int, MonsterData> MonsterDB = new Dictionary<int, MonsterData>();
    public Dictionary<int, MonsterData> BossMonsterDB = new Dictionary<int, MonsterData>();

    public PlayerData InitJob(string name,int job)
    {
        //직업전체를 불러오는게 아니라 선택할때만 그 해당하는 직업만 불러옴
        switch (job)
        {
            case 1:
                return new PlayerData(name, "전사", 1, 25, 30, 100, 30, 1500);
            case 2:
                return new PlayerData(name, "마법사", 1, 10, 10, 100, 100, 1500);
            case 3:
                return new PlayerData(name, "도적", 1, 20, 15, 100, 60, 1500);
            case 4:
                return new PlayerData(name, "궁수", 1, 20, 20, 100, 80, 1500);
            default: //테스트용.
                return new PlayerData(name, "GM", 999, 999, 999, 999, 999, 9999);
        }
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

        //ItemDB.Add(new Item("HP 포션", "체력을 회복시켜 주는 물약.", ItemType.PORTION, 0, 0, 10, 100));
        // ItemDB.Add(new Item("MP 포션", "마나를 회복시켜 주는 물약", ItemType.PORTION, 0, 0, 10, 100));
    }
}