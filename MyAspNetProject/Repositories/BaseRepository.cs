using MyAspNetProject.Models.Domain;

namespace MyAspNetProject.Repositories;

public interface IBaseRepository<T>
{
    T Create(T entity);
    List<T> GetAll();
    T? GetById(int id);
    void Delete(T entity);
    T? Update(T source,T target);
}


public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
{
    private static readonly List<T> Entities = new();
    private int _nextID = 1;

    public T Create(T entity)
    {
        entity.Id = _nextID++;
        Entities.Add(entity);
        return entity;
    }

    public List<T> GetAll()
    {
        return Entities;
    }

    public T? GetById(int id)
    {
        return Entities.FirstOrDefault(e => e.Id == id);
    }

    public void Delete(T entity)
    {
        Entities.Remove(entity);
    }

    public T? Update(T source, T target)
    {
        throw new NotImplementedException();
    }
}
