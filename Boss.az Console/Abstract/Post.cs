namespace Boss.az.Abstract;
using Boss.az.BaseId;
internal class Post : BaseId
{
    public string? SpecializationName { get; set; }
    public string? EducationDegree { get; set; } //
    public string? Experience { get; set; } //
    public List<Dictionary<string, string>> KnowLanguages { get; set; } = new();
    public string? PhoneNumber { get; set; }
    public uint ViewCount { get; set; }
    public string? WorkCity { get; set; } //
    protected DateTime StartTimePost { get; set; } = DateTime.Now;
    protected DateTime EndTimePost { get; set; } = DateTime.Now.AddDays(30);

    public override string ToString()
    {
        string languagesToString = string.Join("\n", KnowLanguages.Select(dict =>
        {
            if (KnowLanguages == null) return $"No knowledge of language!";
            string pairs = "";
            foreach (var pair in dict) pairs += $"{pair.Key}: {pair.Value}, ";
            if (pairs.EndsWith(", ")) pairs = pairs.Remove(pairs.Length - 2);
            return $"{{ {pairs} }}";
        }));
        return $"Specialization Name-> {SpecializationName}\n" +
        $"Education Degree -> {EducationDegree}\n" +
        $"Experience-> {Experience}\n" +
        $"Know Language-> {languagesToString}\n\n" +
        $"Phone Number-> {PhoneNumber}\n"+
        $"Work City-> {WorkCity}\n" +
        $"View Count-> {ViewCount}\n" +
        $"Start Time Post-> {StartTimePost.ToString("dd MMMM yyyy")}\n" +
        $"End Time Post-> {EndTimePost.ToString("dd MMMM yyyy")}\n";
    }
        




}
