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
            // TODO: view tasks
            break;
        case "3":
            // TODO: mark complete
            break;
        case "4":
            // TODO: delete task
            break;
        case "5":
            running = false;
            break;
        default:
            Console.WriteLine("Invalid option, try again.");
            break;
    }
}