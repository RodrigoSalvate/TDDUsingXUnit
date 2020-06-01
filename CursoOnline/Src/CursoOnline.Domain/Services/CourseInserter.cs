using CursoOnline.Domain.DTOs;
using CursoOnline.Domain.Entities;
using CursoOnline.Domain.Enumerators;
using CursoOnline.Domain.Interfaces;
using System;
namespace CursoOnline.Domain.Services
{
    public class CourseInserter
    {
        private ICourseRepository courseRepository;

        public CourseInserter(ICourseRepository _courseRepository)
        {
            courseRepository = _courseRepository;
        }

        public void Insert(CourseDto courseDto)
        {
            var insertedCourse = courseRepository.GetByName(courseDto.Name);

            if (insertedCourse != null)
                throw new ArgumentException("Course name already inserted!");

            if (!Enum.TryParse<TargetAudience>(courseDto.TargetAudience, out var targetAudience))
                throw new ArgumentException("Invalid Target Audience!");

            var course = new Course(courseDto.Name, courseDto.Description, courseDto.CourseLoad, targetAudience, courseDto.Value);
            courseRepository.Insert(course);
        }
    }
}
