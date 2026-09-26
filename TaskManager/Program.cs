using TaskManager.Models;
using TaskManager.Services;

var taskService = new TaskService();
bool running = true;

while (running)
{
    Console.WriteLine("\n--- Task Manager ---");
    Console.WriteLine("1. Add Task");
    Console.WriteLine("2. View Tasks");
    Console.WriteLine("3. Mark Task Complete");
    Console.WriteLine("4. Delete Task");
    Console.WriteLine("5. Exit");
    Console.WriteLine("Choose an option: ");

    string? choice = Console.ReadLine();

    switch(choice)
    {
        case "1":
            Console.Write("Title: ");
            string title = Console.ReadLine() ?? "";

            Console.Write("Description: ");
            string description = Console.ReadLine() ?? "";

            Console.Write("Priority (High/Medium/Low): ");
            string priorityInput = Console.ReadLine() ?? "";

            if (!Enum.TryParse<TaskPriority>(priorityInput, true, out TaskPriority priority))
            {
                Console.WriteLine("Invalid priority. Task not added.");
                break;
            }

            Console.Write("Due Date (e.g. 2026-12-25):");
            string dueDateInput = Console.ReadLine() ?? "";

            if (!DateTime.TryParse(dueDateInput, out DateTime dueDate)) 
            {
                Console.WriteLine("Invalid due date. Task not added.");
                break;
            }

            var newTask = taskService.AddTask(title, description, priority, dueDate);
            Console.WriteLine($"Task added with ID {newTask.Id}");

            break;
        case "2":
            var allTasks = taskService.GetAllTask();

            if (allTasks.Count == 0)
            {
                Console.WriteLine("No tasks found.");
                break;
            }

            foreach (var task in allTasks)
            {
                Console.WriteLine($"[{task.Id}] {task.Title} - {task.Status} - {task.Priority} - Due: {task.DueDate:yyyy-MM-dd}");
            }

            break;
        case "3":
            Console.Write("Enter task ID to mark complete: ");
            string idInput = Console.ReadLine() ?? "";

            if (!int.TryParse(idInput, out int id))
            {
                Console.WriteLine("Invalid ID. Please enter a number.");
                break;
            }

            if (taskService.MarkComplete(id))
            {
                Console.WriteLine($"Task {id} marked as complete.");
            }
            else
            {
                Console.WriteLine($"No task found with ID {id}.");
            }

            break;
        case "4":
            Console.Write("Enter task ID to delete: ");
            string inputId = Console.ReadLine() ?? "";

            if (!int.TryParse(inputId, out int delId))
            {
                Console.WriteLine("Invalid ID. Please enter a number.");
                break;
            }

            if (taskService.DeleteTask(delId))
            {
                Console.WriteLine($"Task {delId} deleted successfully.");
            }
            else
            {
                Console.WriteLine($"No task found with ID {delId}.");
            }

            break;
        case "5":
            running = false;
            break;
        default:
            Console.WriteLine("Invalid option, try again.");
            break;
    }
}