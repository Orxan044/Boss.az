namespace Boss.az.MenyuHelper;
using System.Text.RegularExpressions;
using Worker;
using Employer;
using Boss.az.Repos;
using System.Data.SqlTypes;
using Boss.az.Person;
using Boss.az.Models;

internal class MenyuHelper
{
    public static WorkerRepository WorkerRepo = new();
    public static EmployerRepository EmployerRepo = new();
    private static void ErorMessage(Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(ex.Message);
        Thread.Sleep(1000);
        Console.ResetColor();
        Console.Clear();
    }
    
    public static string StringRead(string Str,int StrLenght,bool SpaceCheck) // Burada Yalniz Herfler qebul edir ve Uzunluguna gore ve istese space(bosluqda) return edir 
    {
        Console.Clear();
        string? pattern = "^[a-zA-Z]+$";
        var Regex = new Regex(pattern);
        while (true)
        {
            try
            {
                Console.Write(Str);
                string? input = Console.ReadLine();
                if (!SpaceCheck && Regex.IsMatch(input) && input.Length > StrLenght) return input;
                if (SpaceCheck && input.Length > StrLenght) return input;
                else throw new Exception("Enter Correctly !!!");
            }
            catch (Exception ex) { ErorMessage(ex); }
        }
    }

    public static int IntRead(string Str ,string? input) // Burada yalniz int Reqem Daxil Edir
    {
        Console.Clear();
        string? pattern = "^[0-9]+$";
        var Regex = new Regex(pattern);
        while (true)
        {
            try
            {
                Console.Write(Str);
                input = Console.ReadLine();
                if (Regex.IsMatch(input) && int.TryParse(input, out int value)) return value;
                else throw new Exception("Enter Correctly !!!");
            }
            catch (Exception ex) { ErorMessage(ex); }
        }
    }  
    public static double DoubleRead(string Str ,string? input) // Burada yalniz double Reqem Daxil Edir
    {
        Console.Clear();
        string? pattern = @"\b\d+\.\d+\b";
        var Regex = new Regex(pattern);
        while (true)
        {
            try
            {
                Console.Write(Str);
                input = Console.ReadLine();
                if (Regex.IsMatch(input) && double.TryParse(input, out double value)) return value;
                else if (int.TryParse(input, out int value1)) return value1;
                else throw new Exception("Enter Correctly !!!");
            }
            catch (Exception ex) { ErorMessage(ex); }
        }
    }

    public static int AgeRead(string Str) // Yasi Yoxlayir 18 den yuxari olub olmadigini
    {
        string? input = null;
        var Age = IntRead(Str, input);
        while (true)
        {
            try
            {
                if(Age >= 18) return Age;
                else throw new Exception("Must be over 18 years old !!!");
            }
            catch (Exception ex) { ErorMessage(ex); }
        }
    }

    public static string PhoneRead(string Str) // Nomreni Yoxlama
    {
        Console.Clear();
        string? pattern = @"^(?:\+994|0)(50|51|55|60|70|77)\d{7}$"; // Azerbaycan Nomrelerini Yoxlayir
        var Regex = new Regex(pattern);
        while (true)
        {
            try
            {
                Console.WriteLine("Etc -> +994xxxxxxxxx , 994xxxxxxxxx , 0xxxxxxxxx\n");
                Console.Write(Str);
                string? input = Console.ReadLine();
                if (Regex.IsMatch(input)) return input;
                else throw new Exception("Enter Correctly !!!");
            }
            catch (Exception ex) { ErorMessage(ex); }
        }
    }

    public static string MailRead(string Str) // E-Mail Yoxlayir
    {
        Console.Clear();
        string? pattern = "^\\w+([.-]?\\w+)*@\\w+([.-]?\\w+)*(\\.\\w{2,3})+$"; // Mail Yoxlayir
        var Regex = new Regex(pattern);
        while (true)
        {
            try
            {
                Console.Write(Str);
                string? input = Console.ReadLine();
                if (!Regex.IsMatch(input)) throw new Exception("Enter Correctly !!!");
                if (WorkerRepo.CheckWorkerMail(input) || EmployerRepo.CheckEmployerMail(input)) 
                    throw new Exception("There is a user for the Gmail account you entered !!!");     
                else return input; 
            }
            catch (Exception ex) { ErorMessage(ex); }
        }
    }

