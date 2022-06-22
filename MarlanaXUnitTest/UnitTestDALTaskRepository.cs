using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Task.DAL.DbContexts;
using Task.DAL.Entities;
using Task.DAL.Repositories.Implementations;
using Task.DAL.Repositories.Interfaces;

namespace MarlanaXUnitTest
{
    public class UnitTestDALTaskRepository
    {

        private ITaskRepository _taskRepository;
        public UnitTestDALTaskRepository()
        {
            var services = new ServiceCollection();

            string connection = "Server=localhost;Port=5432;Database=MarlanaTaskDb;User Id=postgres;Password=2288228";

            services.AddDbContext<MarlanaTaskDbContext>(options => options.UseNpgsql(connection));

            services.AddTransient<ITaskRepository, TaskRepository>();

            var serviceProvider = services.BuildServiceProvider();

            _taskRepository = serviceProvider.GetService<ITaskRepository>();
        }

        [Fact]
        public async void CreateTask()
        {

            TaskEntity taskEntity = new TaskEntity { Name = "TaskXTest", Status = false };

            int result = await _taskRepository.CreateTaskAsync(taskEntity);

            Assert.Equal(1, result);

        }

        [Fact]
        public async void UpdateTask()
        {
            int result = 0;

            TaskEntity? taskEntity = await _taskRepository.GetTaskByNameAsync("TaskXTest");

            if (taskEntity != null)
            {
                taskEntity.Name = "TaskXTestNew";
                result = await _taskRepository.UpdateTaskAsync(taskEntity);
            }

            Assert.Equal(1, result);

        }

        [Fact]
        public async void DeleteTask()
        {
            int result = 0;

            TaskEntity? taskEntity = await _taskRepository.GetTaskByNameAsync("TaskXTestNew");

            if (taskEntity != null)
                result = await _taskRepository.DeleteTaskAsync(taskEntity);

            Assert.Equal(1, result);

        }

    }
}