public class Player
{
    public string Name { get; }
    public string Job { get; }
    public int Level { get; }
    public int Atk { get; }
    public int Def { get; }
    public int Hp { get; }
    public int Gold { get; set; }

    public Player(string name, string job, int level, int atk, int def, int hp, int gold)
    {
        Name = name;
        Job = job;
        Level = level;
        Atk = atk;
        Def = def;
        Hp = hp;
        Gold = gold;
    }

    public static Player ChooseJob(int jobChoice, string name)
    {
        switch (jobChoice)
        {
            case 1:
                return Warrior(name);
            case 2:
                return Mage(name);
            case 3:
                return Rogue(name);
            case 4:
                return Archer(name);
            default:
                Console.WriteLine("직업을 선택해주세요");
                Console.WriteLine("직업을 다시 선택해주세요:");
                int newChoice = int.Parse(Console.ReadLine());
                return ChooseJob(newChoice, name); // 다시 직업 선택
        }
    }

    public  Player Warrior(string name)
    {
        return new Player(name, "전사", 1, 25, 15, 120, 1500);
    }

    public  Player Mage(string name)
    {
        return new Player(name, "마법사", 1, 15, 10, 80, 1500);
    }

    public  Player Rogue(string name)
    {
        return new Player(name, "도적", 1, 20, 12, 90, 1500);
    }

    public  Player Archer(string name)
    {
        return new Player(name, "궁수", 1, 18, 18, 100, 1500);
    }
}