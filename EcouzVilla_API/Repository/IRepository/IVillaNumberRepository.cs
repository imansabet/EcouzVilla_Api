using EcouzVilla_API.Models;
using System.Linq.Expressions;

namespace EcouzVilla_API.Repository.IRepository
{
    public interface IVillaNumberRepository : IRepository<VillaNumber>
    {
        Task<VillaNumber> UpdateAsync(VillaNumber entity);

    }
}
