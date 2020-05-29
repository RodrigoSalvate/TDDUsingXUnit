using CursoOnline.Domain.Enumerators;
using System;

namespace CursoOnline.Domain.Entities
{
    public class Course
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public double CourseLoad { get; private set; }
        public TargetAudience TargetAudience { get; private set; }
        public double Value { get; private set; }

        public Course(string name, string description, double courseLoad, TargetAudience targetAudience, double value)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Invalid Name");

            if (courseLoad < 1)
                throw new ArgumentException("Invalid CourseLoad");

            if (value < 1)
                throw new ArgumentException("Invalid Value");

            Name = name;
            Description = description;
            CourseLoad = courseLoad;
            TargetAudience = targetAudience;
            Value = value;
        }
    }
}
