# Task Manager

A small CLI task manager I'm building in .NET as part of learning to think and code like a real engineer, not just things to run. Right now it's fully functional: you can add, view, complete, and delete tasks, and everything gets saved to disk so it survives a restart.

## What's working right now

- A `Task` model - just the data: ID, title, description, status, priority, due date
- Enums for status and priority instead of raw strings, so invalid values can't sneak in
- `TaskService` - The brains of the app" add a task, mark one complete, delete one, list them all
- `TaskRepository` - reads and writes tasks to a JSON file (`tasks.json`), so nothing gets lost between runs 
- Tasks actually persist across restarts, and new task IDs pick up from the highest existing ID instead of resetting to 1 (this one took a bit of thinking to get right) 
- A working CLI menu in `Program.cs` - add, view, or a task ID that doesn't exist - none of it crashes the app 
- Builds cleanly, no errors

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

## Running it

From the project root, run:

```bash
dotnet build
dotnet run
```

Builds and runs fine as of now.

## Not yet implemented

- Editing an existing task (title/description/due date)
- Filtering/sorting the task list (by status, priority, etc.)

## Status

In progress - core functionality works, polishing and extending from here.
