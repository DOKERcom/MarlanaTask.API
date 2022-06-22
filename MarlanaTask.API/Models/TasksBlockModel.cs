namespace MarlanaTask.API.Models
{
    public class TasksBlockModel
    {
        public string Name { get; set; }

        public virtual List<TaskModel> Tasks { get; set; }
        public TasksBlockModel()
        {
            Tasks = new List<TaskModel>();
        }
    }
}
