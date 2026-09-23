# Task Manager

A small .NET console application for managing tasks. The project is currently in an early stage and includes the core task model and service layer for task operations.

## Current Progress

The project currently includes:

- A `Task` model with fields for ID, title, description, status, priority, and due date
- Enums for task status and priority
- A `TaskService` class with basic functionality to:
  - get all tasks
  - add a task
  - mark a task as complete
  - delete a task
- A working .NET project structure that builds successfully

## Important Note

The application entry point in [TaskManager/Program.cs](TaskManager/Program.cs) is still the default C# starter template output (`Hello, World!`). The project is functional at the model/service layer, but the interactive console flow and user-facing menu still need to be implemented.

## Project Structure

```
TaskManager/
|--Models/
|  |--Task.cs                   # Represents a single task (data only)
|  |--TaskItemStatus.cs         # Enum: Pending, InProgress, Completed
|  |--TaskPriority.cs           # Enum: High, Medium, Low
|
|--Service/
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

## Verification

This project was verified with a successful build:

```bash
dotnet build
```

Build result: succeeded.

## Not yet implemented

- CLI menu / entry point (`Program.cs`)
- File persistence (save/load tasks to disk)
- Input validation
- Editing tasks (title/description/due date updates)
- Listing/filtering/sorting tasks

## Status

Status: In progress
