using TaskManager.Models;

namespace TaskManager.Services
{
    public class TaskService
    {
        private readonly List<Models.Task> _task;
        private readonly TaskRepository _taskRepository;
        private int _nextId;

        public TaskService(TaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
            _task = _taskRepository.LoadTasks();

            _nextId = _task.Any() ? _task.Max(t => t.Id) + 1 : 1;
        }

        public IReadOnlyList<Models.Task> GetAllTask()
        {
            return _task;
        }

        public Models.Task AddTask(string title, string description, TaskPriority priority, DateTime dueDate)
        {
            Models.Task task = new Models.Task(_nextId, title, description, TaskItemStatus.Pending, priority, dueDate);

            _task.Add(task);
            _nextId = _nextId + 1;
            _taskRepository.SaveTask(_task);

            return task;
        }

        public bool MarkComplete(int id)
        {
            var task = _task.FirstOrDefault(t => t.Id == id);
            if (task is null) return false;

            task.Status = TaskItemStatus.Completed;
            _taskRepository.SaveTask(_task); 
            return true;
        }

        public bool DeleteTask(int id)
        {
            var task = _task.FirstOrDefault(t => t.Id == id);
            if (task is null) return false;

            _task.Remove(task);
            _taskRepository.SaveTask(_task);
            return true;
        }
    }
}
