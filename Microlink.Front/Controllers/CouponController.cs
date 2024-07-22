using Microlink.Front.Models;
using Microlink.Front.Service;
using Microlink.Front.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace Microlink.Front.Controllers
{
    public class CouponController : Controller
    {
		private readonly ICouponService _couponService;

		public CouponController(ICouponService couponService)
        {
			_couponService=couponService;

		}
        public async Task<IActionResult> Index()
        {
            List<CouponDto?> List = new();
            ResponseDto response = await _couponService.GetCouponAsync();
            if (response.ISSuccess == true) { 
            
            }

            return View();
        }
    }
}
