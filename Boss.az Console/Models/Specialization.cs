namespace Boss.az.Models;

internal class Specialization
{
    public string? Category { get; set; }

    public List<string> CategoryNames = new();
    public override string ToString() => $"\n- *{Category}* \n";
    public string ShowCategoryNames() => string.Join("\n", CategoryNames, "\n");
}

