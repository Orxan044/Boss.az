namespace Boss.az.MenyuHelper;

using Boss.az.Worker;
using Boss.az.Person;
using Boss.az.Employer;
using Boss.az.Data;
using Boss.az.Menyu;
using CV;
using Boss.az.Model;
using Boss.az.Models;
using System.Collections.Generic;
using System.Text.Json;
using Boss.az.Menyu.MainMenyu;




internal class Program
{
    public static Worker workerProgram = new();
    public static Employer employerProgram = new();

    public static WorkerDbContext workerdb = new();
    public static EmployerDbContext employerdb = new();
    public static List<Specialization> SpecializationList = new();


    static void Main(string[] args)
    {
        GreatSpecialization(); // Specialization Yaradir
        MainPage.MenyuLoginAndRegisther(SpecializationList); // Giris
    }
    public static void GreatSpecialization()
    {
        Specialization InformationTechnologies = new() 
        {
            Category = "Information technologies",
            CategoryNames = new() { "IT", "Programming" }
        };
        Specialization Finance = new() 
        {
            Category = "Finance",
            CategoryNames = new() { "Insurance", "Cashier", "Accounting" }
        };
        Specialization MedicinePharmacy = new()
        {
            Category = "Medicine and pharmacy",
            CategoryNames = new() { "Doctor", "Medical Personnel"}
        };
        SpecializationList.Add(InformationTechnologies);
        SpecializationList.Add(Finance);
        SpecializationList.Add(MedicinePharmacy);
    }

    public static void UserGreat()
    {

        string? NameInput = MenyuHelper.StringRead("Name-> ", 3, false);
        string? SurnameInput = MenyuHelper.StringRead("Surname-> ", 4, false);
        int AgeInput = MenyuHelper.AgeRead("Age-> ");
        string? CityInput = MenyuHelper.StringRead("City-> ", 2, false);
        string? PhoneInput = MenyuHelper.PhoneRead("Phone-> ");
        string? EmailInput = MenyuHelper.MailRead("E-Mail-> ");
        string? PasswordInput = MenyuHelper.PasswordRead("Password-> ");

        if (RegistherMenyu.DataStatus == Status.Worker)
        {
            workerProgram = new()
            {
                Name = NameInput,
                Surname = SurnameInput,
                Age = AgeInput,
                City = CityInput,
                Phone = PhoneInput,
                Email = EmailInput,
                Password = PasswordInput,
                CVs = new()
            };
            workerdb.Workers.Add(workerProgram);
            workerdb.SaveChanges();
        }
        else if (RegistherMenyu.DataStatus == Status.Employer)
        {
            employerProgram = new()
            {
                Name = NameInput,
                Surname = SurnameInput,
                Age = AgeInput,
                City = CityInput,
                Phone = PhoneInput,
                Email = EmailInput,
                Password = PasswordInput,
                Vacancies = new()
            };
            employerdb.Employers.Add(employerProgram);
            employerdb.SaveChanges();
        }
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("It has been Registered ;)");
        Thread.Sleep(2000);
        Console.ResetColor();
    }

