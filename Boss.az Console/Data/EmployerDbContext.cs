namespace Boss.az.Data;
using System.Text.Json;
using Boss.az.Employer;

internal class EmployerDbContext
{
    string fileName = @"C:\Users\user\source\Repos\Boss.az Console\Boss.az Console\Json File\Employer.json";
    public EmployerDbContext()
    {
        if (File.Exists(fileName))
        {
            var EmployerJson = File.ReadAllText(fileName);
            Employers = JsonSerializer.Deserialize<List<Employer>>(EmployerJson) ?? new();
        }
        else
            Employers = new();
    }

    public List<Employer> Employers { get; set; }

    public void SaveChanges()
    {
        var EmployerJson = JsonSerializer.Serialize(Employers);
        File.WriteAllText(fileName, EmployerJson);
    }
}
