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

            var result = await _dbmanager.Food
                             .Where(x => x.IsActive)
                             .OrderByDescending(x => x.Created)
                             .ToListAsync();

            return result;
        }

        public async Task<ResponseCostumeBase> AddFood(FoodAdd data)
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

            var result = new ResponseCostumeBase()
            {
                StatusCode = 200,
                Content = "მონაცემი წარმატებით დაემატა"
            };
            return (result);
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

        public async Task<ResponseCostume> UploadFoodPhoto(IFormFile file, UploadPhoto uploadPhoto)
        {
            string content = string.Empty;

            var checkData = await _dbmanager.Food.FindAsync(uploadPhoto.FoodId);

            if (checkData == null)
            {
                var notFoundResult = new ResponseCostume
                {
                    StatusCode = 102,
                    Content = $"მონაცემი არ მოიძებნა",
                    ContentType = $"შესაბამის აიდიზე : {uploadPhoto.FoodId}"
                };

                return notFoundResult;
            }

            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                content = Convert.ToBase64String(fileBytes);
            }
            var data = new FoodPhoto()
            {
                ImageFileName = file.ContentType,
                Content = content,
                FoodId = uploadPhoto.FoodId,
                CreateDate = DateTime.Now
            };

            _dbmanager.FoodPhoto.Add(data);
            await _dbmanager.SaveChangesAsync();

            var result = new ResponseCostume()
            {
                StatusCode = 200,
                Content = "მონაცემი წარმატებით წაიშალა"
            };
            return result;
        }

        public async Task<List<FoodPhoto>> GetPhoto()
        {
            var result = await _dbmanager.FoodPhoto.ToListAsync();
            return result;
        }

        public async Task<ResponseCostume> UpdatePhoto(IFormFile file, PhotoUpdate photoUpdate)
        {
            var checkData = await _dbmanager.FoodPhoto.FindAsync(photoUpdate.FoodPhotoId);
            string content = string.Empty;

            if (checkData == null)
            {
                var notFoundResult = new ResponseCostume
                {
                    StatusCode = 102,
                    Content = $"მონაცემი არ მოიძებნა",
                    ContentType = $"შესაბამის აიდიზე : {photoUpdate.FoodPhotoId}"
                };

                return notFoundResult;
            }

            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                content = Convert.ToBase64String(fileBytes);
            }

            var photoUpdateDb = new PhotoUpdateDb()
            {
                ImageFileName = file.ContentType,
                Content = content
            };

            _dbmanager.Entry(checkData).CurrentValues.SetValues(photoUpdateDb);
            await _dbmanager.SaveChangesAsync();

            var result = new ResponseCostume()
            {
                StatusCode = 200,
                Content = "მონაცემი წარმატებით შეიცვალა"
            };
            return result;
        }

        public async Task<ResponseCostume> DeletePhoto(int foodPhotoId)
        {
            var checkData = await _dbmanager.FoodPhoto.FindAsync(foodPhotoId);

            if (checkData == null)
            {
                var notFoundResult = new ResponseCostume
                {
                    StatusCode = 102,
                    Content = $"მონაცემი არ მოიძებნა",
                    ContentType = $"შესაბამის აიდიზე : {foodPhotoId}"
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

        public async Task<Food> GetFoodFoodId(int foodId)
        {
            return await _dbmanager.Food
                .FirstOrDefaultAsync(x => x.IsActive && x.FoodId == foodId);
        }
    }
}
