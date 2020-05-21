using Xunit;

namespace CursoOnline.DomainTest.Courses
{
    public class CourseTest
    {
        [Fact]
        public void MustCreateCourse()
        {
            //Arrange
            const string name = "English and Programming";
            const double courseLoad = 80;
            const string targetAudience = "Programmers";
            const double value = 895;

            //Act
            var course = new Courses(name, courseLoad, targetAudience, value);

            //Assert
            Assert.Equal(name, course.Name);
            Assert.Equal(courseLoad, course.CourseLoad);
            Assert.Equal(targetAudience, course.TargetAudience);
            Assert.Equal(value, course.Value);
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
