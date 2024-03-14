using Boss.az.MenyuHelper;
using Boss.az.Person;

namespace Boss.az.Menyu.MainMenyu;

internal class RegistherMenyu
{
    public static Status DataStatus { get; set; }
    public static void WorkerOREmployer()
    {
        string[] MenyuList = { "Worker", "Employer" };
        int Index = 0;

        do
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("What Name Would You Like To Register With?");
            Console.ResetColor();
            for (int i = 0; i < MenyuList.Length; i++)
            {
                if (i == Index)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
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
                    Console.Clear();
                    Index = Math.Max(0, Index - 1);
                    break;
                case ConsoleKey.DownArrow:
                    Console.Clear();
                    Index = Math.Min(MenyuList.Length - 1, Index + 1);
                    break;
                case ConsoleKey.Enter:
                    Console.Clear();
                    if (MenyuList[Index] == "Worker") { DataStatus = Status.Worker; Program.UserGreat(); }
                    else if (MenyuList[Index] == "Employer") { DataStatus = Status.Employer; Program.UserGreat(); }
                    //MainPage.MenyuLoginAndRegisther(List < Specialization > SpecializationList);
                    return;
            }

        } while (true);
    }

}
