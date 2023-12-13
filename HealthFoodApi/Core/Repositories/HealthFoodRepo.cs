using HealthFoodApi.Core.Interfaces;
using HealthFoodApi.Core.Models;
using HealthFoodApi.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace HealthFoodApi.Core.Repositories
{
    public class HealthFoodRepo : IHealthFoodRepo
    {
        private readonly DbRepo _dbmanager;
        public HealthFoodRepo(DbRepo dbmanager)       
        {
            _dbmanager = dbmanager;
        }

        public async Task<IEnumerable<Food>> GetFood()
        {
            var result =  await _dbmanager.Food.ToListAsync();
            var filtre = result.Where(x=>x.IsActive == true);
            return filtre;
        }

        public async Task<string> AddFood(FoodAdd data)
        {
            var food = new Food()
            {
                FoodNameLat = data.FoodNameLat,
                FoodNameNat = data.FoodNameNat,
                Created = DateTime.Now,
                IsActive = true
            };

            _dbmanager.Food.Add(food);
            await _dbmanager.SaveChangesAsync();
            return ("წარმატებით დაემატა პროდუქტი");
        }

        public async Task<ResponseCostume> UpdateFood(FoodUpdate data)
        {
            var checkData = await _dbmanager.Food.FindAsync(data.FoodId);
            if (checkData == null)
            {
                var notFoundResult = new ResponseCostume
                {
                    StatusCode = 102,
                    Content = $"მონაცემი არ მოიძებნა",
                    ContentType = $"შესაბამის აიდიზე : {data.FoodId}"
                };

                return notFoundResult;
            }

            _dbmanager.Entry(checkData).CurrentValues.SetValues(data);
            await _dbmanager.SaveChangesAsync();

            var result = new ResponseCostume()
            {
                StatusCode = 200,
                Content = "მონაცემი წარმატებით შეიცვალა"
            };
            return result;
        }

        public async Task<ResponseCostume> DeleteFood(int foodId)
        {
            var checkData = await _dbmanager.Food.FindAsync(foodId);

            if (checkData == null)
            {
                var notFoundResult = new ResponseCostume
                {
                    StatusCode = 102,
                    Content = $"მონაცემი არ მოიძებნა",
                    ContentType = $"შესაბამის აიდიზე : {foodId}"
                };

                return notFoundResult;
            }

            _dbmanager.Remove(checkData);
            await _dbmanager.SaveChangesAsync();

            var result = new ResponseCostume()
            {
                StatusCode = 200,
                Content = "მონაცემი წარმატებით წაიშალა"
            };
            return result;
        }
    }
}
