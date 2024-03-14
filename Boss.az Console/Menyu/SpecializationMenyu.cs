using Boss.az.Models;

namespace Boss.az.Menyu;

internal class SpecializationMenyu
{    public static string? DateSpecialization;

    public static void Menyu(List<Specialization> SpecializationList)
    {
        ConsoleKeyInfo key;
        int selectedIndex = 0;
        int subSelectedIndex = 0;
        do
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Please select a Specialization !!!");
            Console.ResetColor();

            for (int i = 0; i < SpecializationList.Count; i++)
            {

                Console.WriteLine(SpecializationList[i]);

                if (i == selectedIndex)
                {
                    for (int j = 0; j < SpecializationList[i].CategoryNames?.Count; j++)
                    {
                        if (j == subSelectedIndex) Console.ForegroundColor = ConsoleColor.DarkYellow;

                        Console.WriteLine($"=>  {SpecializationList[i].CategoryNames?[j]}");
                        Console.ResetColor();
                    }
                }
                Console.ResetColor();
            }

            key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.DownArrow)
            {
                if (selectedIndex < SpecializationList.Count - 1 && subSelectedIndex == SpecializationList[selectedIndex].CategoryNames?.Count - 1) { selectedIndex++; subSelectedIndex = 0; }
                else if (subSelectedIndex < SpecializationList[selectedIndex].CategoryNames?.Count - 1) subSelectedIndex++;
            }
            else if (key.Key == ConsoleKey.UpArrow)
            {
                if (selectedIndex > 0 && subSelectedIndex == 0) { selectedIndex--; subSelectedIndex = SpecializationList[selectedIndex].CategoryNames.Count - 1; }
                else if (subSelectedIndex > 0) subSelectedIndex--;
            }
        } while (key.Key != ConsoleKey.Enter);

        DateSpecialization = SpecializationList[selectedIndex].CategoryNames?[subSelectedIndex];
    }
}
