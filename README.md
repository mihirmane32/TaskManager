# Task Manager

A small .NET console application for managing tasks. The project currently has a fully working in-memory CLI: add, view, complete, and delete tasks.

## Current Progress

The project currently includes:

- A `Task` model with fields for ID, title, description, status, priority, and due date
- Enums for task status and priority
- A `TaskService` class with basic functionality to:
  - get all tasks
  - add a task
  - mark a task as complete
  - delete a task
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
|
|--Program.cs                   # Entry point (CLI menu) - Todo
```

## Running the Project

From the project root, run:

```bash
dotnet build
dotnet run
```

Build result: succeeded.

## Not yet implemented

- File persistence (save/load tasks to disk - tasks are lost on restart)
- Editing tasks (title/description/due date updates)
- Listing/filtering/sorting tasks (e.g. by status or priority)

## Status

Status: In progress
