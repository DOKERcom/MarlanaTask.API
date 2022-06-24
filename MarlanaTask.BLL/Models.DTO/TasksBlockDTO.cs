using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarlanaTask.BLL.Models.DTO
{
    public class TasksBlockDTO
    {
        

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        public virtual List<TaskDTO> Tasks { get; set; }
        public TasksBlockDTO()
        {
            Tasks = new List<TaskDTO>();
        }
    }
}
