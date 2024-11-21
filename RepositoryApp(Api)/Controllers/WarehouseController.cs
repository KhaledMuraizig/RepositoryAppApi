using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryApp_Api_.DTOs;
using RepositoryApp_Api_.Services;

namespace RepositoryApp_Api_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "manager")]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService warehouseService;

        public WarehouseController(IWarehouseService _warehouseService)
        {
            warehouseService = _warehouseService;
        }

        [HttpPost]
        public void AddWarehouse(WarehouseDTO warehouseDTO)
        {
            warehouseService.Add(warehouseDTO);
        }

        [HttpGet]
        [Route("LoadAll")]
        public List<WarehouseDTO> LoadAll()
        {
            return warehouseService.LoadAll();
        }

        [HttpDelete]
        public void Delete(int Id)
        {
            warehouseService.Delete(Id);
        }

        [HttpGet]
        [Route("Load")]
        public WarehouseDTO Load(int Id)
        {
            return warehouseService.Load(Id);
        }

        public void Update(WarehouseDTO warehouseDTO)
        {
            warehouseService.Update(warehouseDTO);
        }
    }
}
