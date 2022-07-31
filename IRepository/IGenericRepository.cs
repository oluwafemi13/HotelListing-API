using System.Linq.Expressions;
using System.Threading.Tasks; 

namespace HotelListing_API.IRepository
{
    public interface IGenericRepository<T> where T:class
    {
        //get function to return a list
        Task<IList<T>> GetAll(
            Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            List<string> includes = null);

        //get function to return just one
        Task<IList<T>> Get(Expression<Func<T, bool>> expression, List<string> includes = null);

        //create
        Task Insert(T entity);

        Task InsertRange(IEnumerable<T> entities);
        //delete
        Task Delete(int id);

        void DeleteRange(IEnumerable<T> entities);

        //update
        void Update(T entity);
    }
}
