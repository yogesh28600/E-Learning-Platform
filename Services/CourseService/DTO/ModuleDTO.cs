
namespace CourseService.DTO
{
    public class ModuleDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string VideoUrl { get; set; }
        public string AdditionalResources { get; set; }
        public Guid CourseId { get; set; }
    }
}
