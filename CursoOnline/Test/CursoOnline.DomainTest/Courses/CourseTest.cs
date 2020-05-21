using ExpectedObjects;
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
                TargetAudience = "Programmers",
                Value = (double)895,
            };

            //Act
            var course = new Courses(expectedCourse.Name, expectedCourse.CourseLoad, expectedCourse.TargetAudience, expectedCourse.Value);

            //Assert
            expectedCourse.ToExpectedObject().ShouldMatch(course);
        }

        public class Courses
        {
            public string Name { get; private set; }
            public double CourseLoad { get; private set; }
            public string TargetAudience { get; private set; }
            public double Value { get; private set; }

            public Courses(string name, double courseLoad, string targetAudience, double value)
            {
                Name = name;
                CourseLoad = courseLoad;
                TargetAudience = targetAudience;
                Value = value;
            }
        }
    }
}
