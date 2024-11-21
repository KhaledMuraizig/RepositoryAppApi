using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RepositoryApp_Api_.Data;
using RepositoryApp_Api_.DTOs;

namespace RepositoryApp_Api_.Services
{
    public class WarehouseService : IWarehouseService
    {
        Context context;
        IMapper mapper;

        public WarehouseService(Context _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public void Add(WarehouseDTO warehouseDTO)
        {
            Warehouse warehouse = mapper.Map<Warehouse>(warehouseDTO);
            context.Warehouses.Add(warehouse);
            context.SaveChanges();
        }

        public List<WarehouseDTO> LoadAll()
        {
            List<Warehouse> warehouses = context.Warehouses.Include("Country").Include("City").ToList();
            List<WarehouseDTO> warehouseDTOs = mapper.Map<List<WarehouseDTO>>(warehouses);
            return warehouseDTOs;
        }

        public void Delete(int Id)
        {
            Warehouse warehouse = context.Warehouses.Find(Id);
            context.Warehouses.Remove(warehouse);
            context.SaveChanges();
        }

        public WarehouseDTO Load(int Id)
        {
            Warehouse warehouse = context.Warehouses.Find(Id);
            WarehouseDTO warehouseDTO = mapper.Map<WarehouseDTO>(warehouse);
            return warehouseDTO;
        }

        public void Update(WarehouseDTO warehouseDTO)
        {
            Warehouse warehouse = mapper.Map<Warehouse>(warehouseDTO);
            context.Warehouses.Attach(warehouse);
            context.Entry(warehouse).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
