namespace Boss.az.Model;

using Boss.az.Abstract;
using Boss.az.BaseId;

internal class Vacancy : Post
{
    public string? WorkName { get; set; }
    public int? AgeMin { get; set; }
    public int? AgeMax { get; set; }
    public double? SalaryMax { get; set; }
    public string? Requirements { get; set; }
    public string? JobDescription { get; set; }

    public override string ToString() { return
            $"WorkName-> {WorkName}\n" +
            $"Age min-> {AgeMin}\n" +
            $"Age max-> {AgeMax}\n" +
            $"Salary max-> {SalaryMax}\n" +
            $"Requirements-> {Requirements}\n" +
            $"JobDescription-> {JobDescription}\n\n" +
            base.ToString();
    }
}
