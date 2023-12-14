using System.ComponentModel.DataAnnotations;

namespace HealthFoodApi.Core.Models
{
    public class Food
    {
        public int FoodId { get; set; }
        public string? FoodNameNat { get; set; }
        public string? FoodNameLat { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
    }
}
