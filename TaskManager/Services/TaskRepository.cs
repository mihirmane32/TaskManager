using System.Text.Json;

namespace TaskManager.Services
{
    public class TaskRepository
    {
        private readonly string _filePath;

        public TaskRepository(string filePath)
        {
            _filePath = filePath;
        }

        public void SaveTask(List<Models.Task> tasks)
        {
            string json = JsonSerializer.Serialize(tasks);
            File.WriteAllText(_filePath, json);
        }

        public List<Models.Task> LoadTasks()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Models.Task>();
            }

            string json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Models.Task>>(json) ?? new List<Models.Task>();
        }
    }
}
