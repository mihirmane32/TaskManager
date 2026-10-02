# Task Manager

A small CLI task manager I'm building in .NET as part of learning to think and code like a real engineer, not just things to run. It's fully functional now: add, view, filter, sort, edit, complete, delete tasks, with everything saved to disk so it survives a restart.

## What's working right now

- A `Task` model - just the data: ID, title, description, status, priority, due date
- Enums for status and priority instead of raw strings, so invalid values can't sneak in
- `TaskService` - The brains of the app: add a task, mark one complete, delete one, edit one, list them all
- `TaskRepository` - reads and writes tasks to a JSON file (`tasks.json`), so nothing gets lost between runs
- Tasks actually persist across restarts, and new task IDs pick up from the highest existing ID instead of resetting to 1
- Corrupted `tasks.json` doesn't crash the app - it warns and falls back to an empty list instead
- A working CLI menu in `Program.cs` - add, view (with filter/sort sub-menu), edit, mark complete, delete
- Editing lets you update title, description, priority, or due date one at a time, through a sub-menu, without retyping fields you don't want to change
- Viewing tasks can show everything, filter by status, filter by priority, or sort by due date
- Basic validation everywhere: bad priority, bad date, or a task ID that doesn't exist - none of it crashes the app
- Builds cleanly, no errors

## Project Structure

```
TaskManager/
|-- Models/
|   |-- Task.cs                   # Represents a single task (data only)
|   |-- TaskItemStatus.cs         # Enum: Pending, InProgress, Completed
|   |-- TaskPriority.cs           # Enum: High, Medium, Low
|
|-- Services/
|   |-- TaskService.cs            # Owns task list; add/complete/delete/edit/filter/sort logic, ID generation
|   |-- TaskRepository.cs         # Handles saving/loading tasks to/from a JSON file
|
|-- Program.cs                   # Entry point: working CLI menu (add/view/filter/sort/complete/delete/edit)
```

## Running it

From the project root, run:

```bash
dotnet build
dotnet run
```

## Status

Done
