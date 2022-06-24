using MarlanaTask.BLL.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task.BLL.Services.Interfaces
{
    public interface ITaskService
    {
        public Task<int> CreateTaskAsync(TaskDTO dto);

        public Task<int> UpdateTaskStatusAsync(string name, bool status);

        public Task<int> DeleteTaskAsync(string name);

        public Task<TaskDTO?> GetTaskByNameAsync(string name);

        public Task<TaskDTO?> GetTaskByIdAsync(int id);
    }
}
