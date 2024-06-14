using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Core.Interfaces;
using Infra.Dto;
using Infra.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using LoginRequestApiModel = Core.Model.LoginRequestApiModel;
using LoginResponseApiModel = Core.Model.LoginResponseApiModel;

namespace Core.Service;

public class AuthService(ICustomerRepository customerRepository, IMapper mapper, IConfiguration configuration): IAuthService
{
    public async Task<LoginResponseApiModel> LoginUser(LoginRequestApiModel requestApi)
    {
        var loginModel = mapper.Map<LoginRequestDto>(requestApi);
        var result = await customerRepository.Login(loginModel);

        if (!result.Status) throw new Exception("Invalid login credentials");
        var authorization = await GenerateToken(result.CustomerId.GetValueOrDefault());
            
        return new LoginResponseApiModel
        {
            AccessTokenExpireDate = authorization.AccessTokenExpireDate,
            AuthenticateResult= true,
            Token = "Bearer " + authorization.Token
        };

    }

    private Task<LoginResponseApiModel> GenerateToken(Guid customerId)
    {
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["AppSettings:Secret"]));
        var dateTimeNow = DateTime.UtcNow;

        var jwt = new JwtSecurityToken(
            issuer: configuration["AppSettings:ValidIssuer"],
            audience: configuration["AppSettings:ValidAudience"],
            claims: new List<Claim> {
                new Claim("id", customerId.ToString())
            },
            notBefore: dateTimeNow,
            expires: dateTimeNow.Add(TimeSpan.FromMinutes(500)),
            signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
        );

        return Task.FromResult(new LoginResponseApiModel
        {
            Token = new JwtSecurityTokenHandler().WriteToken(jwt),
            AccessTokenExpireDate = dateTimeNow.Add(TimeSpan.FromMinutes(500))
        });
    }
}