namespace TodoAPI.Models
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsComplete { get; set; }

        public Guid TodoUserId { get; set; }
        public User TodoUser { get; set; }

        public Todo()
        {

        }

        public Todo(Guid id, string title, bool isComplete)
        {
            Id = id;
            Title = title;
            IsComplete = isComplete;
        }

        public override bool Equals(object? obj)
        {
            return obj is Todo todo &&
                   Id.Equals(todo.Id);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
