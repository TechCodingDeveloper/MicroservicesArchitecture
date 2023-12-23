namespace MicroservicesArtuchecture.Services.CouponAPI.Storage.Contracts
{
    public class CouponContract
    {
        public int CouponId { get; set; }
        public string CouponCode { get; set; }
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}
