using EcouzVilla_API.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcouzVilla_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        [HttpGet]
        public IEnumerator<VillaDTO> GetVillas()
        {

        }
        [HttpGet]
        public VillaDTO GetVilla(int id)
        {

        }
    }
}
