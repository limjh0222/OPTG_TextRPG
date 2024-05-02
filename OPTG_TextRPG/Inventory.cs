using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPTG_TextRPG
{
    internal class Inventory
    {

        public static void InventoryMenu()
        {
            int choice = -1;

            while (choice < 0)
            {
                Console.Clear();

                ConsoleUtility.PrintMagenta("■ 인벤토리 ■");
                ConsoleUtility.PrintYellowHighlights("보유 중인 아이템을 ", "관리", "할 수 있습니다.\n");

                Console.WriteLine("\n[아이템 목록]");

                for (int i = 0; i < GameManager.Instance.inventory.Count; i++)
                {
                    GameManager.Instance.inventory[i].PrintItemStatDescription();
                }

                Console.WriteLine("\n1. 장착관리");
                Console.WriteLine("0. 나가기\n");

                choice = ConsoleUtility.PromptMenuChoice(0, 1);
            }

            switch (choice)
            {
                case 0:
                    GameManager.Instance.MainMenu();
                    break;
                case 1:
                    EquipMenu();
                    break;
            }
        }

        public static void EquipMenu()
        {
            int choice = -1;
            while (choice < 0)
            {
                Console.Clear();

                ConsoleUtility.PrintMagenta("■ 인벤토리 - 장착 관리 ■");
                ConsoleUtility.PrintYellowHighlights("보유 중인 아이템을 ", "관리", "할 수 있습니다.\n");

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
    }
}
