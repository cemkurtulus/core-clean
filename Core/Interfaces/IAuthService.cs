using LoginRequestApiModel = Core.Model.LoginRequestApiModel;
using LoginResponseApiModel = Core.Model.LoginResponseApiModel;

namespace Core.Interfaces;

public interface IAuthService
{
    public Task<LoginResponseApiModel> LoginUser(LoginRequestApiModel requestApi);
}