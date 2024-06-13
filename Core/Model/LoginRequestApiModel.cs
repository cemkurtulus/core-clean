using FluentValidation;

namespace Core.Model;

public class LoginRequestApiModel
{
    public string Email { get; set; }
    public string Password { get; set; }
}
public class LoginRequestApiModelValidation : AbstractValidator<LoginRequestApiModel> 
{
    public LoginRequestApiModelValidation() 
    {
        RuleFor(x => x.Email)
            .NotNull().WithMessage("Is Not Null")
            .EmailAddress().WithMessage("Email invalid");
        RuleFor(x => x.Password)
            .NotNull().WithMessage("Is Not Null")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters");
    }
}