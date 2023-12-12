using AutoMapper;
using FunPart.Entities;
using FunPart.Repository.IRepos;
using Microsoft.AspNetCore.Mvc;

namespace FunPart.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserRepo repository;
        private readonly ILogger<UserController> logger;
        public UserController(IUserRepo repository, ILogger<UserController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<List<Users>>> GetAllUsers()
        {
            try
            {
                var result = await repository.All();
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repo} GetAllUsers function error", typeof(UserController));
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet("GetUsersById")]
        public async Task<IActionResult> GetUserById(string Name)
        {
            try
            {
                var result = await repository.GetById(Name);

                if (result == null) { return NotFound(); }

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repo} GetUserById function error", typeof(UserController));
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
