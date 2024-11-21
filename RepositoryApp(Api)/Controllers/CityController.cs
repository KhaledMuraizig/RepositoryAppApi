using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryApp_Api_.DTOs;
using RepositoryApp_Api_.Services;

namespace RepositoryApp_Api_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CityController : ControllerBase
    {
        ICityService service;

        public CityController(ICityService _service)
        {
            service = _service;
        }

        [HttpPost]
        public void AddCity(CityDTO cityDTO)
        {
            service.Add(cityDTO);
        }

        [HttpGet]
        [Route("GetCities")]
        public List<CityDTO> GetCities()
        {
            return service.LoadAll();
        }

        [HttpDelete]
        public void Delete(int Id)
        {
            service.Delete(Id);
        }

        [HttpGet]
        [Route("Load")]
        public CityDTO Load(int Id)
        {
            return service.Load(Id);
        }

        [HttpPut]
        public void Update(CityDTO cityDTO)
        {
            service.Update(cityDTO);
        }
    }
}
