using AutoMapper;
using FunPart.Entities;
using FunPart.Models;
using FunPart.Repository.IRepos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FunPart.Controllers
{
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepo repository;
        private readonly ILogger<TaskController> logger;
        private readonly IMapper mapper;
        public TaskController(ITaskRepo repository, ILogger<TaskController> logger, IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet("GetAllTasks")]
        public async Task<ActionResult<List<Tasks>>> GetAllTasks()
        {
            try
            {
                var result = await repository.All();
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repo} GetAllTasks function error", typeof(TaskController));
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet("GetTasksById")]
        public async Task<IActionResult> GetTasksById(int id)
        {
            try
            {
                var result = await repository.GetById(id);

                if (result == null) { return NotFound(); }

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repo} GetCategoryById function error", typeof(TaskCategoriesController));
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpDelete("DeleteTasks")]
        public async Task<IActionResult> DeleteTasks([FromQuery] GetByIdInt model)
        {
            try
            {
                var result = await repository.GetById(model.Id);

                if (result == null) { return NotFound($"Категория с id {model.Id} не найдена"); }

                await repository.Delete(model.Id);
                await repository.SaveAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ошибка удаление задач model = {model}", JsonConvert.SerializeObject(model));
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("AddNewTasks")]
        [ProducesResponseType(typeof(Tasks), 201)]
        public async Task<IActionResult> AddNewTasks(TaskModel category)
        {
            try
            {
                var entity = mapper.Map<Tasks>(category);
                await repository.Add(entity);
                await repository.SaveAsync();

                return Ok(new { Id = entity.Id });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repo} AddNewTasks function error", JsonConvert.SerializeObject(category));
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpPut("UpdateTasks")]
        public async Task<IActionResult> UpdateTasks(Tasks category)
        {
            try
            {
                if (category == null) { return BadRequest(); }

                await repository.Update(category);
                await repository.SaveAsync();

                // following up the REST standart on update, we need to return NoContent
                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repo} UdateTasks function error", JsonConvert.SerializeObject(category));
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
