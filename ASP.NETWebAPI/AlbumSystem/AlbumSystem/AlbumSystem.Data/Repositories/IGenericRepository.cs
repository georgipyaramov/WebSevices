namespace AlbumSystem.Data.Repositories
{
    using System.Linq;

    public interface IGenericRepository<T>
    {
        IQueryable<T> All();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}