using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataLayer.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MyDbContext _context;
        private readonly DbSet<T> _entities;
       // private readonly DbSet<StudentCourse> _studentCourses;

        public Repository(MyDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
            //_studentCourses = context.Set<StudentCourse>();
        }

        public T GetById(Guid id)
        {
            return _entities.Find(id);
        }

        /*public StudentCourse GetCourseByStudentAndName(string name, string student)
        {
            var course = _studentCourses.FirstOrDefault(c => c.Name == name && c.Student == student);
            return course;
        }*/

        public IEnumerable<T> GetAll()
        {
            return _entities.ToList();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _entities.Where(predicate);
        }

        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        public void Remove(T entity)
        {
            _entities.Remove(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
