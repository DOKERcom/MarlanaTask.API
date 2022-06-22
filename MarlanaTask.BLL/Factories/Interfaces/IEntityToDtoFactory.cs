using MarlanaTask.BLL.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.DAL.Entities;

namespace MarlanaTask.BLL.Factories.Interfaces
{
    public interface IEntityToDtoFactory
    {
        public TaskDTO TaskEntityToDto(TaskEntity entity);

        public TasksBlockDTO TasksBlockEntityToDto(TasksBlockEntity entity);
    }
}
