using Microlink.Front.Models;
using Microlink.Front.Service.IService;
using Microlink.Front.Utility;

namespace Microlink.Front.Service
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;

        public CouponService(IBaseService baseService)
        {
            _baseService=baseService;
        }
        public async Task<ResponseDto?> CreateCouponAsync(CouponDto couponDto)
        {
            return await _baseService.SendRequest(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = couponDto,
                Url = SD.CouponApiBase + "/api/Coupon/"
            });
        }

        public async Task<ResponseDto?> DeleteCouponAsync(int id)
        {
            return await _baseService.SendRequest(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.CouponApiBase + "/api/Coupon/" + id
            });
        }

        public async Task<ResponseDto?> GetCouponAsync()
        {
            return await _baseService.SendRequest(new RequestDto()
            {
                ApiType = Utility.SD.ApiType.GET,
                Url=SD.CouponApiBase+ "/api/Coupon"

            });
        }

        public async Task<ResponseDto?> GetCouponByIdAsync(int id)
        {
            return await _baseService.SendRequest(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponApiBase + "/api/Coupon/GetById" + id
            });
        }

        public async Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto)
        {
            return await _baseService.SendRequest(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = couponDto,
                Url = SD.CouponApiBase + "/api/Coupon/"
            });
        }
    }
}
