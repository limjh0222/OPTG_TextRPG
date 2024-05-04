using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OPTG_TextRPG
{
    public class Player
    {

        public static void StatusMenu()
        {
            int choice = -1;
            while (choice < 0)
            {
                Console.Clear();

                ConsoleUtility.PrintColor(Color.MAGENTA, "■ 상태보기 ■");
                ConsoleUtility.PrintYellowHighlights("캐릭터의 ", "정보", "가 표기됩니다.\n");

                ConsoleUtility.PrintYellowHighlights("\nLv. ", GameManager.Instance.player.Level.ToString("00"), "\n");
                ConsoleUtility.PrintGreenHighlights("", $"{GameManager.Instance.player.Name}");
                ConsoleUtility.PrintYellowHighlights(" ( ", $"{GameManager.Instance.player.Job}", " )\n");

                // TODO : 능력치 강화분을 표현하도록 변경

                int bonusAtk = GameManager.Instance.inventory.Select(item => item.IsEquipped ? item.Atk : 0).Sum();
                int bonusDef = GameManager.Instance.inventory.Select(item => item.IsEquipped ? item.Def : 0).Sum();
                int bonusHp = GameManager.Instance.inventory.Select(item => item.IsEquipped ? item.Hp : 0).Sum();
                ConsoleUtility.PrintYellowHighlights("공격력 : ", (GameManager.Instance.player.Atk + bonusAtk).ToString(), bonusAtk != 0 ? (bonusAtk > 0 ? $" (+{bonusAtk})\n" : $" ({bonusAtk})\n") : "\n");
                ConsoleUtility.PrintYellowHighlights("방어력 : ", (GameManager.Instance.player.Def + bonusDef).ToString(), bonusDef != 0 ? (bonusDef > 0 ? $" (+{bonusDef})\n" : $" ({bonusDef})\n") : "\n");
                ConsoleUtility.PrintYellowHighlights("체 력 : ", (GameManager.Instance.player.MaxHp + bonusHp).ToString(), bonusHp != 0 ? (bonusHp > 0 ? $" (+{bonusHp})\n" : $" ({bonusHp})\n") : "\n");
                ConsoleUtility.PrintYellowHighlights("마 력 : ", (GameManager.Instance.player.MaxMp + bonusHp).ToString(), bonusHp != 0 ? (bonusHp > 0 ? $" (+{bonusHp})\n" : $" ({bonusHp})\n") : "\n");
                ConsoleUtility.PrintYellowHighlights("Gold : ", GameManager.Instance.player.Gold.ToString(), "\n");

                Console.WriteLine("\n0. 뒤로가기\n");

                choice = ConsoleUtility.PromptMenuChoice(0, 0);
            }

            switch (choice)
            {
                case 0:
                    GameManager.Instance.MainMenu();
                    break;
            }
        }

        public static void InventoryMenu()
        {
            int choice = -1;

            while (choice < 0)
            {
                Console.Clear();

                ConsoleUtility.PrintColor(Color.MAGENTA, "■ 인벤토리 ■");

                ConsoleUtility.PrintYellowHighlights("보유 중인 아이템을 ", "관리", "할 수 있습니다.\n");

                Console.WriteLine("\n[아이템 목록]");

                for (int i = 0; i < GameManager.Instance.inventory.Count; i++)
                {
                    GameManager.Instance.inventory[i].PrintItemStatDescription();
                }

                Console.WriteLine("\n1. 장착관리");
                Console.WriteLine("2. 아이템 판매");
                Console.WriteLine("0. 나가기\n");

                choice = ConsoleUtility.PromptMenuChoice(0, 2);
            }

            switch (choice)
            {
                case 0:
                    GameManager.Instance.MainMenu();
                    break;
                case 1:
                    EquipMenu();
                    break;
                case 2:
                    // 판매
                    SaleMenu();
                    break;
            }
        }

        public static void EquipMenu()
        {
            int choice = -1;
            while (choice < 0)
            {
                Console.Clear();

                ConsoleUtility.PrintColor(Color.MAGENTA, "■ 인벤토리 - 장착 관리 ■");

                ConsoleUtility.PrintYellowHighlights("보유 중인 아이템을 ", "장착", "할 수 있습니다.\n");

                Console.WriteLine("\n[아이템 목록]");
                for (int i = 0; i < GameManager.Instance.inventory.Count; i++)
                {
                    GameManager.Instance.inventory[i].PrintItemStatDescription(true, i + 1); // 나가기가 0번 고정, 나머지가 1번부터 배정
                }

                Console.WriteLine("\n0. 나가기\n");

                choice = ConsoleUtility.PromptMenuChoice(0, GameManager.Instance.inventory.Count);
            }

            switch (choice)
            {
                case 0:
                    InventoryMenu();
                    break;
                default:
                    GameManager.Instance.inventory[choice - 1].ToggleEquipStatus();
                    EquipMenu();
                    break;
            }
        }

        public static void SaleMenu()
        {
            // 아이템 불러오기
            int choice = -1;
            while (choice < 0)
            {
                Console.Clear();

                ConsoleUtility.PrintColor(Color.MAGENTA, "■ 인벤토리 - 아이템 판매 ■");
                ConsoleUtility.PrintYellowHighlights("보유 중인 아이템을 ", "판매", "할 수 있습니다.\n");

                Console.WriteLine("\n[보유 골드]");
                ConsoleUtility.PrintYellowHighlights("", GameManager.Instance.player.Gold.ToString(), " G\n");

                Console.WriteLine("\n[아이템 목록]");
                for (int i = 0; i < GameManager.Instance.inventory.Count; i++)
                {
                    GameManager.Instance.inventory[i].PrintSaleItemDescription(true, i + 1); // 나가기가 0번 고정, 나머지가 1번부터 배정
                }

                Console.WriteLine("\n0. 나가기\n");

                choice = ConsoleUtility.PromptMenuChoice(0, GameManager.Instance.inventory.Count);
            }

            switch (choice)
            {
                case 0:
                    InventoryMenu();
                    break;
                default:
                    GameManager.Instance.inventory[choice - 1].Sale();
                    SaleMenu();
                    break;
            }
        }
    }
}
