# Task Manager

A small .NET console application for managing tasks. The project currently has a fully working with JSON file persistence: add, view, complete, and delete tasks with data surviving app restarts.

## Current Progress

The project currently includes:

- A `Task` model with fields for ID, title, description, status, priority, and due date
- Enums for task status and priority
- A `TaskService` class with basic functionality to:
  - get all tasks
  - add a task
  - mark a task as complete
  - delete a task
- A `TaskRepository` that saves and loads tasks to/from a JSON file (`tasks.json`)
- Tasks persist across app restarts - The ID counter correctly resumes from the highest saved ID instead of restarting at 1
- A working CLI menu in `Program.cs` with options to add, view, mark complete, and delete tasks
- Basic input validation: invalid priority, invalid due date, invalid/non-existent task ID are all handled without crashing
- A working .NET project structure that builds successfully

## Project Structure

```
TaskManager/
|--Models/
|  |--Task.cs                   # Represents a single task (data only)
|  |--TaskItemStatus.cs         # Enum: Pending, InProgress, Completed
|  |--TaskPriority.cs           # Enum: High, Medium, Low
|
|--Services/
|  |--TaskService.cs            # Owns task list; add/complete/delete logic, ID generation
|  |--TaskRepository.cs         # Handles saving/loading tasks to/from a JSON file
|
|--Program.cs                   # Entry point: working CLI menu (add/view/complete/delete)
```

## Running the Project

From the project root, run:

```bash
dotnet build
dotnet run
```

Build result: succeeded.

## Not yet implemented

- Editing tasks (title/description/due date updates)
- Listing/filtering/sorting tasks (e.g. by status or priority)

## Status

Status: In progress
