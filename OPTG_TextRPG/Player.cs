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
                Console.WriteLine("잘못된 선택입니다. 1부터 4 사이의 숫자를 입력하세요.");
                return ChooseJob(int.Parse(Console.ReadLine()), name);

        }
      
    }

    public static Player Warrior(string name)
    {
        return new Player(name, "전사", 1, 25, 15, 120, 1500);
    }

    public  static  Player Mage(string name)
    {
        return new Player(name, "마법사", 1, 15, 10, 80, 1500);
    }

    public  static Player Rogue(string name)
    {
        return new Player(name, "도적", 1, 20, 12, 90, 1500);
    }

    public  static Player Archer(string name)
    {
        return new Player(name, "궁수", 1, 18, 18, 100, 1500);
    }
}