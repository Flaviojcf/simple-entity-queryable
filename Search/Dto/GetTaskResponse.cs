using Search.Enum;

namespace Search.Dto
{
    public class GetTaskResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string SubCategory { get; set; } = string.Empty;
        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
