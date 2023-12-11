using System.ComponentModel.DataAnnotations;

namespace MicroservicesArtuchecture.Services.CouponAPI.Models.Entities
{
    public class CouponEntity
    {
        [Key]
        public int CouponId { get; set; }
        [Required]
        public string CouponCode { get; set; }
        [Required]
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}
