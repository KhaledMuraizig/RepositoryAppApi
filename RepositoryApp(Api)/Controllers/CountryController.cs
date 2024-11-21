using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryApp_Api_.DTOs;
using RepositoryApp_Api_.Services;

namespace RepositoryApp_Api_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CountryController : ControllerBase
    {

        ICountryService service;

        public CountryController(ICountryService _service)
        {
            service = _service;
        }

        [HttpPost]
        public void Insert(CountryDTO countryDTO)
        {
            service.Add(countryDTO);
        }

        [HttpGet]
        [Route("GetAll")]
        public List<CountryDTO> GetAll()
        {
            return service.LoadAll();
        }

        [HttpDelete]
        public void Delete(int id)
        {
            service.Delete(id);
        }

        [HttpGet]
        [Route("Load")]
        public CountryDTO Load(int id)
        {
            return service.Load(id);
        }

        [HttpPut]
        public void Update(CountryDTO countryDTO)
        {
            service.Update(countryDTO);
        }
    }
}
