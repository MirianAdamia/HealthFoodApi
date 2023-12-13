namespace HealthFoodApi.Core.Models
{
    public class FoodUpdate
    {
        public int FoodId { get; set; }
        public string? FoodNameNat { get; set; }
        public string? FoodNameLat { get; set; }
        public bool IsActive { get; set; }
    }
}
