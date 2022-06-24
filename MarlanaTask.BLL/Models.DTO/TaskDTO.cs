using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarlanaTask.BLL.Models.DTO
{
    public class TaskDTO
    {
        

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        public bool Status { get; set; }

    }
}
