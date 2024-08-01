using EcouzVilla_API.Models;
using System.Linq.Expressions;

namespace EcouzVilla_API.Repository.IRepository
{
    public interface IVillaRepository : IRepository<Villa>
    {
        Task<Villa> UpdateAsync(Villa entity);

    }
}