    public static void PostGreat()
    {        
        SpecializationMenyu.Menyu(SpecializationList); // Menyu Baslayir
        string? EducationDegreeInput = MenyuHelper.EducationDegreeRead();
        string? ExperienceInput = MenyuHelper.StringRead("Experience -> ", 2, true);
        List<Dictionary<string, string>> KnowLanguageInput = MenyuHelper.KnowLanguageRead();
        string? PhoneNumberInput = MenyuHelper.PhoneRead("Contact Phone Number-> ");
        string? WorkCityInput = MenyuHelper.StringRead("Work City-> ", 3, true);
        if (RegistherMenyu.DataStatus == Status.Worker) // CV Great
        {
            string ScoolNum = null;
            string UniScore = null;
            int ScoolNumInput = MenyuHelper.IntRead("Your School Number -> ", ScoolNum);
            int UniScoreInput = MenyuHelper.IntRead("Your University Score -> ", UniScore);
            string? SkillsInput = MenyuHelper.StringRead("Skills-> ", 3, true); // StrMellumat, Str uzunlugu , Space true/false
            List<CompaniesWork> CompaniesWorks = MenyuHelper.CompaniesWorkRead();
            bool HonorsDiplomaInput = MenyuHelper.HonorsDiplomaRead("Honors Diploma(yes/no)-> ");
            string? GitLinkInput = MenyuHelper.StringRead("GITLINK-> ", 1, true); 
            string? LinkedinInput = MenyuHelper.StringRead("LINKEDIN-> ", 1, true); 
            CV CvProgram = new()
            {
                SpecializationName = SpecializationMenyu.DateSpecialization,
                EducationDegree = EducationDegreeInput,
                Experience = ExperienceInput,
                KnowLanguages = KnowLanguageInput,
                WorkCity = WorkCityInput,
                SchoolNo = ScoolNumInput,
                UniversityScore = UniScoreInput,
                Skills = SkillsInput,
                CompaniesWorksCV = CompaniesWorks,
                HonorsDiploma = HonorsDiplomaInput,
                Gitlink = GitLinkInput,
                Linkedin = LinkedinInput,
            };
            foreach (var item in workerdb.Workers)
                if (item.Email == LoginMenyu.DateMailInput) workerProgram = item;
            workerProgram.CVs.Add(CvProgram);
            workerdb.Workers.Remove(workerProgram);
            workerdb.Workers.Add(workerProgram);
            workerdb.SaveChanges();
        }
        else if (RegistherMenyu.DataStatus == Status.Employer)
        {
            string? WorkNameInput = MenyuHelper.StringRead("Work Name-> ", 2, true);
            string AgeMin = null;
            string AgeMax = null;
            string SalaryMax = null;
            int AgeMinInput = MenyuHelper.IntRead("Worker Age min-> ", AgeMin);
            int AgeMaxInput = MenyuHelper.IntRead("Worker Age max-> ", AgeMax);
            double SalaryMaxInput = MenyuHelper.DoubleRead("Worker Salary max-> ", SalaryMax);
            string? RequirementsInput = MenyuHelper.StringRead("Requirements-> ", 5, true);
            string? JobDescriptionInput = MenyuHelper.StringRead("Job Description-> ", 5, true);
            Vacancy vacancy = new()
            {
                SpecializationName = SpecializationMenyu.DateSpecialization,
                EducationDegree = EducationDegreeInput,
                Experience = ExperienceInput,
                KnowLanguages = KnowLanguageInput,
                PhoneNumber = PhoneNumberInput,
                WorkCity = WorkCityInput,
                WorkName = WorkNameInput,
                AgeMin = AgeMinInput,
                AgeMax = AgeMaxInput,
                SalaryMax = SalaryMaxInput,
                Requirements = RequirementsInput,
                JobDescription = JobDescriptionInput
            };
            foreach (var item in employerdb.Employers)
                if (item.Email == LoginMenyu.DateMailInput) employerProgram = item;
            employerProgram.Vacancies.Add(vacancy);
            employerdb.Employers.Remove(employerProgram);
            employerdb.Employers.Add(employerProgram);
            employerdb.SaveChanges();
            EmployerMenyu.Menyu(SpecializationList);
        }
    }

    public static void ShowCV()
    {
        foreach (var item in workerdb.Workers)
            if (item.Email == LoginMenyu.DateMailInput) workerProgram = item;

        Console.Clear();
        foreach (var item in workerProgram.CVs)
        {
            Console.WriteLine(item.ToString());
            Console.WriteLine("----------------------------------------------");
        }


    }

    public static void ShowVacancy()
    {
        foreach (var item in employerdb.Employers)
            if (item.Email == LoginMenyu.DateMailInput) employerProgram = item;

        Console.Clear();
        foreach (var item in employerProgram.Vacancies)
        {
            Console.WriteLine(item.ToString());
            Console.WriteLine("----------------------------------------------");
        }
    }


    public static SeeVacancyDbContext seeVacancydb = new();
    public static SeeCvDbContext seeCvdb = new();
    public static void DateVacancySee(Vacancy vacancy)
    {
        bool check = true;
        foreach (var dictonary in seeVacancydb.SeeVacancies)
        {
            foreach (var key in dictonary)
            {
                if(key.Value == vacancy.Id.ToString() && key.Key == LoginMenyu.DateMailInput)
                    check = false;
            }
        }
        if (check == true)
        {
            foreach (var employer in MenyuHelper.EmployerRepo.GetAllEmployers())
            {   
                foreach (var vacancyIn in employer.Vacancies)
                {
                    if(vacancyIn.Id == vacancy.Id)
                    {
                        employer.Vacancies.Remove(vacancy);
                        vacancy.ViewCount++;
                        employer.Vacancies.Add(vacancy);
                        employerdb.SaveChanges();
                        Dictionary<string, string> dic = new();
                        dic.Add($"{LoginMenyu.DateMailInput}", vacancy.Id.ToString());
                        seeVacancydb.SeeVacancies.Add(dic);
                        seeVacancydb.SaveChanges();
                        break;
                    }
                }
            }
        }
    }

    public static void DateCvSee(CV Cv)
    {
        bool check = true;
        foreach (var dictonary in seeCvdb.SeeCvs)
        {
            foreach (var key in dictonary)
            {
                if (key.Value == Cv.Id.ToString() && key.Key == LoginMenyu.DateMailInput)
                    check = false;
            }
        }

        //foreach (var item in seeCvdb.SeeCvs)
        //    if (item == Cv.Id.ToString()) check = false;
        if (check == true)
        {
            foreach (var worker in MenyuHelper.WorkerRepo.GetAllWorkers())
            {
                foreach (var cvIn in worker.CVs)
                {
                    if (cvIn.Id == Cv.Id)
                    {
                        worker.CVs.Remove(Cv);
                        Cv.ViewCount++;
                        worker.CVs.Add(Cv);
                        workerdb.SaveChanges();
                        Dictionary<string, string> dic = new();
                        dic.Add($"{LoginMenyu.DateMailInput}", Cv.Id.ToString());
                        seeCvdb.SeeCvs.Add(dic); 
                        seeCvdb.SaveChanges();
                        break;
                    }
                }
            }
        }

    }
}