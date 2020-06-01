
namespace CursoOnline.Domain.DTOs
{
    public class CourseDto
    {
        public CourseDto()
        {
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public double CourseLoad { get; set; }
        public string TargetAudience { get; set; }
        public double Value { get; set; }
    }
}
