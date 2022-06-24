using MarlanaTask.BLL.Factories.Interfaces;
using MarlanaTask.BLL.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.DAL.Entities;

namespace MarlanaTask.BLL.Factories.Implementations
{
    public class DtoToEntityFactory : IDtoToEntityFactory
    {
        public TaskEntity DtoToTaskEntity(TaskDTO dto)
        {

            TaskEntity taskEntity = new TaskEntity()
            {
                Name = dto.Name,
                Status = dto.Status,
            };


            return taskEntity;
        }

        public TasksBlockEntity DtoToTasksBlockEntity(TasksBlockDTO dto)
        {
            TasksBlockEntity tasksBlockEntity = new TasksBlockEntity()
            {
                Name = dto.Name,
                Tasks = DtosToTaskEntities(dto.Tasks),
            };

            return tasksBlockEntity;
        }

        private List<TaskEntity> DtosToTaskEntities(List<TaskDTO> dtos)
        {

            List<TaskEntity> taskEntities = new List<TaskEntity>();

            foreach (var dto in dtos)
            {
                taskEntities.Add(DtoToTaskEntity(dto));
            }

            return taskEntities;
        }
    }
}
