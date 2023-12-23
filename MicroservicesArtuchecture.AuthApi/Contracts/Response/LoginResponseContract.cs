namespace MicroservicesArtuchecture.AuthApi.Contracts.Response
{
    public class LoginResponseContract
    {
        public UserContract User { get; set; }
        public string Token { get; set; }
    }
}
