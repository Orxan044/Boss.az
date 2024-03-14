namespace Boss.az.Menyu.ByShowMenyu;
using Boss.az.MenyuHelper;
using Boss.az.Models;
using Boss.az.Model;

internal class ShowVacansiesByWorker
{
    public static List<Vacancy> MenyuList = new();
    public static int Index = 0;
    public static void Menyu(List<Specialization> SpecializationList)
    {
        Console.Clear();
        SpecializationMenyu.Menyu(SpecializationList);
        foreach (var employer in Program.employerdb.Employers)
            foreach (var vacancy in employer.Vacancies)
                if (vacancy.SpecializationName == SpecializationMenyu.DateSpecialization)
                    MenyuList.Add(vacancy);
        Console.Clear();
        do
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Back To <ESC>\n\n");
            Console.ResetColor();

            for (int i = 0; i < MenyuList.Count; i++)
            {
                if (i == Index)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("=> ");
                }
                else Console.Write("   ");
                Console.WriteLine($"WorkName-> {MenyuList[i].WorkName}");
                Console.WriteLine($"Salary-> {MenyuList[i].SalaryMax}\n");
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
                    Index = Math.Min(MenyuList.Count - 1, Index + 1);
                    break;
                case ConsoleKey.Escape:
                    Console.Clear();
                    Menyu(SpecializationList);
                    MenyuList.Clear();
                    Console.Clear();
                    break;
                case ConsoleKey.Enter:
                    Console.Clear();
                    Program.DateVacancySee(MenyuList[Index]);
                    Console.WriteLine(MenyuList[Index]);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Press Any Button To Go <Back>");
                    Console.ReadKey();
                    Console.ResetColor();
                    break;
            }
        } while (true);
    }

}