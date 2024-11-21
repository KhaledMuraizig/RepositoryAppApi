using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryApp_Api_.DTOs;
using RepositoryApp_Api_.Services;

namespace RepositoryApp_Api_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "employee")]
    public class ItemController : ControllerBase
    {
        IItemService itemService;

        public ItemController(IItemService _itemService)
        {
            itemService = _itemService;
        }

        [HttpPost]
        public void Add(ItemDTO itemDTO)
        {
            itemService.Add(itemDTO);
        }

        [HttpGet]
        [Route("LoadAll")]
        public List<ItemDTO> LoadAll()
        {
            return itemService.LoadAll();
        }

        [HttpDelete]
        public void Delete(int id)
        {
            itemService.Delete(id);
        }

        [HttpGet]
        [Route("Load")]
        public ItemDTO Load(int Id)
        {
            return itemService.Load(Id);
        }

        [HttpPut]
        public void Update(ItemDTO itemDTO)
        {
            itemService.Update(itemDTO);
        }
    }
}
