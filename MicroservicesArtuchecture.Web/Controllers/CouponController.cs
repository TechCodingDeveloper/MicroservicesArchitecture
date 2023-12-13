using MicroservicesArtuchecture.Web.Services.CouponAPI;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicesArtuchecture.Web.Controllers
{
    public class CouponController : Controller
    {
        public async  Task<IActionResult> Index()
        {
            var client = new Client("http://localhost:5000",new HttpClient());


            var result = await client.CouponAPIGETAsync();


            return View(result);
        }

        [HttpGet("CreateCoupon")]
        public async Task<IActionResult> CreateCoupon()
        {
            return View();
        }
        [HttpPost("CreateCoupon")]
        public async Task<IActionResult> CreateCoupon(CouponContract model)
        {
            var client = new Client("http://localhost:5000", new HttpClient());

            var result = await client.CouponAPIPOSTAsync(model);

            return View(new CouponContract());
        }
    }
}
