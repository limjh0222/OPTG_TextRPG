


using OPTG_TextRPG;
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

    private Player player;
    public List<Item> inventory {  get; set; }
    private List<Item> storeInventory;

    public GameManager()
    {
        if (instance == null)
        {
            instance = this;
        }
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

        ConsoleUtility.PrintYellowHighlights("\n", "이름", "을 입력해주세요: ");
        name = Console.ReadLine();
        DataManager.Instance.InitJob(name);

        player = DataManager.Instance.JobDB[choice];
        //player.Gold = 99999; // 테스트용 골드

        inventory = new List<Item>();

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
            Console.WriteLine("3. 상점\n");

            // 2. 선택한 결과를 검증함
            choice = ConsoleUtility.PromptMenuChoice(1, 3);
        }

        // 3. 선택한 결과에 따라 보내줌
        switch (choice)
        {
            case 1:
                StatusMenu();
                break;
            case 2:
                Inventory.InventoryMenu();
                break;
            case 3:
                StoreMenu();
                break;
        }
        MainMenu();
    }

    private void StatusMenu()
    {
        int choice = -1;
        while (choice < 0)
        {
            Console.Clear();

            ConsoleUtility.PrintMagenta("■ 상태보기 ■");
            ConsoleUtility.PrintYellowHighlights("캐릭터의 ", "정보", "가 표기됩니다.\n");

            ConsoleUtility.PrintYellowHighlights("\nLv. ", player.Level.ToString("00"), "\n");
            ConsoleUtility.PrintGreenHighlights("", $"{player.Name}");
            ConsoleUtility.PrintYellowHighlights(" ( ", $"{player.Job}", " )\n");

            // TODO : 능력치 강화분을 표현하도록 변경

            int bonusAtk = inventory.Select(item => item.IsEquipped ? item.Atk : 0).Sum();
            int bonusDef = inventory.Select(item => item.IsEquipped ? item.Def : 0).Sum();
            int bonusHp = inventory.Select(item => item.IsEquipped ? item.Hp : 0).Sum();
            ConsoleUtility.PrintYellowHighlights("공격력 : ", (player.Atk + bonusAtk).ToString(), bonusAtk != 0 ? (bonusAtk > 0 ? $" (+{bonusAtk})\n" : $" ({bonusAtk})\n") : "\n");
            ConsoleUtility.PrintYellowHighlights("방어력 : ", (player.Def + bonusDef).ToString(), bonusDef != 0 ? (bonusDef > 0 ? $" (+{bonusDef})\n" : $" ({bonusDef})\n") : "\n");
            ConsoleUtility.PrintYellowHighlights("체 력 : ", (player.Hp + bonusHp).ToString(), bonusHp != 0 ? (bonusHp > 0 ? $" (+{bonusHp})\n" : $" ({bonusHp})\n") : "\n");

            ConsoleUtility.PrintYellowHighlights("Gold : ", player.Gold.ToString(), "\n");

            Console.WriteLine("\n0. 뒤로가기\n");

            choice = ConsoleUtility.PromptMenuChoice(0, 0);
        }

        switch (choice)
        {
            case 0:
                MainMenu();
                break;
        }
    }

    private void StoreMenu()
    {
        int choice = -1;
        while(choice < 0 )
        {
            Console.Clear();

            ConsoleUtility.PrintMagenta("■ 상점 ■");
            ConsoleUtility.PrintYellowHighlights("필요한 아이템을 얻을 수 있는 ", "상점", "입니다.\n");

            Console.WriteLine("\n[보유 골드]");
            ConsoleUtility.PrintYellowHighlights("", player.Gold.ToString(), " G\n");

            Console.WriteLine("\n[아이템 목록]");
            for (int i = 0; i < storeInventory.Count; i++)
            {
                storeInventory[i].PrintStoreItemDescription();
            }

            Console.WriteLine("\n1. 아이템 구매");
            Console.WriteLine("0. 나가기\n");

            choice = ConsoleUtility.PromptMenuChoice(0, 1);
        }
        
        switch (choice)
        {
            case 0:
                MainMenu();
                break;
            case 1:
                PurchaseMenu();
                break;
        }
    }

    private void PurchaseMenu(string? prompt = null)
    {
        if (prompt != null)
        {
            // 1초간 메시지를 띄운 다음에 다시 진행
            Console.Clear();
            ConsoleUtility.PrintMagenta(prompt);
            Thread.Sleep(1000);
        }

        int choice = -1;
        while(choice < 0)
        {
            Console.Clear();

            ConsoleUtility.PrintMagenta("■ 상점 ■");
            ConsoleUtility.PrintYellowHighlights("필요한 아이템을 얻을 수 있는 ", "상점", "입니다.\n");

            Console.WriteLine("\n[보유 골드]");
            ConsoleUtility.PrintYellowHighlights("", player.Gold.ToString(), " G\n");

            Console.WriteLine("\n[아이템 목록]");
            for (int i = 0; i < storeInventory.Count; i++)
            {
                storeInventory[i].PrintStoreItemDescription(true, i + 1);
            }

            Console.WriteLine("\n0. 나가기\n");

            choice = ConsoleUtility.PromptMenuChoice(0, storeInventory.Count);
        }
        

        switch (choice)
        {
            case 0:
                StoreMenu();
                break;
            default:
                // 1 : 이미 구매한 경우
                if (storeInventory[choice - 1].IsPurchased) // index 맞추기
                {
                    PurchaseMenu("이미 구매한 아이템입니다.");
                }
                // 2 : 돈이 충분해서 살 수 있는 경우
                else if(player.Gold >= storeInventory[choice - 1].Price)
                {
                    player.Gold -= storeInventory[choice - 1].Price;
                    storeInventory[choice - 1].Purchase();
                    inventory.Add(storeInventory[choice - 1]);
                    PurchaseMenu();
                }
                // 3 : 돈이 모자라는 경우
                else
                {
                    PurchaseMenu("Gold가 부족합니다.");
                }
                break;
        }
    }
}


