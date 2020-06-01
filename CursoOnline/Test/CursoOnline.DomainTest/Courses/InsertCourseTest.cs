using Bogus;
using CursoOnline.Domain.DTOs;
using CursoOnline.Domain.Entities;
using CursoOnline.Domain.Enumerators;
using CursoOnline.Domain.Interfaces;
using CursoOnline.Domain.Services;
using CursoOnline.DomainTest._Builder;
using CursoOnline.DomainTest._Util;
using Moq;
using System;
using Xunit;

namespace CursoOnline.DomainTest.Courses
{

    public class InsertCourseTest
    {
        private readonly CourseDto _courseDto;
        private readonly Mock<ICourseRepository> _courseRepositoryMock;
        private readonly CourseInserter _courseInserter;

        public InsertCourseTest()
        {
            var fake = new Faker();

            _courseDto = new CourseDto()
            {
                Name = fake.Random.Words(),
                Description = fake.Lorem.Paragraph(),
                CourseLoad = fake.Random.Double(1, 1000),
                TargetAudience = fake.Random.Enum<TargetAudience>().ToString(),
                Value = fake.Random.Double(1, 500)
            };

            _courseRepositoryMock = new Mock<ICourseRepository>();

            _courseInserter = new CourseInserter(_courseRepositoryMock.Object);
        }

        //Mock
        [Fact]
        public void ShoudInsertCourse()
        {
            _courseInserter.Insert(_courseDto);

            _courseRepositoryMock.Verify(v => v.Insert(
                It.Is<Course>(
                    a => a.Name == _courseDto.Name &&
                    a.Description == _courseDto.Description &&
                    a.CourseLoad == _courseDto.CourseLoad &&
                    a.Value == _courseDto.Value
                )
              ));
        }

        //Stub
        [Fact]
        public void ShouldNotInsertCoursesWithTheSameName()
        {
            var courseInserted = CourseBuilder.New().WithName(_courseDto.Name).Build();
            _courseRepositoryMock.Setup(s => s.GetByName(_courseDto.Name)).Returns(courseInserted);

            Assert.Throws<ArgumentException>(() => _courseInserter.Insert(_courseDto))
               .WithMessage("Course name already inserted!");
        }

        [Fact]
        public void ShouldNotInformInvalidTargetAudience()
        {
            _courseDto.TargetAudience = "Doctor";

            Assert.Throws<ArgumentException>(() => _courseInserter.Insert(_courseDto))
                .WithMessage("Invalid Target Audience!");
        }
    }
}
