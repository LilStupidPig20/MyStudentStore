namespace RTF.Mobile.Infrastructure.Abstractions.Models
{
    public class ProblemsDto
    {
        public string Title { get; set; }

        public ErrorDto[] Errors { get; set; }
    }

    public class ErrorDto
    {
        public string Field { get; set; }

        public string[] Messages { get; set; }
    }
}
