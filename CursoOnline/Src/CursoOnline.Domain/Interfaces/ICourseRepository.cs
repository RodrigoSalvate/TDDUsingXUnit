using CursoOnline.Domain.Entities;

namespace CursoOnline.Domain.Interfaces
{
    public interface ICourseRepository
    {
        void Insert(Course course);
        Course GetByName(string name);
    }
}
