using EcouzVilla_API.Data;
using EcouzVilla_API.Models;
using EcouzVilla_API.Models.Dto;
using EcouzVilla_API.Repository.IRepository;

namespace EcouzVilla_API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool IsUniqueUser(string username)
        {
        }

        public Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
        }

        public Task<LocalUser> Register(RegisterationRequestDTO registerationRequestDTO)
        {
        }
    }
}
