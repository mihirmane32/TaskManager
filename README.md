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

- [TaskManager/Program.cs](TaskManager/Program.cs) - application entry point
- [TaskManager/Models/Task.cs](TaskManager/Models/Task.cs) - task entity model
- [TaskManager/Models/TaskItemStatus.cs](TaskManager/Models/TaskItemStatus.cs) - task status enum
- [TaskManager/Models/TaskPriority.cs](TaskManager/Models/TaskPriority.cs) - task priority enum
- [TaskManager/Services/TaskService.cs](TaskManager/Services/TaskService.cs) - task management logic
- [TaskManager/TaskManager.csproj](TaskManager/TaskManager.csproj) - .NET project configuration

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
