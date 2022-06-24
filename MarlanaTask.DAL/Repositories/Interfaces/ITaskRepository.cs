using System;
using System.Collections.Generic;
using System.Text;
using Task.DAL.Entities;

namespace Task.DAL.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        public Task<int> CreateTaskAsync(TaskEntity entity);

        public Task<int> UpdateTaskAsync(string name, bool status);

        public Task<int> DeleteTaskAsync(string name);

        public Task<TaskEntity?> GetTaskByNameAsync(string name);

        public Task<TaskEntity?> GetTaskByIdAsync(int id);

    }
}
