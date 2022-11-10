
namespace DalApi;

public interface ICrud<T>
{
    void ADD(T entity);
    void DELETE(int id);
    T GET(int id);
    void UPDATE(T entity);
}
