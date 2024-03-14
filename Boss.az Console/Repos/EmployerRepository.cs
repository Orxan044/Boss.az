namespace Boss.az.Repos;
using Boss.az.Data;
using Boss.az.Employer;
using Boss.az.Models;

internal class EmployerRepository
{
    private readonly EmployerDbContext _context;

    public EmployerRepository()
    {
        _context = new EmployerDbContext();
    }

    public List<Employer> GetAllEmployers() => _context.Employers;

    public bool CheckEmployerMail(string Mail)
    {
        var employer = _context.Employers.FirstOrDefault(e => e.Email == Mail);
        if (employer is null) return false;
        return true;
    }

    public bool CheckEmployerLogin(string Mail, string Password)
    {
        var employer = _context.Employers.FirstOrDefault(e => e.Email == Mail && e.Password == Password);
        if (employer is null) return false;
        return true;
    }

}
