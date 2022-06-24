using MarlanaTask.API.Factories.Interfaces;
using MarlanaTask.API.Models;
using MarlanaTask.BLL.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarlanaTask.BLL.Factories.Implementations
{
    public class DtoToModelFactory : IDtoToModelFactory
    {
        public TaskModel TaskModelToDto(TaskDTO dto)
        {
            return new TaskModel { Name = dto.Name, Status = dto.Status };
        }

        public TasksBlockModel TasksBlockModelToDto(TasksBlockDTO dto)
        {
            return new TasksBlockModel { Name = dto.Name, Tasks = DtosToTaskModels(dto.Tasks) };
        }

        private List<TaskModel> DtosToTaskModels(List<TaskDTO> dtos)
        {
            List<TaskModel> taskModels = new List<TaskModel>();

            foreach (var dto in dtos)
            {
                taskModels.Add(TaskModelToDto(dto));
            }

            return taskModels;
        }
    }
}
