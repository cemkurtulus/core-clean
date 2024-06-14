namespace Infra.Dto;

public class CustomerLoginDto
{
    public bool Status { get; set; }
    
    public Guid? CustomerId { get; set; }
}