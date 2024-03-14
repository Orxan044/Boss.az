using Boss.az.Worker;
namespace Boss.az.CV;
using Boss.az.Abstract;

internal class CV : Post
{
    public int? SchoolNo { get; set; }
    public int? UniversityScore { get; set; }
    public string? Skills { get; set; }
    public List<CompaniesWork> CompaniesWorksCV { get; set; } = new(); // Baslama ve Bitirme tarixleride burdadir
    public bool HonorsDiploma { get; set; }
    public string? Gitlink { get; set; }
    public string? Linkedin { get; set; }

    public override string ToString()
    {
        string companiesWorksToString = string.Join("\n", CompaniesWorksCV.Select(c =>
        {
            if (CompaniesWorksCV == null) return $"There is no place he wants before!";
            return c.ToString();
        }));
        string honorsDiplomaResult = HonorsDiploma ? "Yes" : "No";
        return $"SchoolNo-> {SchoolNo}\n" +
        $"UniversityScore-> {UniversityScore}\n" +
        $"Skills-> {Skills}\n" +
        $"CompaniesWorksCV-> {companiesWorksToString}\n" +
        $"HonorsDiploma-> {honorsDiplomaResult}  \n" +
        $"GitLink-> {Gitlink}\n" +
        $"Linkedin-> {Linkedin}\n"+
        base.ToString();
    }
    
}
