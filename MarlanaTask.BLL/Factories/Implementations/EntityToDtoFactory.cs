using MarlanaTask.BLL.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.DAL.Entities;

namespace MarlanaTask.BLL.Factories.Implementations
{
    public class EntityToDtoFactory
    {
        public TaskDTO TaskEntityToDto(TaskEntity entity)
        {
            TaskDTO taskDto = new TaskDTO()
            {
                Name = entity.Name,
                Status = entity.Status,
            };


            return taskDto;
        }

        public TasksBlockDTO TasksBlockEntityToDto(TasksBlockEntity entity)
        {
            TasksBlockDTO tasksBlockDto = new TasksBlockDTO()
            {
                Name = entity.Name,
                Tasks = TasksToDtoEntities(entity.Tasks),
            };

            return tasksBlockDto;
        }
        private List<TaskDTO> TasksToDtoEntities(List<TaskEntity> entities)
        {

            List<TaskDTO> taskDtos = new List<TaskDTO>();

            foreach (var entity in entities)
            {
                taskDtos.Add(TaskEntityToDto(entity));
            }

            return taskDtos;
        }
    
    }
}
