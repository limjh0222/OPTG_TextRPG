
public enum Color
{
    DARKYELLOW = 6,
    RED = 12,
    MAGENTA = 13
    //여기에 사용하고 싶은 색상을 추가하세요.
}

internal class ConsoleUtility
{
    public static int PromptMenuChoice(int min, int max)
    {
        PrintYellowHighlights("원하시는 ", "행동", "을 선택해주세요.\n");
        Console.Write(">> ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice >= min && choice <= max)
        {
            return choice;
        }
        PrintColor(Color.RED, "\n잘못된 입력입니다. 다시 입력해주세요.");
        Console.ReadKey();
        return -1;
    }

    public static void PrintColor(Color color, string str)
    {
        //ConsoleUtility.PrintColor(Color.RED, "안녕하세요"); 형식으로 사용합니다. 
        Console.ForegroundColor = (ConsoleColor)color;
        Console.WriteLine(str);
        Console.ResetColor();
    }

    public static void PrintGreenHighlights(string str1, string str2, string str3 = "")
    {
        Console.Write(str1);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(str2);
        Console.ResetColor();
        Console.Write(str3);
    }
    public static void PrintYellowHighlights(string str1, string str2, string str3 = "")
    {
        Console.Write(str1);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(str2);
        Console.ResetColor();
        Console.Write(str3);
    }

    public static int GetPrintableLength(string str)
    {
        int length = 0;
        foreach (char c in str)
        {
            if (char.GetUnicodeCategory(c) == System.Globalization.UnicodeCategory.OtherLetter)
            {
                length += 2; // 한글과 같은 넓은 문자에 대해 길이를 2로 취급
            }
            else
            {
                length += 1; // 나머지 문자에 대해 길이를 1로 취급
            }
        }

        return length;
    }

    public static string PadRightForMixedText(string str, int totalLength)
    {
        // 가나다
        // 111111
        int currentLength = GetPrintableLength(str);
        int padding = totalLength - currentLength;
        return str.PadRight(str.Length + padding);
    }
}