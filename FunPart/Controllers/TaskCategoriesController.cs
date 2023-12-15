using AutoMapper;
using FunPart.Entities;
using FunPart.Models;
using FunPart.Repository.IRepos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FunPart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskCategoriesController : ControllerBase
    {
        private readonly ITaskCategoryRepo repository;
        private readonly ILogger<TaskCategoriesController> logger;
        private readonly IMapper mapper;
        public TaskCategoriesController(ITaskCategoryRepo repository, ILogger<TaskCategoriesController> logger, IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet("GetAllTaskCategories")]
        public async Task<ActionResult<List<TaskCategories>>> GetAllTaskCategories()
        {
            try
            {
                var result = await repository.All();
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repo} GetAllCategories function error", typeof(TaskCategoriesController));
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet("GetTaskCategoriesById")]
        public async Task<IActionResult> GetTaskCategoriesById(string Name)
        {
            try
            {
                var result = await repository.GetById(Name);

                if (result == null) { return NotFound(); }

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repo} GetCategoryById function error", typeof(TaskCategoriesController));
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpDelete("DeleteTaskCategories")]
        public async Task<IActionResult> DeleteTaskCategories([FromQuery] GetByIdString model)
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
                logger.LogError(ex, "Ошибка удаление задачи model = {model}", JsonConvert.SerializeObject(model));
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("AddNewTaskCategories")]
        [ProducesResponseType(typeof(TaskCategories), 201)]
        public async Task<IActionResult> AddNewTaskCategories(TaskCategoriesModel category)
        {
            try
            {
                var entity = mapper.Map<TaskCategories>(category);
                await repository.Add(entity);
                await repository.SaveAsync();

                return Ok(new { Id = entity.Nickname });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repo} AddNewTaskCategories function error", JsonConvert.SerializeObject(category));
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpPut("UpdateTaskCategories")]
        public async Task<IActionResult> UpdateTaskCategories(TaskCategories category)
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
                logger.LogError(ex, "{Repo} UdateTaskCategories function error", JsonConvert.SerializeObject(category));
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
