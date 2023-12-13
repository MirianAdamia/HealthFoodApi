using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace HealthFoodApi.Core.Models
{
    public class ResponseCostume
    {
        public int StatusCode { get; set; }
        public string Content { get; set; }
        public string ContentType { get; set; }
    }
}
