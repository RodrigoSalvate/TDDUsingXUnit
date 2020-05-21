using CursoOnline.DomainTest._Util;
using ExpectedObjects;
using System;
using Xunit;

namespace CursoOnline.DomainTest.Courses
{
    public class CourseTest
    {
        [Fact]
        public void MustCreateCourse()
        {
            //Arrange
            var expectedCourse = new
            {
                Name = "English and Programming",
                CourseLoad = (double)80,
                TargetAudience = TargetAudience.Programmer,
                Value = (double)895,
            };

            //Act
            var course = new Courses(expectedCourse.Name, expectedCourse.CourseLoad, expectedCourse.TargetAudience, expectedCourse.Value);

            //Assert
            expectedCourse.ToExpectedObject().ShouldMatch(course);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void CourseNameMustNotBeInvalid(string nomeInvalido)
        {
            //Arrange
            var expectedCourse = new
            {
                Name = "English and Programming",
                CourseLoad = (double)80,
                TargetAudience = TargetAudience.Programmer,
                Value = (double)895,
            };

            //Assert
            Assert.Throws<ArgumentException>(() =>
                new Courses(nomeInvalido, expectedCourse.CourseLoad, expectedCourse.TargetAudience, expectedCourse.Value)).WithMessage("Invalid Name");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-564)]
        public void CourseLoadMustNotBeLowerThanOne(double courseLoadInvalid)
        {
            //Arrange
            var expectedCourse = new
            {
                Name = "English and Programming",
                CourseLoad = (double)80,
                TargetAudience = TargetAudience.Programmer,
                Value = (double)895,
            };

            //Assert
            Assert.Throws<ArgumentException>(() =>
               new Courses(expectedCourse.Name, courseLoadInvalid, expectedCourse.TargetAudience, expectedCourse.Value)).WithMessage("Invalid CourseLoad");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-564)]
        public void CourseValueMustNotBeLowerThanOne(double valueInvalid)
        {
            //Arrange
            var expectedCourse = new
            {
                Name = "English and Programming",
                CourseLoad = (double)80,
                TargetAudience = TargetAudience.Programmer,
                Value = (double)895,
            };

            //Assert
            Assert.Throws<ArgumentException>(() =>
                 new Courses(expectedCourse.Name, expectedCourse.CourseLoad, expectedCourse.TargetAudience, valueInvalid)).WithMessage("Invalid Value");
        }
    }

    public enum TargetAudience
    {
        Student,
        Programmer,
        Employee
    }

    public class Courses
    {
        public string Name { get; private set; }
        public double CourseLoad { get; private set; }
        public TargetAudience TargetAudience { get; private set; }
        public double Value { get; private set; }

        public Courses(string name, double courseLoad, TargetAudience targetAudience, double value)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Invalid Name");

            if (courseLoad < 1)
                throw new ArgumentException("Invalid CourseLoad");

            if (value < 1)
                throw new ArgumentException("Invalid Value");

            Name = name;
            CourseLoad = courseLoad;
            TargetAudience = targetAudience;
            Value = value;
        }
    }
}
