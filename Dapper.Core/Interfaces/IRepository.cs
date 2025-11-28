namespace Dapper.Core.Interfaces;

public interface IRepository<T> where T: class
{
    int Insert(T obj);
    int Delete(int id);
    int Update(T obj);
    IEnumerable<T> GetAll();
    T GetById(int id);
}