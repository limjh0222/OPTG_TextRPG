using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OPTG_TextRPG
{
    internal class Store
    {
        public static void StoreMenu()
        {
            int choice = -1;
            while (choice < 0)
            {
                Console.Clear();

                ConsoleUtility.PrintColor(Color.MAGENTA, "■ 상점 ■");
                ConsoleUtility.PrintYellowHighlights("필요한 아이템을 얻을 수 있는 ", "상점", "입니다.\n");

                Console.WriteLine("\n[보유 골드]");
                ConsoleUtility.PrintYellowHighlights("", GameManager.Instance.player.Gold.ToString(), " G\n");

                Console.WriteLine("\n[아이템 목록]");
                for (int i = 0; i < GameManager.Instance.storeInventory.Count; i++)
                {
                    GameManager.Instance.storeInventory[i].PrintStoreItemDescription();
                }

                Console.WriteLine("\n1. 아이템 구매");
                Console.WriteLine("0. 나가기\n");

                choice = ConsoleUtility.PromptMenuChoice(0, 1);
            }

            switch (choice)
            {
                case 0:
                    GameManager.Instance.MainMenu();
                    break;
                case 1:
                    PurchaseMenu();
                    break;
            }
        }

        private static void PurchaseMenu(string? prompt = null)
        {
            if (prompt != null)
            {
                ConsoleUtility.PrintColor(Color.DARKYELLOW, prompt);
                Console.ReadKey();
            }

            int choice = -1;
            while (choice < 0)
            {
                Console.Clear();

                ConsoleUtility.PrintColor(Color.MAGENTA,"■ 상점 ■");
                ConsoleUtility.PrintYellowHighlights("필요한 아이템을 얻을 수 있는 ", "상점", "입니다.\n");

                Console.WriteLine("\n[보유 골드]");
                ConsoleUtility.PrintYellowHighlights("", GameManager.Instance.player.Gold.ToString(), " G\n");

                Console.WriteLine("\n[아이템 목록]");
                for (int i = 0; i < GameManager.Instance.storeInventory.Count; i++)
                {
                    GameManager.Instance.storeInventory[i].PrintStoreItemDescription(true, i + 1);
                }

                Console.WriteLine("\n0. 나가기\n");

                choice = ConsoleUtility.PromptMenuChoice(0, GameManager.Instance.storeInventory.Count);
            }


            switch (choice)
            {
                case 0:
                    StoreMenu();
                    break;
                default:
                    // 1 : 이미 구매한 경우
                    if (GameManager.Instance.storeInventory[choice - 1].IsPurchased) // index 맞추기
                    {
                        PurchaseMenu("\n이미 구매한 아이템입니다.");
                    }
                    // 2 : 돈이 충분해서 살 수 있는 경우
                    else if (GameManager.Instance.player.Gold >= GameManager.Instance.storeInventory[choice - 1].Price)
                    {
                        GameManager.Instance.player.Gold -= GameManager.Instance.storeInventory[choice - 1].Price;
                        GameManager.Instance.storeInventory[choice - 1].Purchase();
                        GameManager.Instance.inventory.Add(GameManager.Instance.storeInventory[choice - 1]);
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
}
