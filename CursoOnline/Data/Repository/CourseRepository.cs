using CursoOnline.Domain.Entities;
using CursoOnline.Domain.Interfaces;
using Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repository
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Course GetByName(string name)
        {
            var entity = _Context.Set<Course>().Where(w => w.Name.Contains(name));
            return entity.Any() ? entity.First() : null;
        }
    }
}
