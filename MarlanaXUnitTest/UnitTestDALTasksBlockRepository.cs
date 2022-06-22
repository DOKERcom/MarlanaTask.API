using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Task.DAL.DbContexts;
using Task.DAL.Entities;
using Task.DAL.Repositories.Implementations;
using Task.DAL.Repositories.Interfaces;

namespace MarlanaXUnitTest
{
    public class UnitTestDALTasksBlockRepository
    {

        private ITasksBlockRepository _tasksBlockRepository;
        public UnitTestDALTasksBlockRepository()
        {
            var services = new ServiceCollection();

            string connection = "Server=localhost;Port=5432;Database=MarlanaTaskDb;User Id=postgres;Password=2288228";

            services.AddDbContext<MarlanaTaskDbContext>(options => options.UseNpgsql(connection));

            services.AddTransient<ITasksBlockRepository, TasksBlockRepository>();

            var serviceProvider = services.BuildServiceProvider();

            _tasksBlockRepository = serviceProvider.GetService<ITasksBlockRepository>();
        }

        [Fact]
        public async void CreateTasksBlock()
        {

            TasksBlockEntity tasksBlockEntity = new TasksBlockEntity { Name = "TasksBlockXTest" };

            int result = await _tasksBlockRepository.CreateTasksBlockAsync(tasksBlockEntity);

            Assert.Equal(1, result);

        }

        [Fact]
        public async void UpdateTasksBlock()
        {
            int result = 0;

            TasksBlockEntity? taskBlockEntity = await _tasksBlockRepository.GetTasksBlockByNameAsync("TasksBlockXTest");

            if (taskBlockEntity != null)
            {
                taskBlockEntity.Name = "TasksBlockXTestNew";
                result = await _tasksBlockRepository.UpdateTasksBlockAsync(taskBlockEntity);
            }

            Assert.Equal(1, result);

        }

        [Fact]
        public async void DeleteTasksBlock()
        {
            int result = 0;

            TasksBlockEntity? taskBlockEntity = await _tasksBlockRepository.GetTasksBlockByNameAsync("TasksBlockXTestNew");

            if (taskBlockEntity != null)
                result = await _tasksBlockRepository.DeleteTasksBlockAsync(taskBlockEntity);

            Assert.Equal(1, result);

        }

    }
}