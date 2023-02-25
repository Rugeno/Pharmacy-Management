using MeroPharmaProject.Models.DTO;

namespace MeroPharmaProject.Repository.Abstaract
{
    public interface IUserAuthenticationService
    {
        Task<Status> LoginAsync(LoginModel model);
        Task LogoutAsync();
        Task<Status> RegisterAsync(RegistrationModel model);
        
    }
}
