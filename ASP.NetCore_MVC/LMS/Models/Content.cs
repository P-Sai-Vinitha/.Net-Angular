namespace LMS.Models
{
    public class Content
    {
        public int ContentId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int CourseId { get; set; }
    }
}
