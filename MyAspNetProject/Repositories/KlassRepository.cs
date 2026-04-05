using MyAspNetProject.Models.Domain;
using MyAspNetProject.Models.DTO.Request;

namespace MyAspNetProject.Repositories;


public interface IKlassRepository : IBaseRepository<Klass>
{
    bool ExistsByYearGroup(int? year, string? group);
    Klass GetByYearAndGroup(int year, string group);
}



public class KlassRepository : BaseRepository<Klass>, IKlassRepository
{
   public bool ExistsByYearGroup(int? year, string? group)
   {
      return Entities.Exists(x => x.Year == year && x.Group == group);
   }

   public Klass GetByYearAndGroup(int year, string group)
   {
       return Entities.First(x => x.Group == group && x.Year == year);
   }
}