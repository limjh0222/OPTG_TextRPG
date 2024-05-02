public class Player
{
    public string Name { get; }
    public string Job { get; }
    public int Level { get; set; }
    public float Atk { get; set; }
    public int Def { get; set; }
    public float Hp { get; set; }
    public int MaxHp { get; set; }
    public int Mp { get; set; }
    public int Gold { get; set; }
    public bool IsDead { get; set; }

    public Dictionary<int, Skill> skillList = new Dictionary<int, Skill>();
    public Player(string name, string job, int level, int atk, int def, int mp, int gold)
    {
        Name = name;
        Job = job;
        Level = level;
        Atk = atk;
        Def = def;
        MaxHp = 2000;
        Hp = 500f;
        Mp = mp;
        Gold = gold;
    }

    //public void Attack(Monster monster)
    //{
    //    Console.WriteLine($"{Name}가 공격합니다!");

    //    // 플레이어 직업에 따라 공격력이 다름
    //    switch (Job)
    //    {
    //        case "전사":
    //            monster.Hp -= Atk + 10; // 전사는 추가로 10의 공격력이 있음
    //            break;
    //        case "마법사":
    //            monster.Hp -= Atk;
    //            break;
    //        case "도적":
    //            monster.Hp -= Atk + 5; // 도적은 추가로 5의 공격력이 있음
    //            break;
    //        case "궁수":
    //            monster.Hp -= Atk;
    //            break;
    //        default:
    //            Console.WriteLine("잘못된 직업입니다.");
    //            break;
    //    }
    //}
    public void AddSkill(int index, Skill skill)
    {
        skillList.Add(index, skill);
    }


    public static int PlayerAttack(float attack)
    {
        double minAttack = attack * 0.9;
        double maxAttack = attack * 1.1;

        return (int)Math.Ceiling(new Random().NextDouble() * (maxAttack - minAttack) + minAttack);
    }