using System.ComponentModel.DataAnnotations;

namespace Microlink.Front.Models
{
    public class CouponDto
    {    
        public int CouponId { get; set; }
        public string? CouponCode { get; set; }
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}
