

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
        {   //이름, 레벨, 공격력, 방어력, MaxHP ,MaxMP ,골드
            case 1:
                return new PlayerData(name, "전사", 1, 20, 15, 200, 50, 1000,SkillManager.Instance.GetSkillsForJob(1));
            case 2:
                return new PlayerData(name, "마법사", 1, 11, 5, 100, 200, 1000, SkillManager.Instance.GetSkillsForJob(2));
            case 3:
                return new PlayerData(name, "도적", 1, 15, 7, 180, 60, 1000, SkillManager.Instance.GetSkillsForJob(3));
            case 4:
                return new PlayerData(name, "궁수", 1, 17, 12, 150, 100, 1000,  SkillManager.Instance.GetSkillsForJob(4));
      default: //테스트용.
                return new PlayerData(name, "[GM]", 999, 999, 999, 999, 999, 99999, SkillManager.Instance.GetSkillsForJob(5));
        }

    }
    public void InitMonster() // 이름, 레벨, 공격력, 체력, 골드
    {
        NormalMonsterDB.Add(0, new MonsterData("슬라임",  1, 10, 10, 50));
        NormalMonsterDB.Add(1, new MonsterData("고블린",  2, 13, 15, 70));
        NormalMonsterDB.Add(2, new MonsterData("구울",     2, 12, 24, 110));
        NormalMonsterDB.Add(3, new MonsterData("미믹",     3, 11, 22, 500));
        NormalMonsterDB.Add(4, new MonsterData("시궁창쥐", 2, 15, 18, 80));
        NormalMonsterDB.Add(5, new MonsterData("스켈레톤", 3, 13, 23, 60));
        NormalMonsterDB.Add(6, new MonsterData("오우거",   5, 16, 28, 100));
        NormalMonsterDB.Add(7, new MonsterData("가고일",   6, 15, 20, 90));
        NormalMonsterDB.Add(8, new MonsterData("리자드맨", 5, 13, 32, 70));
        NormalMonsterDB.Add(9, new MonsterData("맹독충",   4, 14, 25, 40));

        AdvancedMonsterDB.Add(0, new MonsterData("스켈레톤 나이트", 10, 15, 35, 150));
        AdvancedMonsterDB.Add(1, new MonsterData("스켈레톤 워리어", 12, 13, 41, 180));
        AdvancedMonsterDB.Add(2, new MonsterData("앨드리치", 11, 12, 32, 130));
        AdvancedMonsterDB.Add(3, new MonsterData("바실리스크", 14, 20, 33, 170));
        AdvancedMonsterDB.Add(4, new MonsterData("다크엘프", 12, 25, 36, 250));
        AdvancedMonsterDB.Add(5, new MonsterData("미노타우르스", 15, 23, 42, 170));
        AdvancedMonsterDB.Add(6, new MonsterData("뱀파이어", 14, 24, 33, 200));
        AdvancedMonsterDB.Add(7, new MonsterData("사라맨더", 12, 15, 31, 140));
        AdvancedMonsterDB.Add(8, new MonsterData("서큐버스", 16, 21, 27, 280));
        AdvancedMonsterDB.Add(9, new MonsterData("와이번", 15, 24, 38, 300));

        BossMonsterDB.Add(0, new MonsterData("탐욕의 바르실", 20, 20, 70, 1000));
        BossMonsterDB.Add(1, new MonsterData("오만의 카시엘", 22, 21, 75, 1000));
        BossMonsterDB.Add(2, new MonsterData("폭식의 레이든", 23, 22, 80, 1000));
        BossMonsterDB.Add(3, new MonsterData("질투의 미르비나", 24, 23, 85, 1000));
        BossMonsterDB.Add(4, new MonsterData("나태의 게르멜", 25, 24, 90, 1000));
        BossMonsterDB.Add(5, new MonsterData("분노의 베르제프", 27, 26, 95, 1000));
        BossMonsterDB.Add(6, new MonsterData("색욕의 루드벨라", 29, 27, 100, 1000));
    }
    public void InitItem() //아이템타입,공격력,방어력,체력,가격
    {
        ItemDB.Add(new Item("녹슨 단검", "없는것보단 낫지 않겠어요?.", ItemType.WEAPON, 5, 0, 0, 1300));
        ItemDB.Add(new Item("낡은 클럽", "베는것만이 답이 아닐수도 있죠.", ItemType.WEAPON, 9, 0, 0, 2000));
        ItemDB.Add(new Item("롱소드", "이제 몬스터와의 싸움은 두렵지않아요.", ItemType.WEAPON, 13, 0, 0, 2700));
        ItemDB.Add(new Item("레이피어", "찌른다. 또 찌른다.. 계속 찌른다!", ItemType.WEAPON, 18, 0, 0, 3600));
        ItemDB.Add(new Item("스피어", "가까이에서 싸울필요는 없잖아요?", ItemType.WEAPON, 23, 0, 0, 4500));
        ItemDB.Add(new Item("배틀엑스", "외형만큼이나 무겁죠. 무겁지만 아파요.", ItemType.WEAPON, 28, 0, 0, 5800));
        ItemDB.Add(new Item("클레이모어", "이름만큼 외형도 공격도 일품!", ItemType.WEAPON, 34, 0, 0, 7500));

        ItemDB.Add(new Item("허름한 조끼", "낡은것 같지만 쓸만할지도?", ItemType.ARMOR, 0, 3, 0, 800));
        ItemDB.Add(new Item("가죽 갑옷", "장인의 손길로 한땀한땀!.", ItemType.ARMOR, 0, 5, 0, 1500));
        ItemDB.Add(new Item("브리간딘", "이제 좀 튼튼한거 같아요.", ItemType.ARMOR, 0, 8, 0, 2800));
        ItemDB.Add(new Item("사슬 갑옷", "촘촘하게 만들어서 튼튼해요.", ItemType.ARMOR, 0, 12, 0, 3700));
        ItemDB.Add(new Item("미스릴 갑옷", "드워프가 만든건 일품이죠.", ItemType.ARMOR, 0, 15, 0, 5300));
        ItemDB.Add(new Item("드래곤스킨", "전설로 내려오는 갑옷이에요!", ItemType.ARMOR, 0, 20, 0, 7200));

        //ItemDB.Add(new Item("HP 포션", "체력을 회복시켜 주는 물약.", ItemType.PORTION, 0, 0, 10, 100));
        // ItemDB.Add(new Item("MP 포션", "마나를 회복시켜 주는 물약", ItemType.PORTION, 0, 0, 10, 100));
    }
}