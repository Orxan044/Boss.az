namespace Boss.az.Menyu.MainMenyu;
using Boss.az.MenyuHelper;
using Boss.az.Models;

internal class LoginMenyu
{
    public static string? DateMailInput;
    private static string? DatePasswordInput;
    public static void Menyu(List<Specialization> SpecializationList)
    {
        Console.Clear();
        string LoginCheck = MenyuHelper.CheckLogin(ref DateMailInput, ref DatePasswordInput);
        if (LoginCheck == "Worker") WorkerMenyu.Menyu(SpecializationList);
        if (LoginCheck == "Employer") EmployerMenyu.Menyu(SpecializationList);

    }

}
