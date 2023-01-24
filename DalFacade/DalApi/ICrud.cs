
namespace DalApi;

public interface ICrud<T> where T: struct
{
    int ADD(T entity);
    void DELETE(int id);
    T GET (int id);
    void UPDATE(T entity);

    public IEnumerable<T> GetAll();
}
