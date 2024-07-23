using Microlink.Front.Models;
using Microlink.Front.Service;
using Microlink.Front.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microlink.Front.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        public async Task<IActionResult> Index()
        {
            List<CouponDto?> list = new();
            ResponseDto response = await _couponService.GetCouponAsync();
            if (response != null && response.ISSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(list);
        }

        public IActionResult CouponCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CouponCreate(CouponDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto response = await _couponService.CreateCouponAsync(model);
                if (response != null && response.ISSuccess)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, response?.Message);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> CouponEdit(int couponId)
        {
            ResponseDto response = await _couponService.GetCouponByIdAsync(couponId);
            if (response != null && response.ISSuccess)
            {
                CouponDto model = JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(response.Result));
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CouponEdit(CouponDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto response = await _couponService.UpdateCouponAsync(model);
                if (response != null && response.ISSuccess)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, response?.Message);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> CouponDelete(int couponId)
        {
            ResponseDto response = await _couponService.GetCouponByIdAsync(couponId);
            if (response != null && response.ISSuccess)
            {
                CouponDto? model = JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CouponDeletea(int couponId)
        {
            ResponseDto response = await _couponService.DeleteCouponAsync(couponId);
            if (response != null && response.ISSuccess)
            {
                TempData["success"] = "Coupon deleted successfully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return RedirectToAction("Index");
        }
    }
}
