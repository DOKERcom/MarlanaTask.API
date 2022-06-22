using System;
using System.Collections.Generic;
using System.Text;
using Task.DAL.Entities;

namespace Task.DAL.Repositories.Interfaces
{
    public interface ITasksBlockRepository
    {
        public Task<int> CreateTasksBlockAsync(TasksBlockEntity entity);

        public Task<int> DeleteTasksBlockAsync(TasksBlockEntity entity);

        public Task<int> UpdateTasksBlockAsync(TasksBlockEntity entity);

        public Task<TasksBlockEntity?> GetTasksBlockByNameAsync(string name);

        public Task<TasksBlockEntity?> GetTasksBlockByIdAsync(int id);

        public Task<int> AddTaskAsync(TaskEntity taskEntity, TasksBlockEntity blockEntity);

        public Task<int> RemoveTaskAsync(TaskEntity taskEntity, TasksBlockEntity blockEntity);
    }
}
