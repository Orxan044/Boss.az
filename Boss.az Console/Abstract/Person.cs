namespace Boss.az.Person;
using Boss.az.BaseId;
using Boss.az.CV;

public enum Status { Worker, Employer }

internal abstract class Person : BaseId
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public int Age { get; set; }
    public string? City { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }

    public override string ToString() =>
        $"Name-> {Name}\n" +
        $"Surname-> {Surname}\n" +
        $"Age-> {Age} \n" +
        $"City-> {City} \n" +
        $"Phone-> {Phone} \n" +
        $"Email-> {Email}\n";
}
