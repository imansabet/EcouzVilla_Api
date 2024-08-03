using AutoMapper;
using Azure;
using EcouzVilla_API.Logging;
using EcouzVilla_API.Models;
using EcouzVilla_API.Models.Dto;
using EcouzVilla_API.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace EcouzVillaNumber_API.Controllers
{
    [Route("api/VillaNumberAPI")]
    [ApiController]
    public class VillaNumberAPIController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogging _logger;
        private readonly IVillaNumberRepository _dbVillaNumber;
        private readonly IVillaRepository _dbVilla;

        protected APIResponse _response;

        public VillaNumberAPIController(ILogging logger,IVillaNumberRepository dbVillaNumber,IMapper mapper, IVillaRepository dbVilla)
        {
            _mapper = mapper;
            _logger = logger;
            _dbVillaNumber = dbVillaNumber;
            this._response = new();
            _dbVilla = dbVilla;

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetVillaNumbers()
        {
            try
            {

                IEnumerable<VillaNumber> VillaNumberList = await _dbVillaNumber.GetAllAsync(includeProperties: "Villa"); ;
                _response.Result = _mapper.Map<List<VillaNumberDTO>>(VillaNumberList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("{id:int}", Name = "GetVillaNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetVillaNumber(int id)
        {
            try
            {

                if (id == 0)
                {
                    _logger.Log("Get VillaNumber Error with Id : " + id, "error");
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var VillaNumber = await _dbVillaNumber.GetAsync(u => u.VillaNo == id);
                if (VillaNumber == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound();
                }
                
                _response.Result = _mapper.Map<VillaNumberDTO>(VillaNumber);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString()
            };
            }
            return _response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateVillaNumber([FromBody] VillaNumberCreateDTO createDTO)
        {
            try
            {
                if (await _dbVilla.GetAsync(u => u.Id == createDTO.VillaID) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "Villa ID is Invalid!");
                    return BadRequest(ModelState);
                }
                if (await _dbVilla.GetAsync(u => u.Id == createDTO.VillaID) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "Villa Number already Exists!");
                    return BadRequest(ModelState);
                }
                if (createDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                VillaNumber VillaNumber = _mapper.Map<VillaNumber>(createDTO);


                await _dbVillaNumber.CreateAsync(VillaNumber);
                _response.Result = _mapper.Map<VillaNumberDTO>(VillaNumber);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetVillaNumber", new { id = VillaNumber.VillaNo }, _response);
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString()};
            }

            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteVillaNumber")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> DeleteVillaNumber(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var VillaNumber = await _dbVillaNumber.GetAsync(u => u.VillaNo == id);

                if (VillaNumber == null)
                {
                    return NotFound();
                }
                await _dbVillaNumber.RemoveAsync(VillaNumber);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;

        }

        [HttpPut("{id:int}", Name = "UpdateVillaNumber")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateVillaNumber(int id, [FromBody] VillaNumberUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.VillaNo)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                if (await _dbVilla.GetAsync(u => u.Id == updateDTO.VillaID) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "Villa ID is Invalid!");
                    return BadRequest(ModelState);
                }
                VillaNumber model = _mapper.Map<VillaNumber>(updateDTO);

                await _dbVillaNumber.UpdateAsync(model);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;

        }

       
    }
}
