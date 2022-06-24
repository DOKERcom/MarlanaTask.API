using MarlanaTask.BLL.Models.DTO;
using MarlanaTask.BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.BLL.Services.Interfaces;

namespace MarlanaTask.BLL.Services.Implementations
{
    public class BlockAndTaskService : IBlockAndTaskService
    {
        private ITaskService _taskService;
        private ITasksBlockService _tasksBlockService;
        public BlockAndTaskService(
            ITaskService taskService,
            ITasksBlockService tasksBlockService
            )
        {
            _taskService = taskService;
            _tasksBlockService = tasksBlockService;
        }
        public async Task<int> CreateTaskAndJoinToBlock(string blockName, TaskDTO taskDto)
        {
            await _taskService.CreateTaskAsync(taskDto);

            return await _tasksBlockService.AddTaskAsync(blockName, taskDto.Name);
        }
    }
}
