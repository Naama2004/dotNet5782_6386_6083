
namespace DalApi;

public interface ICrud<T>
{
    void ADD(T entity);
    void DELETE(T entity);
    T GET();
    void UPDATE(T entity);
}
