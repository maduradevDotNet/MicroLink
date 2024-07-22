using Microlink.Front.Models;
using Microsoft.AspNetCore.Mvc;

namespace Microlink.Front.Service.IService
{
    public interface ICouponService
    {
        Task<ResponseDto?> GetCouponAsync();
        Task<ResponseDto?> GetCouponByIdAsync(int id);
        Task<ResponseDto?> CreateCouponAsync(CouponDto couponDto);
        Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto);
        Task<ResponseDto?> DeleteCouponAsync(int id);



    }
}
