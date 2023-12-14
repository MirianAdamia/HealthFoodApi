namespace HealthFoodApi.Core.Models
{
    public class FoodPhoto
    {
        public int FoodPhotoId { get; set; }
        public int FoodId { get; set; }
        public string? ImageFileName { get; set; }
        public string? Content { get; set; }     
        public DateTime CreateDate { get; set; }
    }
}
