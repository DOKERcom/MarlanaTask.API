using MarlanaTask.API.Factories.Interfaces;
using MarlanaTask.API.Models;
using MarlanaTask.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.BLL.Services.Interfaces;

namespace MarlanaTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private ITaskService _taskService;
        private IBlockAndTaskService _blockAndTaskService;
        private IModelToDtoFactory _modelToDtoFactory;
        public TaskController(
            ITaskService taskService,
            IModelToDtoFactory modelToDtoFactory,
            IBlockAndTaskService blockAndTaskService
            )
        {
            _taskService = taskService;

            _modelToDtoFactory = modelToDtoFactory;

            _blockAndTaskService = blockAndTaskService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateTaskAndJoinToBlock(string blockName, TaskModel model)
        {
            try
            {
                return await _blockAndTaskService.CreateTaskAndJoinToBlock(blockName, _modelToDtoFactory.TaskModelToDto(model));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPatch]
        [Route("ChangeStatus")]
        public async Task<ActionResult<int>> Patch(string name, bool status)
        {
            try
            {
                return await _taskService.UpdateTaskStatusAsync(name, status);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<ActionResult<int>> Delete(string name)
        {
            try
            {
                return await _taskService.DeleteTaskAsync(name);

            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
