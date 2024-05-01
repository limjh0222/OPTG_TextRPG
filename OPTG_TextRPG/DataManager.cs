

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

    // 플레이어 직업 정보

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

    // 스킬 정보
    /*
    public Dictionary<string, Skill> SkillDB = new Dictionary<string, Skill>();

    public void InitSkill()
    {
        SkillDB.Add("스킬명", new Skill("스킬명", 소비MP, 스탯변화, 사용대상, 스킬설명));
    }

    public Skill GetSkill(string index)
    {
        if (ItemDB.ContainsKey(index))
        {
            return SkillDB[index];
        }
        else
            Console.WriteLine("DataManager: 해당하는 스킬이 없습니다.");
        return null;
    }
    */

    // 몬스터 정보

    public Dictionary<string, Monster> MonsterDB = new Dictionary<string, Monster>();

    public void InitMonster()
    {
        MonsterDB.Add("미니언", new Monster("미니언", 2, 15, 5));
        MonsterDB.Add("공허충", new Monster("공허충", 3, 10, 9));
        MonsterDB.Add("대포미니언", new Monster("미니언", 5, 25, 8));

        //추가 몬스터 견본 - 편하게 수정하세요
        MonsterDB.Add("먼지", new Monster("먼지", 2, 16, 3));
        MonsterDB.Add("재훈님네고양이", new Monster("재훈님네고양이", 3, 6, 11));
        MonsterDB.Add("후다닭", new Monster("후다닭", 5, 15, 9));

        //보스몹 견본
        MonsterDB.Add("강동욱 튜터님", new Monster("강동욱 튜터님", 10, 25, 15));
    }

    public Monster GetMonster(string index)
    {
        if (MonsterDB.ContainsKey(index))
        {
            return MonsterDB[index];
        }
        else
            Console.WriteLine("DataManager: 해당하는 몬스터가 없습니다.");
        return null;
    }



    // 스테이지 정보




    // 아이템 정보

    public Dictionary<string, Item> ItemDB = new Dictionary<string, Item>();

    public void InitItem()
    {
        ItemDB.Add("무쇠갑옷", new Item("무쇠갑옷", "튼튼한 갑옷", ItemType.ARMOR, 0, 5, 0, 500));
        ItemDB.Add("낡은 검", new Item("낡은 검", "낡은 검", ItemType.WEAPON, 2, 0, 0, 1000));
        ItemDB.Add("골든 헬름", new Item("골든 헬름", "희귀한 투구", ItemType.ARMOR, 0, 9, 0, 2000));

        //추가 아이템 견본
        ItemDB.Add("가벼운 갑옷", new Item("가벼운 갑옷", "돌격에 용이", ItemType.ARMOR, 2, 3, 0, 500));
        ItemDB.Add("단단한 도끼", new Item("단단한 도끼", "무겁고 치명적인 무기", ItemType.WEAPON, 9, -2, 0, 1500));
        ItemDB.Add("검과 방패", new Item("검과 방패", "공격과 방어를 동시에", ItemType.WEAPON, 4, 4, 0, 2000));
    }

    public Item GetItem(string index)
    {
        if (ItemDB.ContainsKey(index))
        {
            return ItemDB[index];
        }
        else
            Console.WriteLine("DataManager: 해당하는 아이템이 없습니다.");
        return null;
    }

    // 기타 정보
}