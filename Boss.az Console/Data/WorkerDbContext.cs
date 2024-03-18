namespace Boss.az.Data;
using System.Text.Json;
using  Boss.az.Worker;

internal class WorkerDbContext
{
    string fileName = @"C:\Users\user\source\Repos\Boss.az\Boss.az Console\Json File\Worker.json";
    public WorkerDbContext()
    {
        if (File.Exists(fileName))
        {
            var WorkerJson = File.ReadAllText(fileName);
            Workers = JsonSerializer.Deserialize<List<Worker>>(WorkerJson) ?? new();
        }
        else
            Workers = new();
                    
    }

    public List<Worker> Workers { get; set; }

    public void SaveChanges()
    {
        var WorkerJson = JsonSerializer.Serialize(Workers);
        File.WriteAllText(fileName, WorkerJson);  
    }




}
