namespace Boss.az.Worker;
using Boss.az.Person;
using Boss.az.CV;
internal class Worker : Person
{
    public List<CV> CVs { get; set; }

    public override string ToString() => 
        base.ToString()+
        $"Cv -> {CVs}";
}

