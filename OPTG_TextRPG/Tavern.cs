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
                Console.WriteLine("1. 푹신한 침대! 따뜻한 목욕! \t [2000G]  (HP/MP 100% 회복)");
                Console.WriteLine("2. 가게만의 특선 라구 스튜!  \t [1100G]  (  HP   40% 회복)");
                Console.WriteLine("3. 부드러운 빵과 신선한 우유!\t  [600G]  (  HP   20% 회복)");
                Console.WriteLine("4. 드워프가 만든 특제 위스키!\t [1000G]  (  MP   60% 회복)");
                Console.WriteLine("5. 시원한 슈와슈와맥주 한잔! \t  [500G]  (  MP   30% 회복)\n");
                Console.WriteLine("0. 나간다.\n");
                choice = ConsoleUtility.PromptMenuChoice(0, 5);
            }
            switch (choice)
            {
                case 0:
                    break;
                case 1:
                    MaxAllHealing();
                    TavernManu();
                    break;
                case 2:
                    HalfHpHealing();
                    TavernManu();
                    break;
                case 3:
                    littleHpHealing();
                    TavernManu();
                    break;
                case 4:
                    HalfMpHealing();
                    TavernManu();
                    break;
                case 5:
                    littleMpHealing();
                    TavernManu();
                    break;
            }
        }

        public void MaxAllHealing()
        {
            if (GameManager.Instance.player.Gold >= 2000)
            {
                if (GameManager.Instance.player.Hp == GameManager.Instance.player.MaxHp && GameManager.Instance.player.Mp == GameManager.Instance.player.MaxMp)
                {
                    Console.WriteLine("\n체력과 마력이 이미 최대치 입니다!");
                    Thread.Sleep(1000);
                }
                else
                {
                    GameManager.Instance.player.Gold -= 2000;
                    GameManager.Instance.player.Hp += GameManager.Instance.player.MaxHp;
                    GameManager.Instance.player.Mp += GameManager.Instance.player.MaxMp;
                    Console.WriteLine("\n체력과 마력이 [100%] 회복되었습니다!");
                    Thread.Sleep(1000);
                }
            }
            else
            {
                Console.WriteLine("\n골드가 부족하여 회복할 수 없습니다.");
                Thread.Sleep(1000);
            }
        }

        public void HalfHpHealing()
        {
            if (GameManager.Instance.player.Gold >= 1100)
            {
                if (GameManager.Instance.player.Hp == GameManager.Instance.player.MaxHp)
                {
                    Console.WriteLine("\n체력이 이미 최대치 입니다!");
                    Thread.Sleep(1000);
                }
                else
                {
                    GameManager.Instance.player.Gold -= 1100;
                    GameManager.Instance.player.Hp += (int)(GameManager.Instance.player.MaxHp * 0.4);
                    Console.WriteLine("\n체력이 [40%] 회복되었습니다!");
                    Thread.Sleep(1000);
                }
            }
            else
            {
                Console.WriteLine("\n골드가 부족하여 회복할 수 없습니다.");
                Thread.Sleep(1000);
            }
        }
        public void littleHpHealing()
        {
            if (GameManager.Instance.player.Gold >= 600)
            {
                if (GameManager.Instance.player.Hp == GameManager.Instance.player.MaxHp)
                {
                    Console.WriteLine("\n체력이 이미 최대치 입니다!");
                    Thread.Sleep(1000);
                }
                else
                {
                    GameManager.Instance.player.Gold -= 600;
                    GameManager.Instance.player.Hp += (int)(GameManager.Instance.player.MaxHp * 0.2);
                    Console.WriteLine("\n체력이 [20%] 회복되었습니다!");
                    Thread.Sleep(1000);
                }
            }
            else
            {
                Console.WriteLine("\n골드가 부족하여 회복할 수 없습니다.");
                Thread.Sleep(1000);
            }
        }

        public void HalfMpHealing()
        {
            if (GameManager.Instance.player.Gold >= 1000)
            {
                if (GameManager.Instance.player.Mp == GameManager.Instance.player.MaxMp)
                {
                    Console.WriteLine("\n마력이 이미 최대치 입니다!");
                    Thread.Sleep(1000);
                }
                else
                {
                    GameManager.Instance.player.Gold -= 1000;
                    GameManager.Instance.player.Mp += (int)(GameManager.Instance.player.MaxMp * 0.6);
                    Console.WriteLine("\n마력이 [60%] 회복되었습니다!");
                    Thread.Sleep(1000);
                }
            }
            else
            {
                Console.WriteLine("\n골드가 부족하여 회복할 수 없습니다.");
                Thread.Sleep(1000);
            }
        }
        public void littleMpHealing()
        {
            if (GameManager.Instance.player.Gold >= 500)
            {
                if (GameManager.Instance.player.Mp == GameManager.Instance.player.MaxMp)
                {
                    Console.WriteLine("\n마력이 이미 최대치 입니다!");
                    Thread.Sleep(1000);
                }
                else
                {
                    GameManager.Instance.player.Gold -= 500;
                    GameManager.Instance.player.Mp += (int)(GameManager.Instance.player.MaxMp * 0.3);
                    Console.WriteLine("\n마력이 [30%] 회복되었습니다!");
                    Thread.Sleep(1000);
                }
            }
            else
            {
                Console.WriteLine("\n골드가 부족하여 회복할 수 없습니다.");
                Thread.Sleep(1000);
            }
        }
    }
}