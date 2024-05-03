


using OPTG_TextRPG;
using System.Threading;
using System.Xml.Serialization;

public class Program
{
    public static void Main(string[] args)
    {
        GameManager gameManager = new GameManager();
        gameManager.StartGame();
    }
}

public class GameManager
{
    //// 싱글톤
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    DungeonEvent dungeonEvent = new DungeonEvent();
    public PlayerData player;
    public BattleManager battleManager;
    public List<Item> inventory {  get; set; }
    public List<Item> storeInventory;
    
    public GameManager()
    {
        if (instance == null)
        {
            instance = this;
        }

        battleManager = new BattleManager();
        InitializeGame();
    }

    private void InitializeGame()
    {
        int choice = -1;
        string name;

        while(choice < 0)
        {
            Console.Clear();
            ConsoleUtility.PrintYellowHighlights("", "직업", "을 선택해주세요.\n");
            Console.WriteLine("\n1. 전사");
            Console.WriteLine("2. 마법사");
            Console.WriteLine("3. 도적");
            Console.WriteLine("4. 궁수\n");

            choice = ConsoleUtility.PromptMenuChoice(1, 4);
        }

        ConsoleUtility.PrintYellowHighlights("\n플레이어의 ", "이름", "을 입력해주세요.\n");
        Console.Write(">> ");
        name = Console.ReadLine();

        DataManager.Instance.InitJob(name);
        player = DataManager.Instance.JobDB[choice];
        player.Gold = 9999;

        inventory = new List<Item>();

        DataManager.Instance.InitMonster();
        DataManager.Instance.InitItem();
        storeInventory = DataManager.Instance.ItemDB;
    }

    public void StartGame()
    {
        Console.Clear();
        MainMenu();
    }

    public void MainMenu()
    {
        // 구성
        int choice = -1;
        while(choice < 0)
        {
            // 0. 화면 정리
            Console.Clear();

            // 1. 선택 멘트를 줌
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            ConsoleUtility.PrintYellowHighlights("이곳에서 던전으로 들어가기 전 ", "활동", "을 할 수 있습니다.\n");

            Console.WriteLine("\n1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("4. 던전 입장\n");

            // 2. 선택한 결과를 검증함
            choice = ConsoleUtility.PromptMenuChoice(1, 4);
        }

        // 3. 선택한 결과에 따라 보내줌
        switch (choice)
        {
            case 1:
                Player.StatusMenu();
                break;
            case 2:
                Player.InventoryMenu();
                break;
            case 3:
                Store.StoreMenu();
                break;
            case 4:
                battleManager.BatteleStart();
                break;
        }
        MainMenu();
    }
}


