using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace HealthFoodApi.Core.Models
{
    public class ResponseCostume: ResponseCostumeBase
    {
        public string ContentType { get; set; }
    }
}
