namespace Core.Model;

public class LoginResponseApiModel
{
    public bool AuthenticateResult { get; set; }
    
    public required string Token { get; set; }
    public DateTime AccessTokenExpireDate { get; set; }
}