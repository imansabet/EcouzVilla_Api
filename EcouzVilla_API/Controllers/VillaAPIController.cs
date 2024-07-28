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
        public ActionResult<IEnumerator<VillaDTO>> GetVillas()
        {
            return Ok();

        }
        [HttpGet]
        public ActionResult<VillaDTO> GetVilla(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            if (villa == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
