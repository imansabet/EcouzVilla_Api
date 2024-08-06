using EcouzVilla_API.Models;
using EcouzVilla_API.Models.Dto;

namespace EcouzVilla_API.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<LocalUser> Register(RegisterationRequestDTO  registerationRequestDTO);
    }
}
