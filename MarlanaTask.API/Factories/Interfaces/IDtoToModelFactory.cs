using MarlanaTask.API.Models;
using MarlanaTask.BLL.Models.DTO;

namespace MarlanaTask.API.Factories.Interfaces
{
    public interface IDtoToModelFactory
    {
        public TaskModel TaskModelToDto(TaskDTO dto);

        public TasksBlockModel TasksBlockModelToDto(TasksBlockDTO dto);
    }
}
