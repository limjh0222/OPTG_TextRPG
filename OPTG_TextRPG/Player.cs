public class Player
{
    public string Name { get; }
    public string Job { get; }
    public int Level { get; set; }
    public int Atk { get; set; }
    public int Def { get; set; }

    private int hp;
    public int Hp
    {   // 최대값을 100으로 제한
        get { return hp; }
        set { hp = Math.Min(value, 100); } //Math.min() 함수는 주어진 숫자들 중 가장 작은 값을 반환
    }
    public int MaxHp { get; }
    public int Mp { get; set; }
    public int Gold { get; set; }
    public bool IsDead { get; set; }

    public Player() { }
    public Player(string name, string job, int level, int atk, int def,int hp, int maxHp, int mp, int gold)
    {
        Name = name;
        Job = job;
        Level = level;
        Atk = atk;
        Def = def;
        MaxHp = maxHp;
        Hp = hp;
        Mp = mp;
        Gold = gold;
    }

    public int PlayerAttack(float attack)
    {
        double minAttack = attack * 0.9;
        double maxAttack = attack * 1.1;

        return (int)Math.Ceiling(new Random().NextDouble() * (maxAttack - minAttack) + minAttack);
    }
}