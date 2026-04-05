using MyAspNetProject.Models.Domain;

namespace MyAspNetProject.Repositories;

public interface IBaseRepository<T>
{
    T Create(T entity);
    List<T> GetAll();
    T? GetById(int id);
    void Delete(T entity);
    T? Update(T source,T target);
    bool ExistsById(int id);
}


public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
{
    protected static readonly List<T> Entities = new();
    private static int _nextId = 1;

    public virtual T Create(T entity)
    {
        entity.Id = _nextId++;
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

    public bool ExistsById(int id)
    {
        return Entities.Exists(x => x.Id == id);
    }
}
