using MarlanaTask.BLL.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.DAL.Entities;

namespace MarlanaTask.BLL.Factories.Interfaces
{
    public interface IDtoToEntityFactory
    {
        public TaskEntity DtoToTaskEntity(TaskDTO dto);

        public TasksBlockEntity DtoToTasksBlockEntity(TasksBlockDTO dto);
    }
}
