namespace TaskManager.Models
{
    public class Task
    {
        public int Id { get; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskItemStatus Status { get; set; }
        public TaskPriority Priority { get; set; }
        public DateTime DueDate { get; set; }

        public Task(int id, string title, string description, TaskItemStatus status, TaskPriority priority, DateTime dueDate)
        {
            Id = id;
            Title = title;
            Description = description;
            Status = status;
            Priority = priority;
            DueDate = dueDate;
        }
    }
}
