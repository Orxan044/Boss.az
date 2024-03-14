namespace Boss.az.Menyu.MainMenyu;
using Boss.az.Models;

internal class MainPage
{
    public static void MenyuLoginAndRegisther(List<Specialization> SpecializationList)
    {
        string[] MenyuList = { "Sign In", "Register" };
        int Index = 0;

        do
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("                     Boos.az                         \n");
            Console.ResetColor();
            for (int i = 0; i < MenyuList.Length; i++)
            {
                if (i == Index)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("=> ");
                }
                else Console.Write("   ");
                Console.WriteLine(MenyuList[i]);
                Console.ResetColor();
            }
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    Index = Math.Max(0, Index - 1);
                    break;
                case ConsoleKey.DownArrow:
                    Index = Math.Min(MenyuList.Length - 1, Index + 1);
                    break;
                case ConsoleKey.Enter:
                    if (MenyuList[Index] == "Sign In") LoginMenyu.Menyu(SpecializationList);
                    else RegistherMenyu.WorkerOREmployer();
                    return;
            }

        } while (true);
    }

}
