namespace Boss.az.Worker;

internal class CompaniesWork
{
    public string? CompanyName { get; set; }
    public DateTime BeginWork { get; set; }
    public DateTime EndWork { get; set; }

    public override string ToString() =>
        $" Company Name: {CompanyName}, BeginWork: {BeginWork.ToString("yyyy-MM-dd")}, EndWork: {EndWork.ToString("yyyy-MM-dd")}";

}
