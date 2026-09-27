using TaskManager.Models;

namespace TaskManager.Services
{
    public class TaskService
    {
        private readonly List<Models.Task> _tasks;
        private readonly TaskRepository _taskRepository;
        private int _nextId;

        public TaskService(TaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
            _tasks = _taskRepository.LoadTasks();

            _nextId = _tasks.Any() ? _tasks.Max(t => t.Id) + 1 : 1;
        }

        public IReadOnlyList<Models.Task> GetAllTask()
        {
            return _tasks;
        }

        public Models.Task AddTask(string title, string description, TaskPriority priority, DateTime dueDate)
        {
            Models.Task task = new Models.Task(_nextId, title, description, TaskItemStatus.Pending, priority, dueDate);

            _tasks.Add(task);
            _nextId = _nextId + 1;
            _taskRepository.SaveTasks(_tasks);

            return task;
        }

        public bool MarkComplete(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task is null) return false;

            task.Status = TaskItemStatus.Completed;
            _taskRepository.SaveTasks(_tasks); 
            return true;
        }

        public bool DeleteTask(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task is null) return false;

            _tasks.Remove(task);
            _taskRepository.SaveTasks(_tasks);
            return true;
        }

        public Models.Task? GetTaskById(int id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }

        public void SaveChanges()
        {
            _taskRepository.SaveTasks(_tasks);
        }
    }
}
