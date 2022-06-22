using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Task.DAL.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class TasksBlockEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        public virtual List<TaskEntity> Tasks { get; set; }
        public TasksBlockEntity()
        {
            Tasks = new List<TaskEntity>();
        }
    }
}
