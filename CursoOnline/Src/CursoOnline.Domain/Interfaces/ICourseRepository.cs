using CursoOnline.Domain.Entities;
using CursoOnline.Domain.Interfaces.Base;

namespace CursoOnline.Domain.Interfaces
{
    public interface ICourseRepository : IRepository<Course>
    {
        Course GetByName(string name);
    }
}
