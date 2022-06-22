using Task.DAL.Entities;
using Task.DAL.Repositories.Interfaces;

namespace MarlanaUnitTest
{
    [TestClass]
    public class UnitTestsDALTaskRepository
    {
        private ITaskRepository _taskRepository;
        public UnitTestsDALTaskRepository(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }


        [TestMethod]
        public void CreateTask()
        {
            TaskEntity taskEntity = new TaskEntity { Name = "Work0", Status = false };

            _taskRepository.CreateTaskAsync(taskEntity);

            Assert.IsNotNull(taskEntity);
        }
    }
}