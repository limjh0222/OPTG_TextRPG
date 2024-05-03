﻿


public enum ItemType
{
    WEAPON,
    ARMOR
}

public class Item
{
    public string Name { get; }
    public string Desc { get; }

    private ItemType Type;

    public int Atk { get; }
    public int Def { get; }
    public int Hp { get; }

    public int Price { get; }

    public bool IsEquipped { get; private set; }
    public bool IsPurchased { get; private set; }

    public Item() { }
    public Item(string name, string desc, ItemType type, int atk, int def, int hp, int price, bool isEquipped = false, bool isPurchased = false)
    {
        Name = name;
        Desc = desc;
        Type = type;
        Atk = atk;
        Def = def;
        Hp = hp;
        Price = price;
        IsEquipped = isEquipped;
        IsPurchased = isPurchased;
    }

    // 아이템 정보를 보여줄때 타입이 비슷한게 2가지있음.
    // 1. 인벤토리에서 그냥 내가 어느 아이템 가지고 있는지 보여줄 때
    // 2. 장착관리에서 내가 어떤 아이템을 낄지 말지 결정할 때
    internal void PrintItemStatDescription(bool withNumber = false, int idx = 0)
    {
        Console.Write("- ");
        if (withNumber)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write($"{idx} ");
            Console.ResetColor();
        }
        if (IsEquipped)
        {
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("E");
            Console.ResetColor();
            Console.Write("]");
            Console.Write(ConsoleUtility.PadRightForMixedText(Name, 17));
        }
        else Console.Write(ConsoleUtility.PadRightForMixedText(Name, 20));

        Console.Write(" | ");

        if (Atk != 0)
        {
            Console.Write($"공격력 {(Atk >= 0 ? "+" : "")}{(Atk >= 0 ? ConsoleUtility.PadRightForMixedText(Atk.ToString(), 3) : ConsoleUtility.PadRightForMixedText(Atk.ToString(), 4))}");
        }
        else
        {
            Console.Write(ConsoleUtility.PadRightForMixedText("", 11));
        }

        if (Def != 0)
        {
            Console.Write($"방어력 {(Def >= 0 ? "+" : "")}{(Def >= 0 ? ConsoleUtility.PadRightForMixedText(Def.ToString(), 3) : ConsoleUtility.PadRightForMixedText(Def.ToString(), 4))}");
        }
        else
        {
            Console.Write(ConsoleUtility.PadRightForMixedText("", 11));
        }

        if (Hp != 0)
        {
            Console.Write($"체  력 {(Hp >= 0 ? "+" : "")}{(Hp >= 0 ? ConsoleUtility.PadRightForMixedText(Hp.ToString(), 3) : ConsoleUtility.PadRightForMixedText(Hp.ToString(), 4))}");
        }
        else
        {
            Console.Write(ConsoleUtility.PadRightForMixedText("", 11));
        }

        Console.Write(" | ");

        Console.WriteLine(Desc);

    }


    public void PrintStoreItemDescription(bool withNumber = false, int idx = 0)
    {
        Console.Write("- ");
        
        if (withNumber)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("{0} ", idx);
            Console.ResetColor();
            
        }
        Console.Write(ConsoleUtility.PadRightForMixedText(Name, 20));

        Console.Write(" | ");

        if(Atk != 0)
        {
            Console.Write($"공격력 {(Atk >= 0 ? "+" : "")}{(Atk >= 0 ? ConsoleUtility.PadRightForMixedText(Atk.ToString(), 3) : ConsoleUtility.PadRightForMixedText(Atk.ToString(), 4))}");
        }
        else
        {
            Console.Write(ConsoleUtility.PadRightForMixedText("", 11));
        }

        if (Def != 0)
        {
            Console.Write($"방어력 {(Def >= 0 ? "+" : "")}{(Def >= 0 ? ConsoleUtility.PadRightForMixedText(Def.ToString(), 3) : ConsoleUtility.PadRightForMixedText(Def.ToString(), 4))}");
        }
        else
        {
            Console.Write(ConsoleUtility.PadRightForMixedText("", 11));
        }

        if (Hp != 0)
        {
            Console.Write($"체  력 {(Hp >= 0 ? "+" : "")}{(Hp >= 0 ? ConsoleUtility.PadRightForMixedText(Hp.ToString(), 3) : ConsoleUtility.PadRightForMixedText(Hp.ToString(), 4))}");
        }
        else
        {
            Console.Write(ConsoleUtility.PadRightForMixedText("", 11));
        }

        Console.Write(" | ");

        Console.Write(ConsoleUtility.PadRightForMixedText(Desc, 30));

        Console.Write(" | ");

        if (IsPurchased)
        {
            Console.WriteLine("구매완료");
        }
        else
        {
            ConsoleUtility.PrintYellowHighlights("", Price.ToString(), " G\n");
        }
    }

    public void PrintSaleItemDescription(bool withNumber = false, int idx = 0)
    {
        Console.Write("- ");

        if (withNumber)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("{0} ", idx);
            Console.ResetColor();

        }

        if (IsEquipped)
        {
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("E");
            Console.ResetColor();
            Console.Write("]");
            Console.Write(ConsoleUtility.PadRightForMixedText(Name, 17));
        }
        else Console.Write(ConsoleUtility.PadRightForMixedText(Name, 20));

        Console.Write(" | ");

        if (Atk != 0)
        {
            Console.Write($"공격력 {(Atk >= 0 ? "+" : "")}{(Atk >= 0 ? ConsoleUtility.PadRightForMixedText(Atk.ToString(), 3) : ConsoleUtility.PadRightForMixedText(Atk.ToString(), 4))}");
        }
        else
        {
            Console.Write(ConsoleUtility.PadRightForMixedText("", 11));
        }

        if (Def != 0)
        {
            Console.Write($"방어력 {(Def >= 0 ? "+" : "")}{(Def >= 0 ? ConsoleUtility.PadRightForMixedText(Def.ToString(), 3) : ConsoleUtility.PadRightForMixedText(Def.ToString(), 4))}");
        }
        else
        {
            Console.Write(ConsoleUtility.PadRightForMixedText("", 11));
        }

        if (Hp != 0)
        {
            Console.Write($"체  력 {(Hp >= 0 ? "+" : "")}{(Hp >= 0 ? ConsoleUtility.PadRightForMixedText(Hp.ToString(), 3) : ConsoleUtility.PadRightForMixedText(Hp.ToString(), 4))}");
        }
        else
        {
            Console.Write(ConsoleUtility.PadRightForMixedText("", 11));
        }

        Console.Write(" | ");

        Console.Write(ConsoleUtility.PadRightForMixedText(Desc, 30));

        Console.Write(" | ");

        ConsoleUtility.PrintYellowHighlights("", (Price * 0.8).ToString(), " G\n");
    }

    internal void ToggleEquipStatus()
    {
        IsEquipped = !IsEquipped;
    }

    internal void Purchase()
    {
        IsPurchased = true;
    }

    internal void Sale()
    {
        // 판매 시 장착중인지 판별
        if(IsEquipped)
        {
            // 장착 중이면 판매 x
            ConsoleUtility.PrintMagenta("\n장착 중인 아이템입니다. 장착을 해제해주세요.");
            Console.ReadKey();
        }
        else
        {
            // 미장착 중이면 판매 o
            GameManager.Instance.player.Gold += (int)(Price * 0.8);
            IsPurchased = false;
            GameManager.Instance.inventory.Remove(this);
        }
    }
}