using MarlanaTask.BLL.Factories.Interfaces;
using MarlanaTask.BLL.Models.DTO;
using MarlanaTask.BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.DAL.Repositories.Interfaces;

namespace MarlanaTask.BLL.Services.Implementations
{
    public class TasksBlockService : ITasksBlockService
    {
        private ITasksBlockRepository _tasksBlockRepository;
        private IDtoToEntityFactory _dtoToEntityFactory;
        private IEntityToDtoFactory _entityToDtoFactory;
        public TasksBlockService(
            ITasksBlockRepository tasksBlockRepository,
            IDtoToEntityFactory dtoToEntityFactory,
            IEntityToDtoFactory entityToDtoFactory
            )
        {
            _tasksBlockRepository = tasksBlockRepository;

            _dtoToEntityFactory = dtoToEntityFactory;

            _entityToDtoFactory = entityToDtoFactory;
        }

        public async Task<int> CreateTasksBlockAsync(string name)
        {
            return await _tasksBlockRepository.CreateTasksBlockAsync(name);
        }

        public async Task<int> DeleteTasksBlockAsync(string name)
        {
            await _tasksBlockRepository.ClearTasksinTasksBlock(name);

            return await _tasksBlockRepository.DeleteTasksBlockAsync(name);
        }

        public async Task<int> UpdateTasksBlockNameAsync(string name, string newName)
        {
            return await _tasksBlockRepository.UpdateTasksBlockNameAsync(name, newName);
        }

        public async Task<TasksBlockDTO?> GetTasksBlockByNameAsync(string name)
        {
            var taskBlock = await _tasksBlockRepository.GetTasksBlockByNameAsync(name);

            if (taskBlock != null)
                return _entityToDtoFactory.TasksBlockEntityToDto(taskBlock);

            return null;
        }

        public async Task<TasksBlockDTO?> GetTasksBlockByIdAsync(int id)
        {
            var taskBlock = await _tasksBlockRepository.GetTasksBlockByIdAsync(id);

            if (taskBlock != null)
                return _entityToDtoFactory.TasksBlockEntityToDto(taskBlock);

            return null;
        }

        public async Task<List<TasksBlockDTO>> GetAllTasksBlocks() 
        {
            List <TasksBlockDTO> tasksBlockDTOs = new List <TasksBlockDTO>();

            foreach (var tasksBlock in await _tasksBlockRepository.GetAllTasksBlocks())
            {
                tasksBlockDTOs.Add(_entityToDtoFactory.TasksBlockEntityToDto(tasksBlock));
            }

            return tasksBlockDTOs;
        }

        public async Task<int> AddTaskAsync(string tasksBlockName, string taskName)
        {
            return await _tasksBlockRepository.AddTaskAsync(tasksBlockName, taskName);
        }

        public async Task<int> RemoveTaskAsync(string tasksBlockName, string taskName)
        {
            return await _tasksBlockRepository.RemoveTaskAsync(tasksBlockName, taskName);
        }
    }
}
