using TaskManager.Models;
using TaskManager.Services;

var taskRepository = new TaskRepository("tasks.json");
var taskService = new TaskService(taskRepository);
bool running = true;

while (running)
{
    Console.WriteLine("\n--- Task Manager ---");
    Console.WriteLine("1. Add Task");
    Console.WriteLine("2. View Tasks");
    Console.WriteLine("3. Mark Task Complete");
    Console.WriteLine("4. Delete Task");
    Console.WriteLine("5. Exit");
    Console.WriteLine("6. Edit Task");
    Console.WriteLine("Choose an option: ");

    string? choice = Console.ReadLine();

    switch (choice)
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
            

            bool viewTasks = true;

            while (viewTasks)
            {
                Console.WriteLine("\nView Task");
                Console.WriteLine("1. View All");
                Console.WriteLine("2. Filter By Status");
                Console.WriteLine("3. Filter By Priority");
                Console.WriteLine("4. Sort By Due Date");
                Console.WriteLine("5. Done");
                Console.Write("Choose a field to edit: ");

                string viewChoice = Console.ReadLine() ?? "";

                switch (viewChoice)
                {
                    case "1":
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
                    case "2":
                        Console.WriteLine("Enter status (Pending/InProgress/Completed): ");
                        var inputStatus = Console.ReadLine() ?? "";

                        if (!Enum.TryParse<TaskItemStatus>(inputStatus, true, out TaskItemStatus status))
                        {
                            Console.WriteLine("Invalid status. Please enter valid status.");
                            break;
                        }

                        var filteredStatus = taskService.GetTasksByStatus(status);

                        if (filteredStatus.Count == 0)
                        {
                            Console.WriteLine($"No tasks found with status: {status}.");
                            break;
                        }

                        foreach (var filteredTask in filteredStatus)
                        {
                            Console.WriteLine($"[{filteredTask.Id}] {filteredTask.Title} - {filteredTask.Status} - {filteredTask.Priority} - Due: {filteredTask.DueDate:yyyy-MM-dd}");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Enter priority (High/Medium/Low): ");
                        var inputPriority = Console.ReadLine() ?? "";

                        if(!Enum.TryParse<TaskPriority>(inputPriority, true, out TaskPriority priorityValue))
                        {
                            Console.WriteLine("Invalid status. Please enter valid status.");
                            break;
                        }

                        var filteredPriority = taskService.GetTasksByPriority(priorityValue);

                        if (filteredPriority.Count == 0)
                        {
                            Console.WriteLine($"No tasks found with priority: {priorityValue}.");
                            break;
                        }

                        foreach (var filteredTask in filteredPriority)
                        {
                            Console.WriteLine($"[{filteredTask.Id}] {filteredTask.Title} - {filteredTask.Status} - {filteredTask.Priority} - Due: {filteredTask.DueDate:yyyy-MM-dd}");
                        }
                        break;
                    case "4":
                        var sortedDueDate = taskService.GetTasksSortedByDueDate();

                        foreach (var filteredTask in sortedDueDate)
                        {
                            Console.WriteLine($"[{filteredTask.Id}] {filteredTask.Title} - {filteredTask.Status} - {filteredTask.Priority} - Due: {filteredTask.DueDate:yyyy-MM-dd}");
                        }
                        break;
                    case "5":
                        viewTasks = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
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
        case "6":
            Console.Write("Enter task ID to edit: ");
            string editIdInput = Console.ReadLine() ?? "";

            if (!int.TryParse(editIdInput, out int editId))
            {
                Console.WriteLine("Invalid ID. Please enter a number.");
                break;
            }

            var taskToEdit = taskService.GetTaskById(editId);
            if (taskToEdit is null)
            {
                Console.WriteLine($"No task found with ID {editId}.");
                break;
            }

            bool editing = true;
            while (editing)
            {
                Console.WriteLine($"\nEditing Task [{taskToEdit.Id}]");
                Console.WriteLine($"1. Title: {taskToEdit.Title}");
                Console.WriteLine($"2. Description: {taskToEdit.Description}");
                Console.WriteLine($"3. Priority: {taskToEdit.Priority}");
                Console.WriteLine($"4. Due Date: {taskToEdit.DueDate:yyyy-MM-dd}");
                Console.WriteLine("5. Done Editing");
                Console.Write("Choose a field to edit: ");

                string editChoice = Console.ReadLine() ?? "";

                switch (editChoice)
                {
                    case "1":
                        Console.Write("New title: ");
                        taskToEdit.Title = Console.ReadLine() ?? "";
                        taskService.SaveChanges();
                        break;
                    case "2":
                        Console.Write("New description: ");
                        taskToEdit.Description = Console.ReadLine() ?? "";
                        taskService.SaveChanges();
                        break;
                    case "3":
                        Console.Write("New Priority (High/Medium/Low): ");
                        string newPriority = Console.ReadLine() ?? "";

                        if (!Enum.TryParse<TaskPriority>(newPriority, true, out TaskPriority newPriorityValue))
                        {
                            Console.WriteLine("Invalid priority. Please enter valid priority value.");
                            break;
                        }

                        taskToEdit.Priority = newPriorityValue;
                        taskService.SaveChanges();
                        break;
                    case "4":
                        Console.Write("New Due Date (e.g. 2026-12-25): ");
                        string newDueDate = Console.ReadLine() ?? "";

                        if (!DateTime.TryParse(newDueDate, out DateTime editDueDate))
                        {
                            Console.WriteLine("Invalid due date. Please enter valid due date.");
                            break;
                        }

                        taskToEdit.DueDate = editDueDate;
                        taskService.SaveChanges();
                        break;
                    case "5":
                        editing = false;
                        break;
                    default:
                        Console.WriteLine("Invalid options.");
                        break;
                }
            }
            break;
        default:
            Console.WriteLine("Invalid option, try again.");
            break;
    }
}
