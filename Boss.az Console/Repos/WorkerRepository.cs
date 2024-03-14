namespace Boss.az.Repos;
using Boss.az.Data;
using Boss.az.Models;
using Boss.az.Worker;
using System.Net.Mail;

internal class WorkerRepository
{
    private readonly WorkerDbContext _context;

    public WorkerRepository()
    {
        _context = new WorkerDbContext();
    }

    public List<Worker> GetAllWorkers() => _context.Workers;
    public bool CheckWorkerMail(string Mail)
    {
        var worker = _context.Workers.FirstOrDefault(w => w.Email == Mail);
        if(worker is null)  return false; 
        return true;
    }

    public bool CheckWorkerLogin(string Mail, string Password)
    {
        var worker = _context.Workers.FirstOrDefault(w => w.Email == Mail && w.Password == Password);
        if (worker is null) return false;
        return true;
    }

}
