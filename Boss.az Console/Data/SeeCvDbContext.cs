using System.Text.Json;

namespace Boss.az.Data;

internal class SeeCvDbContext
{
    string fileName = @"C:\Users\user\source\Repos\Boss.az Console\Boss.az Console\Json File\CvLog.json";
    public SeeCvDbContext()
    {
        if (File.Exists(fileName))
        {
            var SeeCvJson = File.ReadAllText(fileName);
            SeeCvs = JsonSerializer.Deserialize<List<Dictionary<string,string>>>(SeeCvJson) ?? new();
        }
        else
            SeeCvs = new();
    }

    public List<Dictionary<string,string>> SeeCvs { get; set; }

    public void SaveChanges()
    {
        var SeeCvJson = JsonSerializer.Serialize(SeeCvs);
        File.WriteAllText(fileName, SeeCvJson);
    }
}
