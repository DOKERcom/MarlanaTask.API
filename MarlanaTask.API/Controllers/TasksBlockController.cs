using MarlanaTask.API.Factories.Interfaces;
using MarlanaTask.API.Models;
using MarlanaTask.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MarlanaTask.API.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/[controller]")]
    public class TasksBlockController : ControllerBase
    {

        private ITasksBlockService _tasksBlockService;
        private IModelToDtoFactory _modelToDtoFactory;
        private IDtoToModelFactory _dtoToModelFactory;
        public TasksBlockController(
            ITasksBlockService tasksBlockService,
            IModelToDtoFactory modelToDtoFactory,
            IDtoToModelFactory dtoToModelFactory
            )
        {
            _tasksBlockService = tasksBlockService;

            _modelToDtoFactory = modelToDtoFactory;

            _dtoToModelFactory = dtoToModelFactory;
        }


        [HttpGet]
        public async Task<ActionResult<List<TasksBlockModel>>> AllTasksBlocks()
        {
            try
            {
                List<TasksBlockModel> TasksBlockModels = new List<TasksBlockModel>();

                foreach (var tasksBlock in await _tasksBlockService.GetAllTasksBlocks())
                {
                    TasksBlockModels.Add(_dtoToModelFactory.TasksBlockModelToDto(tasksBlock));
                }

                return TasksBlockModels;
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("One")]
        public async Task<ActionResult<TasksBlockModel>> TasksBlockByName(string name)
        {
            try
            {
                TasksBlockModel TasksBlockModel = _dtoToModelFactory.TasksBlockModelToDto(await _tasksBlockService.GetTasksBlockByNameAsync(name));

                return TasksBlockModel;
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<int>> Create(string name)
        {
            try
            {
                return await _tasksBlockService.CreateTasksBlockAsync(name);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPatch]
        [Route("ChangeName")]
        public async Task<ActionResult<int>> Patch(string name, string newName)
        {
            try
            {
                return await _tasksBlockService.UpdateTasksBlockNameAsync(name, newName);
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
                return await _tasksBlockService.DeleteTasksBlockAsync(name);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("AddTask")]
        public async Task<ActionResult<int>> Put(string tasksBlockName, string taskName)
        {
            try
            {
                return await _tasksBlockService.AddTaskAsync(tasksBlockName, taskName);
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpDelete]
        [Route("RemoveTask")]
        public async Task<ActionResult<int>> Delete(string tasksBlockName, string taskName)
        {
            try
            {
                return await _tasksBlockService.RemoveTaskAsync(tasksBlockName, taskName);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}