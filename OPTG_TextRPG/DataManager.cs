

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
                return new PlayerData(name, "전사", 1, 30, 35, 200, 50, 100,SkillManager.Instance.GetSkillsForJob(1));
            case 2:
                return new PlayerData(name, "마법사", 1, 15, 15, 100, 200, 1000, SkillManager.Instance.GetSkillsForJob(2));
            case 3:

                return new PlayerData(name, "도적", 1, 20, 25, 180, 60, 1000, SkillManager.Instance.GetSkillsForJob(3));
            case 4:
                return new PlayerData(name, "궁수", 1, 25, 20, 1, 100, 1000,  SkillManager.Instance.GetSkillsForJob(4));
      default: //테스트용.
                return new PlayerData(name, "[GM]", 999, 999, 999, 999, 999, 99999, SkillManager.Instance.GetSkillsForJob(5));
        }

    }
    public void InitMonster() // 이름, 레벨, 공격력, 체력, 골드
    {
        NormalMonsterDB.Add(0, new MonsterData("슬라임", 1, 2, 15, 50));
        NormalMonsterDB.Add(1, new MonsterData("고블린", 2, 4, 18, 50));
        NormalMonsterDB.Add(2, new MonsterData("구울", 2, 4, 21, 50));
        NormalMonsterDB.Add(3, new MonsterData("미믹", 3, 3, 20, 50));
        NormalMonsterDB.Add(4, new MonsterData("시궁창쥐", 2, 3, 18, 50));
        NormalMonsterDB.Add(5, new MonsterData("스켈레톤", 3, 4, 23, 50));
        NormalMonsterDB.Add(6, new MonsterData("오우거", 5, 6, 28, 50));
        NormalMonsterDB.Add(7, new MonsterData("가고일", 6, 6, 25, 50));
        NormalMonsterDB.Add(8, new MonsterData("리자드맨", 5, 5, 23, 50));
        NormalMonsterDB.Add(9, new MonsterData("맹독충", 4, 3, 20, 50));

        AdvancedMonsterDB.Add(0, new MonsterData("스켈레톤 나이트", 10, 6, 22, 100));
        AdvancedMonsterDB.Add(1, new MonsterData("스켈레톤 워리어", 12, 5, 24, 100));
        AdvancedMonsterDB.Add(2, new MonsterData("앨드리치", 11, 5, 25, 100));
        AdvancedMonsterDB.Add(3, new MonsterData("바실리스크", 14, 8, 22, 100));
        AdvancedMonsterDB.Add(4, new MonsterData("다크엘프", 12, 12, 15, 100));
        AdvancedMonsterDB.Add(5, new MonsterData("미노타우르스", 15, 8, 24, 100));
        AdvancedMonsterDB.Add(6, new MonsterData("뱀파이어", 14, 10, 28, 100));
        AdvancedMonsterDB.Add(7, new MonsterData("사라맨더", 12, 7, 22, 100));
        AdvancedMonsterDB.Add(8, new MonsterData("서큐버스", 16, 5, 25, 100));
        AdvancedMonsterDB.Add(9, new MonsterData("와이번", 12, 15, 32, 100));

        BossMonsterDB.Add(0, new MonsterData("탐욕의 바르실", 20, 20, 100, 1000));
        BossMonsterDB.Add(1, new MonsterData("오만의 카시엘", 20, 20, 100, 1000));
        BossMonsterDB.Add(2, new MonsterData("폭식의 레이든", 20, 20, 100, 1000));
        BossMonsterDB.Add(3, new MonsterData("질투의 미르비나", 20, 20, 100, 1000));
        BossMonsterDB.Add(4, new MonsterData("나태의 게르멜", 20, 20, 100, 1000));
        BossMonsterDB.Add(5, new MonsterData("분노의 베르제프", 20, 20, 100, 1000));
        BossMonsterDB.Add(6, new MonsterData("색욕의 루드벨라", 20, 20, 100, 1000));
    }
    public void InitItem() //아이템타입,공격력,방어력,체력,가격
    {
        ItemDB.Add(new Item("녹슨 단검", "아무것도 없는것보단 낫지 않겠어요?.", ItemType.WEAPON, 5, 0, 0, 1500));
        ItemDB.Add(new Item("낡은 클럽", "베는것만이 답이 아닐수도 있죠.", ItemType.WEAPON, 7, 0, 0, 2000));
        ItemDB.Add(new Item("롱소드", "이제 몬스터와의 싸움은 두렵지않아요.", ItemType.WEAPON, 10, 0, 0, 2300));
        ItemDB.Add(new Item("메이스", "흔히 철퇴라고 하죠. 맞으면 상당히 아플지도..", ItemType.WEAPON, 13, 0, 0, 3000));
        ItemDB.Add(new Item("레이피어", "찌른다. 또 찌른다.. 계속 찌른다!", ItemType.WEAPON, 15, 0, 0, 3800));
        ItemDB.Add(new Item("채찍", "혹시.. 그런 취향 이신가요..?", ItemType.WEAPON, 17, 0, 0, 4500));
        ItemDB.Add(new Item("스피어", "꼭 가까이서 싸울필요는 없잖아요?", ItemType.WEAPON, 20, 0, 0, 5200));
        ItemDB.Add(new Item("배틀엑스", "외형만큼이나 무겁죠. 무겁지만 아파요.", ItemType.WEAPON, 25, 0, 0, 6000));
        ItemDB.Add(new Item("클레이모어", "이름만큼 외형도 공격도 일품!", ItemType.WEAPON, 35, 0, 0, 9700));

        ItemDB.Add(new Item("허름한 천옷", "누군가 입었던것 같지만 쓸만해요.", ItemType.ARMOR, 0, 0, 10, 500));
        ItemDB.Add(new Item("", "돌격에 용이!", ItemType.ARMOR, 2, 3, 0, 2500));
        ItemDB.Add(new Item("녹슨 무쇠 갑옷", "튼튼한 갑옷.", ItemType.ARMOR, 0, 6, 0, 3000));
        ItemDB.Add(new Item("", "튼튼한 갑옷.", ItemType.ARMOR, 0, 6, 0, 3000));
        ItemDB.Add(new Item("아머", "튼튼한 갑옷.", ItemType.ARMOR, 0, 6, 0, 3000));
        ItemDB.Add(new Item("", "튼튼한 갑옷.", ItemType.ARMOR, 0, 6, 0, 3000));
        ItemDB.Add(new Item("풀 메일", "튼튼한 갑옷.", ItemType.ARMOR, 0, 6, 0, 3000));
        ItemDB.Add(new Item("미스릴아머", "튼튼한 갑옷.", ItemType.ARMOR, 0, 6, 0, 3000));
        ItemDB.Add(new Item("드래곤스킨", "튼튼한 갑옷.", ItemType.ARMOR, 0, 6, 0, 3000));




        //ItemDB.Add(new Item("HP 포션", "체력을 회복시켜 주는 물약.", ItemType.PORTION, 0, 0, 10, 100));
        // ItemDB.Add(new Item("MP 포션", "마나를 회복시켜 주는 물약", ItemType.PORTION, 0, 0, 10, 100));
    }
}