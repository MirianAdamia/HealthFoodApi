using HealthFoodApi.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthFoodApi.Core.Interfaces
{
    public interface IHealthFoodRepo
    {
        Task<IEnumerable<Food>> GetFood();
        Task<string> AddFood(FoodAdd data);
        Task<ResponseCostume> UpdateFood(FoodUpdate data);
        Task<ResponseCostume> DeleteFood(int foodId);
        Task<ResponseCostume> UploadFoodPhoto(IFormFile file, UploadPhoto uploadPhoto);
        Task<List<FoodPhoto>> GetPhoto();
        Task<ResponseCostume> UpdatePhoto(IFormFile file, PhotoUpdate photoUpdate);
        Task<ResponseCostume> DeletePhoto(int foodPhotoId);
    }
}
