using MarlanaTask.BLL.Factories.Interfaces;
using MarlanaTask.BLL.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Task.BLL.Services.Interfaces;
using Task.DAL.Repositories.Interfaces;

namespace Task.BLL.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private ITaskRepository _taskRepository;
        private IDtoToEntityFactory _dtoToEntityFactory;
        private IEntityToDtoFactory _entityToDtoFactory;
        public TaskService(
            ITaskRepository taskRepository, 
            IDtoToEntityFactory dtoToEntityFactory,
            IEntityToDtoFactory entityToDtoFactory
            )
        {
            _taskRepository = taskRepository;

            _dtoToEntityFactory = dtoToEntityFactory;

            _entityToDtoFactory = entityToDtoFactory;
        }

        public async Task<int> CreateTaskAsync(TaskDTO dto)
        {
            return await _taskRepository.CreateTaskAsync(_dtoToEntityFactory.DtoToTaskEntity(dto));
        }

        public async Task<int> UpdateTaskStatusAsync(string name, bool status)
        {
            return await _taskRepository.UpdateTaskAsync(name, status);
        }

        public async Task<int> DeleteTaskAsync(string name)
        {
            return await _taskRepository.DeleteTaskAsync(name);
        }

        public async Task<TaskDTO?> GetTaskByNameAsync(string name)
        {
            var task = await _taskRepository.GetTaskByNameAsync(name);

            if (task != null)
                return _entityToDtoFactory.TaskEntityToDto(task);

            return null;
        }

        public async Task<TaskDTO?> GetTaskByIdAsync(int id)
        {
            var task = await _taskRepository.GetTaskByIdAsync(id);

            if (task != null)
                return _entityToDtoFactory.TaskEntityToDto(task);

            return null;
        }
    }
}
