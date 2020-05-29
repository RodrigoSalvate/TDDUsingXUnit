using CursoOnline.Domain.Entities;
using CursoOnline.Domain.Enumerators;

namespace CursoOnline.DomainTest._Builder
{
    public class CourseBuilder
    {
        private string _name = "English and Programming";
        private string _description = " testing the application";
        private double _courseLoad = 80;
        private TargetAudience _targetAudience = TargetAudience.Programmer;
        private double _value = 895;

        public static CourseBuilder New()
        {
            return new CourseBuilder();
        }

        public CourseBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public CourseBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public CourseBuilder WithCourseLoad(double courseLoad)
        {
            _courseLoad = courseLoad;
            return this;
        }

        public CourseBuilder WithtargetAudience(TargetAudience targetAudience)
        {
            _targetAudience = targetAudience;
            return this;
        }

        public CourseBuilder WithValue(double value)
        {
            _value = value;
            return this;
        }

        public Course Build()
        {
            return new Course(_name, _description, _courseLoad, _targetAudience, _value);
        }
    }
}
