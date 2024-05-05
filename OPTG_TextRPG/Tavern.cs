using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OPTG_TextRPG
{

    public class Tavern
    {
        public void TavernManu()
        {
            int choice = -1;
            while (choice < 0)
            {
                Console.Clear();
                Console.WriteLine("\n========== [스파르타 선술집] ==========");
                Console.WriteLine("\n어머, 어서오세요. 모험가님.");
                Console.WriteLine("스파르타 선술집에 오신걸 환영합니다.");
                Console.WriteLine("찾으시는게 있으신가요?\n");
                Console.WriteLine($"[소지한 골드: {GameManager.Instance.player.Gold} Gold]\n");
                Console.WriteLine("1. 푹신한 침대! 따뜻한 목욕! \t [2500G]  (HP/MP 100% 회복)");
                Console.WriteLine("2. 가게만의 특선 라구 스튜!  \t [1100G]  (HP/MP  40% 회복)");
                Console.WriteLine("3. 시원한 슈와슈와맥주 한잔! \t  [600G]  (HP/MP  20% 회복)\n");
                Console.WriteLine("0. 나간다.\n");
                choice = ConsoleUtility.PromptMenuChoice(0, 3);
            }
            switch (choice)
            {
                case 0:
                    break;
                case 1:
                    MaxHealing();
                    TavernManu();
                    break;
                case 2:
                    HalfHealing();
                    TavernManu();
                    break;
                case 3:
                    littleHealing();
                    TavernManu();
                    break;
            }
        }
        public void MaxHealing()
        {
            if (GameManager.Instance.player.Gold >= 2500)
            {
                GameManager.Instance.player.Gold -= 2500;
                GameManager.Instance.player.Hp += GameManager.Instance.player.MaxHp;
                GameManager.Instance.player.Mp += GameManager.Instance.player.MaxMp;
                Console.WriteLine("\n체력과 마력이 [100%] 회복되었습니다!");
            }
            else
            {
                Console.WriteLine("\n골드가 부족하여 회복할 수 없습니다.");
                Thread.Sleep(1000);
            }
        }
        public void HalfHealing()
        {
            if (GameManager.Instance.player.Gold >= 1100)
            {
                GameManager.Instance.player.Gold -= 1100;
                GameManager.Instance.player.Hp += (int)(GameManager.Instance.player.MaxHp * 0.4);
                GameManager.Instance.player.Mp += (int)(GameManager.Instance.player.MaxHp * 0.4);
                Console.WriteLine("\n체력과 마력이 [40%] 회복되었습니다!");
                Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine("\n골드가 부족하여 회복할 수 없습니다.");
                Thread.Sleep(1000);
            }
        }
        public void littleHealing()
        {
            if (GameManager.Instance.player.Gold >= 600)
            {
                GameManager.Instance.player.Gold -= 600;
                GameManager.Instance.player.Hp += (int)(GameManager.Instance.player.MaxHp * 0.2);
                GameManager.Instance.player.Mp += (int)(GameManager.Instance.player.MaxMp * 0.2);
                Console.WriteLine("\n체력과 마력이 [20%] 회복되었습니다!");
                Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine("\n골드가 부족하여 회복할 수 없습니다.");
                Thread.Sleep(1000);
            }
        }
    }
}