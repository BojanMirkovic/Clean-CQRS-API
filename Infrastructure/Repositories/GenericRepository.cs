using Infrastructure.Database;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{/*Why we used a Generic Repository instead of a IDogRepository?? 
  * When there are large number of entites in our application, we would need seperate repositories for each entities. 
  * But we do not want to implement all of the above 7 Functions in each and every Repository Class, right? 
  * Thus we made a generic repository that holds the most commonly used implementaions.*/
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly RealDb _context;
        public GenericRepository(RealDb context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id)!;
        }
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
    }
    /*This class will implement the IGenericRepository Interface. We will also inject the ApplicationContext here.
     * This way we are hiding all the actions related to the dbContext object within Repository Classes. 
     * Also note that, for the ADD and Remove Functions, we just do the operation on the dbContext object. 
     * But we are not yet commiting/updating/saving the changes to the database whatsover. 
     * This is not something to be done in a Repository Class. 
     * We would need Unit of Work Pattern for these cases where you commit data to the database.*/
}
