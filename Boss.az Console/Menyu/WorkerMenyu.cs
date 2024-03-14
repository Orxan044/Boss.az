using Boss.az.Menyu.ByShowMenyu;
using Boss.az.MenyuHelper;
using Boss.az.Models;
using Boss.az.Person;

namespace Boss.az.Menyu;

internal class WorkerMenyu
{
    public static void Menyu(List<Specialization> SpecializationList)
    {
        string[] MenyuList = { "Creat CV", "Show CV","Show Vacancies","Quit" };
        int Index = 0;

        do
        {
            Console.Clear();
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
                    if (MenyuList[Index] == "Creat CV") Program.PostGreat();
                    if (MenyuList[Index] == "Show CV") Program.ShowCV();
                    if (MenyuList[Index] == "Show Vacancies") ShowVacansiesByWorker.Menyu(SpecializationList);
                    return;
            }

        } while (true);
    }
}
