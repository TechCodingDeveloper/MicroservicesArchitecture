namespace MicroservicesArtuchecture.AuthApi.Contracts
{
    public class JwtOptionsContract
    {
        public string Secret { get; set; } = string.Empty;
        public string Issure { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
    }
}
