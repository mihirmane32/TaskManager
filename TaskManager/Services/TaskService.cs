using TaskManager.Models;

namespace TaskManager.Services
{
    public class TaskService
    {
        private readonly List<Models.Task> _task = new List<Models.Task>();

        private int _nextId = 1;

        public IReadOnlyList<Models.Task> GetAllTask()
        {
            return _task;
        }

        public Models.Task AddTask(string title, string description, TaskPriority priority, DateTime dueDate)
        {
            Models.Task task = new Models.Task(_nextId, title, description, TaskItemStatus.Pending, priority, dueDate);

            _task.Add(task);
            _nextId = _nextId + 1;

            return task;
        }

        public bool MarkComplete(int id)
        {
            var task = _task.FirstOrDefault(t => t.Id == id);
            if (task is null) return false;

            task.Status = TaskItemStatus.Completed;
            return true;
        }

        public bool DeleteTask(int id)
        {
            var task = _task.FirstOrDefault(t => t.Id == id);
            if (task is null) return false;

            _task.Remove(task);
            return true;
        }
    }
}
