using MicroservicesArtuchecture.Services.CouponAPI.Data;
using MicroservicesArtuchecture.Services.CouponAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public List<Coupon> Get()
        {
            try
            {
                List<Coupon> list = _db.Coupons.ToList();
                return list;
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet]
        [Route("{id:int}")]
        public Coupon Get(int id)
        {
            try
            {
                Coupon coupon = _db.Coupons.Where(dr => dr.CouponId == id).FirstOrDefault();
                return coupon;
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