    public static string PasswordRead(string Str) // Password yoxlayir
    {
        Console.Clear();
        while (true)
        {
            try
            {
                Console.Write(Str);
                string? input = Console.ReadLine();
                if (!(input is null)) return input; 
                else throw new Exception("Enter Correctly !!!");
            }
            catch (Exception ex) { ErorMessage(ex); }
        }    
    }

    public static bool HonorsDiplomaRead(string Str)
    {
        Console.Clear();
        while (true)
        {
            try
            {
                Console.Write(Str);
                string? input = Console.ReadLine();
                if (input.ToLower() != "yes" && input.ToLower() != "no") throw new Exception("Enter Correctly !!!");
                if (input.ToLower() == "yes") return true;
                if (input.ToLower() == "no") return false;
            }
            catch (Exception ex) { ErorMessage(ex); }
        }
    } 

    public static List<CompaniesWork> CompaniesWorkRead()
    {
        Console.Clear();
        List<CompaniesWork> companiesWorks = new();
        string? input = null;
        var Count = IntRead("How many companies have you worked for -> ", input);
        while (true)
        {
            try
            {
                for (int i = 0; i < Count; i++)
                {
                    Console.Clear();
                    string? NameInput = StringRead($"Company Name ({i+1})-> ", 3, true);
                    Console.Write($"Begin Company({i + 1}) Time(yyyy.mmm.dd)-> ");
                    string? TimeBeginInput = Console.ReadLine();
                    if (!DateTime.TryParse(TimeBeginInput, out DateTime resultBegin))
                        throw new Exception("Invalid date format !!!");
                    Console.Write($"End Company({i + 1}) Time(yyyy.mmm.dd)-> ");
                    string? TimeEndInput = Console.ReadLine();
                    if (!DateTime.TryParse(TimeEndInput, out DateTime resultEnd) || resultBegin > resultEnd)
                        throw new Exception("Invalid date format !!!");

                    CompaniesWork companiesWork = new()
                    {
                        CompanyName = NameInput,
                        BeginWork = resultBegin,
                        EndWork = resultEnd
                    };
                    companiesWorks.Add(companiesWork);
                }
                return companiesWorks;
            }
            catch (Exception ex) { ErorMessage(ex); }

        }
    }

    public static List<Dictionary<string,string>> KnowLanguageRead()
    {
        Console.Clear();
        List<Dictionary<string, string>> KnowLanguage = new();
        string? input = null;
        var Count = IntRead("How many languages do you know? -> ", input);
        while (true)
        {
            try
            {
                for (int i = 0; i < Count; i++)
                {
                    string? LanguageInput = StringRead($"Language ({i + 1})-> ", 2, true);
                    Console.Write($"Level ({i + 1}) (Poorly,Middle,Super) -> ");
                    string? LevelInput = Console.ReadLine();
                    string? InputLower = LevelInput.ToLower();
                    if (InputLower != "poorly" && InputLower != "middle" && InputLower != "super"){
                        throw new Exception("Enter Correctly !!!");}

                    Dictionary<string, string> Dic = new();
                    Dic[LanguageInput] = InputLower;
                    KnowLanguage.Add(Dic);

                }
                return KnowLanguage; 
            }
            catch (Exception ex) { ErorMessage(ex); }
        }
    }

    public static string EducationDegreeRead()
    {
        Console.Clear();
        while (true)
        {
            try
            {
                string? input = StringRead("Education Degree \n(Science Degree,Higher,Secondary)->  ", 5, true);
                if (input.ToLower() != "secondary" && input.ToLower() != "higher" && input.ToLower() != "science degree")
                    throw new Exception("Enter Correctly !!!");
                return input;
            }
            catch (Exception ex) { ErorMessage(ex); }
        }
    }

    //----------------------------------------------------------------------------

    public static string CheckLogin(ref string? MailInput,ref string? PasswordInput)
    {
        while (true)
        {
            try
            {
                Console.Write("Email-> ");
                MailInput = Console.ReadLine();
                Console.Write("Password-> ");
                PasswordInput = Console.ReadLine();
                if (MailInput is null || PasswordInput is null) throw new Exception("Not Enter Null !!!");
                bool CheckWorker = WorkerRepo.CheckWorkerLogin(MailInput, PasswordInput);
                bool CheckEmployer = EmployerRepo.CheckEmployerLogin(MailInput, PasswordInput);
                if (CheckWorker) return "Worker";
                if (CheckEmployer) return "Employer";
                else throw new Exception("Not Found User");
            }
            catch (Exception ex) { ErorMessage(ex); }
        }
    }


}
