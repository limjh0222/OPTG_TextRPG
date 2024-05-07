


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
    public Tavern tavern;
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
        tavern = new Tavern();
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
            ConsoleUtility.PrintYellowHighlights("\n", "직업", "을 선택해주세요.\n");
            Console.WriteLine("\n1. 전사");
            Console.WriteLine("2. 마법사");
            Console.WriteLine("3. 도적");
            Console.WriteLine("4. 궁수\n");

            choice = ConsoleUtility.PromptMenuChoice(1, 5); // 최종 제출 때 수정 1,4
        }

        ConsoleUtility.PrintYellowHighlights("\n플레이어의 ", "이름", "을 입력해주세요.\n");
        Console.Write(">> ");
        name = Console.ReadLine();

        player = DataManager.Instance.InitJob(name, choice);

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
            Console.WriteLine("\n스파르타 마을에 오신 여러분 환영합니다.");
            ConsoleUtility.PrintYellowHighlights("이곳에서 던전으로 들어가기 전 ", "활동", "을 할 수 있습니다.\n");

            Console.WriteLine("\n1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("4. 선술집");
            Console.WriteLine("5. 던전으로\n");

            // 2. 선택한 결과를 검증함
            choice = ConsoleUtility.PromptMenuChoice(1, 5);
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
                tavern.TavernManu();
                break;
            case 5:
                if(player.Hp == 0)
                {
                    Console.WriteLine("\n입구를 지키고있는 경비대가 당신을 막아섰습니다.");
                    Console.WriteLine("경비대: 체력을 회복하지 않으면 입장하실 수 없습니다.\n\n");
                    Console.WriteLine("선술집으로가서 회복해야한다.\n");
                    Console.WriteLine("아무키나 입력해주세요.");
                    Console.ReadKey();
                    break;
                }
                else battleManager.BattleStart();
                break;

        }
        MainMenu();
    }
}


