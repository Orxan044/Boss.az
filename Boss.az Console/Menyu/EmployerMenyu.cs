using Boss.az.Menyu.ByShowMenyu;
using Boss.az.Menyu.MainMenyu;
using Boss.az.MenyuHelper;
namespace Boss.az.Menyu;
using Boss.az.Models;

internal class EmployerMenyu
{
    public static void Menyu(List<Specialization> SpecializationList)
    {
        string[] MenyuList = { "Creat Vacancy", "Show Vacancies", "Show Workers", "Quit" };
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
                    RegistherMenyu.DataStatus = Person.Status.Employer;
                    if (MenyuList[Index] == "Creat Vacancy") { Program.PostGreat(); }
                    if (MenyuList[Index] == "Show Vacancies") Program.ShowVacancy();
                    if (MenyuList[Index] == "Show Workers") ShowCvsByEmployer.Menyu(SpecializationList);
                    return;
            }

        } while (true);
    }


}
