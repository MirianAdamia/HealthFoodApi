using HealthFoodApi.Core.Interfaces;
using HealthFoodApi.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthFoodApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthFoodController : ControllerBase
    {
        private readonly IHealthFoodRepo _repo;
        public HealthFoodController(IHealthFoodRepo repo) 
        { 
            _repo = repo;
        }

        [HttpGet("GetFood")]
        public async Task<IActionResult> GetFood()
        {
            var retValue = await _repo.GetFood();

            return Ok(retValue);
        }
        [HttpPost("AddFood")]
        public async Task<IActionResult> AddFood(FoodAdd data)
        {
            var retValue = await _repo.AddFood(data);

            return Ok(retValue);
        }
        [HttpPost("UpdateFood")]
        public async Task<IActionResult> UpdateFood(FoodUpdate data)
        {
            var retValue = await _repo.UpdateFood(data);

            return Ok(retValue);
        }
        [HttpDelete("DeleteFood")]
        public async Task<IActionResult> DeleteFood(int foodId)
        {
            var retValue = await _repo.DeleteFood(foodId);

            return Ok(retValue);
        }
    };
}
