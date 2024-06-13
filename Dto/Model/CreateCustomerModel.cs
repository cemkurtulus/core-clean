using FluentValidation;

namespace Dto.Model;

public class CreateCustomerModel
{
    public string Name { get; set; }
    
    public string Email { get; set; }
}

public class CreateCustomerValidation : AbstractValidator<CreateCustomerModel> 
{
    public CreateCustomerValidation() 
    {
        RuleFor(x => x.Email)
            .NotNull().WithMessage("Is Not Null")
            .EmailAddress().WithMessage("Email invalid");
        RuleFor(x => x.Name)
            .NotNull().WithMessage("Is Not Null");
    }
}