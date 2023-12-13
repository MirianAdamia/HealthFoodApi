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
    }
}
