public class PlayerData
{
    public string Name { get; }
    public string Job { get; }
    public int Level { get; set; }
    public int Atk { get; set; }
    public int Def { get; set; }

    private int hp;
    public int Hp
    {   
        get { return hp; }
        set { hp = Math.Min(value, MaxHp); } //Math.min() 함수는 주어진 숫자들 중 가장 작은 값을 반환
    }
    public int MaxHp { get; }

    private int mp;
    public int Mp
    {
        get { return mp; }
        set { mp = Math.Min(value, MaxMp); } //Math.min() 함수는 주어진 숫자들 중 가장 작은 값을 반환
    }
    public int MaxMp { get; }
    public int Gold { get; set; }
    public bool IsDead { get; set; }
    public Dictionary<int, SkillData> Skills { get; private set; } // 스킬 정보 추가

    public PlayerData() { }

    public PlayerData(string name, string job, int level, int atk, int def, int maxHp, int maxMp, int gold, Dictionary<int, SkillData> skills)


    {
        Name = name;
        Job = job;
        Level = level;
        Atk = atk;
        Def = def;
        MaxHp = maxHp;
        Hp = maxHp;
        MaxMp = maxMp;
        Mp = maxMp;
        Gold = gold;
        Skills = skills; // 스킬 정보 추가
    }
}