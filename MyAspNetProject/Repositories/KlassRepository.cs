using MyAspNetProject.Models.Domain;

namespace MyAspNetProject.Repositories;


public interface IKlassRepository : IBaseRepository<Klass>
{
    
}



public class KlassRepository : BaseRepository<Klass>, IKlassRepository
{
    
}