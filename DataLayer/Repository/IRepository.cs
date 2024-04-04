using DataLayer.Models;
using System.Linq.Expressions;

namespace DataLayer.Repository
{
    public interface IRepository<T> where T : class
    {
        T GetById(Guid id);

       // StudentCourse GetCourseByStudentAndName(string name, string student);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}
