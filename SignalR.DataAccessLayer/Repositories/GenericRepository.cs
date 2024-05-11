using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;

namespace SignalR.DataAccessLayer.Repositories;
public class GenericRepository<T> : IGenericDal<T> where T : class
{
    private readonly SignalRContext _context;
    public GenericRepository(SignalRContext context)
    {
        _context = context; 
    }

    public void Add(T t)
    {
        _context.Add(t);
        _context.SaveChanges();
    }

    public void Delete(T t)
    {
        _context.Remove(t);
        _context.SaveChanges(); 
    }

    public T GetByID(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public List<T> GetListAll()
    {
        return _context.Set<T>().ToList();
    }

    public void Update(T t)
    {
        _context.Update(t);
        _context.SaveChanges();
    }
}
