using AutoMapper;
using MicroservicesArtuchecture.Services.CouponAPI.Data;
using MicroservicesArtuchecture.Services.CouponAPI.Models.Contracts;
using MicroservicesArtuchecture.Services.CouponAPI.Models.Entities;
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
                return ex.toFailContract<List<CouponContract>>();
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
                return ex.toFailContract<CouponContract>();
            }
        }
    }
}
