using RepositoryApp_Api_.DTOs;

namespace RepositoryApp_Api_.Services
{
    public interface IWarehouseService
    {
        void Add(WarehouseDTO warehouseDTO);
        void Delete(int Id);
        WarehouseDTO Load(int Id);
        List<WarehouseDTO> LoadAll();
        void Update(WarehouseDTO warehouseDTO);
    }
}