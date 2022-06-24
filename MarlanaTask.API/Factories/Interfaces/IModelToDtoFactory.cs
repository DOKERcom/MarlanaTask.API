using MarlanaTask.API.Models;
using MarlanaTask.BLL.Models.DTO;

namespace MarlanaTask.API.Factories.Interfaces
{
    public interface IModelToDtoFactory
    {
        public TaskDTO TaskModelToDto(TaskModel model);

        public TasksBlockDTO TasksBlockModelToDto(TasksBlockModel model);
    }
}
