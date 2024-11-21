using RepositoryApp_Api_.DTOs;

namespace RepositoryApp_Api_.Services
{
    public interface IItemService
    {
        void Add(ItemDTO itemDTO);
        void Delete(int Id);
        ItemDTO Load(int Id);
        List<ItemDTO> LoadAll();
        void Update(ItemDTO itemDTO);
    }
}