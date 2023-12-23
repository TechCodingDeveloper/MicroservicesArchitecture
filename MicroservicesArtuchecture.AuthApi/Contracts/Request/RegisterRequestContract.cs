namespace MicroservicesArtuchecture.AuthApi.Contracts.Request
{
    public class RegisterRequestContract
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
