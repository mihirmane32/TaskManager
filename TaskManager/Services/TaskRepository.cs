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

        public void SaveTasks(List<Models.Task> tasks)
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

            try
            {
                string json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<Models.Task>>(json) ?? new List<Models.Task>();
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Warning: tasks.json is corrupted and couldn't be read ({ex.Message}). Starting with an empty task list.");
                return new List<Models.Task>();
            }
        }
    }
}
