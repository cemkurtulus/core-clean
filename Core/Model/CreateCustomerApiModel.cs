using FluentValidation;

namespace Core.Model;

public class CreateCustomerApiModel
{
    public string Name { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
}

public class CreateCustomerValidation : AbstractValidator<CreateCustomerApiModel> 
{
    public CreateCustomerValidation() 
    {
        RuleFor(x => x.Email)
            .NotNull().WithMessage("Is Not Null")
            .EmailAddress().WithMessage("Email invalid");
        RuleFor(x => x.Name)
            .NotNull().WithMessage("Is Not Null");
        RuleFor(x => x.Password)
            .NotNull().WithMessage("Is Not Null")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters");
    }
}