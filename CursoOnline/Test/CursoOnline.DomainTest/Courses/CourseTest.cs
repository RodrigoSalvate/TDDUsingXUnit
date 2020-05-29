using Bogus;
using CursoOnline.Domain.Entities;
using CursoOnline.Domain.Enumerators;
using CursoOnline.DomainTest._Builder;
using CursoOnline.DomainTest._Util;
using ExpectedObjects;
using System;
using Xunit;
using Xunit.Abstractions;

namespace CursoOnline.DomainTest.Courses
{
    public class CourseTest : IDisposable
    {
        private readonly ITestOutputHelper _output;
        private string _name;
        private string _description;
        private double _courseLoad;
        private TargetAudience _targetAudience;
        private double _value;
        public CourseTest(ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("Executing constructor !");

            var faker = new Faker();

            _name = faker.Random.Words();
            _description = faker.Lorem.Paragraph();
            _courseLoad = faker.Random.Double(1, 1000);
            _targetAudience = TargetAudience.Programmer;
            _value = faker.Random.Double(100, 1000);
        }

        public void Dispose()
        {
            _output.WriteLine("Executing dispose !");
        }

        [Fact]
        public void MustCreateCourse()
        {
            //Arrange
            var expectedCourse = new
            {
                Name = _name,
                CourseLoad = _courseLoad,
                TargetAudience = _targetAudience,
                Value = _value,
            };

            //Act
            var course = new Course(expectedCourse.Name, _description, expectedCourse.CourseLoad, expectedCourse.TargetAudience, expectedCourse.Value);

            //Assert
            expectedCourse.ToExpectedObject().ShouldMatch(course);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void CourseNameMustNotBeInvalid(string InvalidName)
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
               CourseBuilder.New().WithName(InvalidName).Build()).WithMessage("Invalid Name");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-564)]
        public void CourseLoadMustNotBeLowerThanOne(double courseLoadInvalid)
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
               CourseBuilder.New().WithCourseLoad(courseLoadInvalid).Build()).WithMessage("Invalid CourseLoad");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-564)]
        public void CourseValueMustNotBeLowerThanOne(double valueInvalid)
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
                 CourseBuilder.New().WithValue(valueInvalid).Build()).WithMessage("Invalid Value");
        }
    }
}
