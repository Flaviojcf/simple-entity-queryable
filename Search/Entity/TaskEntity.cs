using Search.Enum;

namespace Search.Entity
{
    public sealed class TaskEntity
    {
        private TaskEntity() { }

        public TaskEntity(Guid id, string title, string category, string subCategory, Status status, DateTime createdAt)
        {
            Id = id;
            Title = title;
            Category = category;
            SubCategory = subCategory;
            Status = status;
            CreatedAt = createdAt;
        }

        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Category { get; private set; }
        public string SubCategory { get; private set; }
        public Status Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
