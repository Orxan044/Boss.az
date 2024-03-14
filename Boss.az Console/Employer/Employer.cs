namespace Boss.az.Employer;
using Boss.az.Model;
using Person;
internal class Employer : Person
{
    public List<Vacancy> Vacancies { get; set; }

    public override string ToString() =>
        base.ToString() +
        $"Vacancies-> {Vacancies}";

}
