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
    public class ModelToDtoFactory : IModelToDtoFactory
    {
        public TaskDTO TaskModelToDto(TaskModel model)
        {
            return new TaskDTO { Name = model.Name, Status = model.Status};
        }

        public TasksBlockDTO TasksBlockModelToDto(TasksBlockModel model)
        {
            return new TasksBlockDTO { Name = model.Name, Tasks = ModelsToTaskDtos(model.Tasks)};
        }

        private List<TaskDTO> ModelsToTaskDtos(List<TaskModel> models) 
        {
            List<TaskDTO> taskDtos = new List<TaskDTO>();

            foreach (var model in models)
            {
                taskDtos.Add(TaskModelToDto(model));
            }

            return taskDtos;
        }
    }
}
