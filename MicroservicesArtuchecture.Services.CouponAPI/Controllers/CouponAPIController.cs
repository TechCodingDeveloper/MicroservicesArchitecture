using AutoMapper;
using MicroservicesArtuchecture.Services.CouponAPI.Data;
using MicroservicesArtuchecture.Services.CouponAPI.Storage.Contracts;
using MicroservicesArtuchecture.Services.CouponAPI.Storage.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utility.Contracts;
using static Azure.Core.HttpHeader;

namespace MicroservicesArtuchecture.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        IMapper _mapper;
        public CouponAPIController(AppDbContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        [HttpGet]
        public MessageContract<List<CouponContract>> Get()
        {
            try
            {
                List<CouponEntity> list = _db.Coupons.ToList();
                return _mapper.Map<List<CouponContract>>(list) .ToContract();
            }
            catch (Exception ex)    
            {
                return ex.ToFailContract<List<CouponContract>>();
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public MessageContract<CouponContract> Get(int id)
        {
            try
            {
                CouponEntity coupon = _db.Coupons.Where(dr => dr.CouponId == id).FirstOrDefault();
                return _mapper.Map<CouponContract>(coupon).ToContract();
            }
            catch (Exception ex)
            {
                return ex.ToFailContract<CouponContract>();
            }
        }


        [HttpPost]
        public MessageContract<CouponContract> Post([FromBody] CouponContract couponContract)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return "Create Fail".ToFailContract<CouponContract>();
                }

                CouponEntity couponEntity = _mapper.Map<CouponEntity>(couponContract);
                _db.Coupons.Add(couponEntity);
                _db.SaveChanges();

                return couponContract.ToContract();
            }
            catch (Exception ex)
            {
                return ex.ToFailContract<CouponContract>();
            }
        }

        [HttpPut("{id:int}")]
        public MessageContract<CouponContract> Put(int id, [FromBody] CouponContract couponContract)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return "Update Fail".ToFailContract<CouponContract>();
                }

                CouponEntity existingCoupon = _db.Coupons.FirstOrDefault(c => c.CouponId == id);
                if (existingCoupon == null)
                {
                    return "Coupon not found".ToFailContract<CouponContract>();
                }

                _mapper.Map(couponContract, existingCoupon);
                _db.SaveChanges();

                return couponContract.ToContract();
            }
            catch (Exception ex)
            {
                return ex.ToFailContract<CouponContract>();
            }
        }

        [HttpDelete("{id:int}")]
        public MessageContract<bool> Delete(int id)
        {
            try
            {
                CouponEntity existingCoupon = _db.Coupons.FirstOrDefault(c => c.CouponId == id);
                if (existingCoupon == null)
                {
                    return "Coupon not found".ToFailContract<bool>();
                }

                _db.Coupons.Remove(existingCoupon);
                _db.SaveChanges();

                return true.ToContract();
            }
            catch (Exception ex)
            {
                return ex.ToFailContract<bool>();
            }
        }
    }
}
