using System.Linq.Expressions;
using FitnessClub.DataAccess.Entities;

namespace FitnessClub.DataAccess;

public interface IRepository<T> where T: class, IBaseEntity
{
    IEnumerable<T> GetAll();
    IEnumerable<T> GetAll(Expression<Func<T, bool>> filter);
    T? GetById(int id);
    T? GetById(Guid id);
    T Save(T entity);
    void Delete(T entity);
}