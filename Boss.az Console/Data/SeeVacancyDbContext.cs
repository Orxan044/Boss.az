using System.Text.Json;

namespace Boss.az.Data;

internal class SeeVacancyDbContext
{
    string fileName = @"C:\Users\user\source\Repos\Boss.az Console\Boss.az Console\Json File\VacancyLog.json";
    public SeeVacancyDbContext()
    {
        if (File.Exists(fileName))
        {
            var SeeVacancyJson = File.ReadAllText(fileName);
            SeeVacancies = JsonSerializer.Deserialize<List<Dictionary<string,string>>>(SeeVacancyJson) ?? new();
        }
        else
            SeeVacancies = new();
    }

    public List<Dictionary<string,string>> SeeVacancies { get; set; }

    public void SaveChanges()
    {
        var SeeVacancyJson = JsonSerializer.Serialize(SeeVacancies);
        File.WriteAllText(fileName, SeeVacancyJson);
    }
}
