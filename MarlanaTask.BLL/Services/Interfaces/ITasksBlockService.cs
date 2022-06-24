using MarlanaTask.BLL.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarlanaTask.BLL.Services.Interfaces
{
    public interface ITasksBlockService
    {
        public Task<int> CreateTasksBlockAsync(string name);

        public Task<int> DeleteTasksBlockAsync(string name);

        public Task<int> UpdateTasksBlockNameAsync(string name, string newName);

        public Task<TasksBlockDTO?> GetTasksBlockByNameAsync(string name);

        public Task<TasksBlockDTO?> GetTasksBlockByIdAsync(int id);

        public Task<List<TasksBlockDTO>> GetAllTasksBlocks();

        public Task<int> AddTaskAsync(string tasksBlockName, string taskName);

        public Task<int> RemoveTaskAsync(string tasksBlockName, string taskName);
    }
}
