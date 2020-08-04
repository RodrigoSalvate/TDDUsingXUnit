using System.Collections.Generic;

namespace CursoOnline.Domain.Interfaces.Base
{
    public interface IRepository<T>
    {
        T FindById(int id);
        List<T> Search();
        void Insert(T entity);
    }
}
