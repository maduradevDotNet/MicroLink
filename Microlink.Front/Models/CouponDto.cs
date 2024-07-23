using System.ComponentModel.DataAnnotations;

namespace Microlink.Front.Models
{
    public class CouponDto
    {
        public int CouponId { get; set; }

        [Required(ErrorMessage = "Coupon code is required")]
        [StringLength(10, ErrorMessage = "Coupon code cannot exceed 10 characters")]
        public string? CouponCode { get; set; }

        [Required(ErrorMessage = "Discount amount is required")]
        [Range(0.01, 100.00, ErrorMessage = "Discount amount must be between 0.01 and 100.00")]
        public double DiscountAmount { get; set; }

        [Required(ErrorMessage = "Minimum amount is required")]
        [Range(0.01, 1000.00, ErrorMessage = "Minimum amount must be between 0.01 and 1000.00")]
        public int MinAmount { get; set; }
    }
}
