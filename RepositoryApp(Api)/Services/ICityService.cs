using RepositoryApp_Api_.DTOs;

namespace RepositoryApp_Api_.Services
{
    public interface ICityService
    {
        void Add(CityDTO cityDTO);
        void Delete(int Id);
        CityDTO Load(int Id);
        List<CityDTO> LoadAll();
        void Update(CityDTO cityDTO);
    }
}