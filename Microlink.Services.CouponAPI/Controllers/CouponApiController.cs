using AutoMapper;
using Azure;
using Microlink.Services.CouponAPI.Data;
using Microlink.Services.CouponAPI.Models;
using Microlink.Services.CouponAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Microlink.Services.CouponAPI.Controllers
{
    [Route("api/Coupon")]
    [ApiController]
    public class CouponApiController : ControllerBase
    {
        private readonly AppDbContext _Db;
        private readonly ResponseDto _response;
        private readonly IMapper _mapper;

        public CouponApiController(AppDbContext Db,IMapper mapper)
        {
            _Db=Db;
            _response=new ResponseDto();
            _mapper=mapper;
        }

        [HttpGet]
        public ResponseDto Get() {
            try
            {
                IEnumerable<Coupon> ObjList = _Db.Coupons.ToList();
                _response.Result=_mapper.Map<IEnumerable<CouponDto>>(ObjList);
                
            }
            catch (Exception ex) {
                _response.ISSuccess = false;
                _response.Message= ex.Message;
            
            }
            return _response;
        }

        [HttpGet]
        [Route("GetById/{ID}")]
        public ResponseDto Get(int ID)
        {
            try
            {
                Coupon Obj = _Db.Coupons.First(u=>u.CouponId==ID);
                _response.Result = _mapper.Map<Coupon>(Obj);
            }
            catch (Exception ex)
            {
                _response.ISSuccess = false;
                _response.Message = ex.Message;

            }
            return _response;
        }


        [HttpPost]
        public ResponseDto Post([FromBody] CouponDto coupon1)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(coupon1);
                _Db.Coupons.Add(obj);
                _Db.SaveChanges();
                _response.Result=_mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                _response.ISSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPut]
        public ResponseDto Put([FromBody] CouponDto coupon1)
        {
            try
            {

                Coupon obj = _mapper.Map<Coupon>(coupon1);
                _Db.Coupons.Update(obj);
                _Db.SaveChanges();
                _response.Result = _mapper.Map<CouponDto>(obj);

                _response.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                _response.ISSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }


        [HttpDelete]
        [Route("GetById/{ID}")]
        public ResponseDto Delete(int ID)
        {
            try
            {


                Coupon obj =_Db.Coupons.First(u=>u.CouponId==ID);
                _Db.Coupons.Remove(obj);
                _Db.SaveChanges();
   
            }
            catch (Exception ex)
            {
                _response.ISSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }


    }
}
