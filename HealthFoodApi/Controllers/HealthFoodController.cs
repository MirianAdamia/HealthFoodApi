using HealthFoodApi.Core.Interfaces;
using HealthFoodApi.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthFoodApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        [HttpGet("GetFoodFoodId")]
        public async Task<IActionResult> GetFoodFoodId(int foodId)
        {
            var retValue = await _repo.GetFoodFoodId(foodId);

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
        [HttpPost("UploadFoodPhoto")]
        public async Task<IActionResult> UploadFoodPhoto([FromForm] IFormFile file, [FromForm]UploadPhoto uploadPhoto)
        {
            var retValue = await _repo.UploadFoodPhoto(file,uploadPhoto);

            return Ok(retValue);
        }
        [HttpGet("GetPhoto")]
        public async Task<IActionResult> GetPhoto()
        {
            var retValue = await _repo.GetPhoto();

            return Ok(retValue);
        }
        [HttpPost("UpdatePhoto")]
        public async Task<IActionResult> UpdatePhoto([FromForm]IFormFile file,[FromForm]PhotoUpdate photoUpdate)
        {
            var retValue = await _repo.UpdatePhoto(file, photoUpdate);

            return Ok(retValue);
        }
        [HttpDelete("DeletePhoto")]
        public async Task<IActionResult> DeletePhoto(int foodPhotoId)
        {
            var retValue = await _repo.DeletePhoto(foodPhotoId);

            return Ok(retValue);
        }
    };
}
