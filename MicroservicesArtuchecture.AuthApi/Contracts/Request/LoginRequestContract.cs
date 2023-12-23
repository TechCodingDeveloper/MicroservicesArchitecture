namespace MicroservicesArtuchecture.AuthApi.Contracts.Request
{
    public class LoginRequestContract
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
