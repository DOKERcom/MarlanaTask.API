using System.ComponentModel.DataAnnotations;

namespace MarlanaTask.API.Models
{
    public class TaskModel
    {

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}
