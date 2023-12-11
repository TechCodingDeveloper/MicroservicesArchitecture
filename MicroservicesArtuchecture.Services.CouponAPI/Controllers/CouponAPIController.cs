using MicroservicesArtuchecture.Services.CouponAPI.Data;
using MicroservicesArtuchecture.Services.CouponAPI.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utility.Contracts;

namespace MicroservicesArtuchecture.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _db;

        public CouponAPIController(AppDbContext db)
        {
            _db = db;
        }


        [HttpGet]
        public MessageContract<List<CouponEntity>> Get()
        {
            try
            {
                List<CouponEntity> list = _db.Coupons.ToList();
                return list.ToContract();
            }
            catch (Exception ex)    
            {
                return ex.toFailContract<List<CouponEntity>>();
            }

        }

        [HttpGet]
        [Route("{id:int}")]
        public MessageContract<CouponEntity> Get(int id)
        {
            try
            {
                CouponEntity coupon = _db.Coupons.Where(dr => dr.CouponId == id).FirstOrDefault();
                return coupon.ToContract();
            }
            catch (Exception ex)
            {
                return ex.toFailContract<CouponEntity>();
            }
        }
    }
}
