using System.ComponentModel.DataAnnotations;

namespace MarlanaTask.API.Models
{
    public class TasksBlockModel
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        public virtual List<TaskModel> Tasks { get; set; }
        public TasksBlockModel()
        {
            Tasks = new List<TaskModel>();
        }
    }
}
