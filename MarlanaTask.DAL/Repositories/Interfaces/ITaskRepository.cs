using System;
using System.Collections.Generic;
using System.Text;
using Task.DAL.Entities;

namespace Task.DAL.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        public Task<int> CreateTaskAsync(TaskEntity entity);

        public Task<int> UpdateTaskAsync(TaskEntity entity);

        public Task<int> DeleteTaskAsync(TaskEntity entity);

        public Task<TaskEntity?> GetTaskByNameAsync(string name);

        public Task<TaskEntity?> GetTaskByIdAsync(int id);

    }
}
