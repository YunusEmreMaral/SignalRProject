using SignalR.DataAccessLayer.Concrete;

namespace SignalR.DataAccessLayer.Abstract;
public interface IGenericDal<T> where T : class
{
   
    void Add(T t);
    void Delete(T t);
    void Update(T t);
    T GetByID(int id);
    List<T> GetListAll();   
}
