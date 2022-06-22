using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarlanaTask.BLL.Models.DTO
{
    public class TasksBlockDTO
    {
        public string Name { get; set; }

        public virtual List<TaskDTO> Tasks { get; set; }
        public TasksBlockDTO()
        {
            Tasks = new List<TaskDTO>();
        }
    }
}
