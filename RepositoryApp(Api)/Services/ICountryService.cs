using RepositoryApp_Api_.DTOs;

namespace RepositoryApp_Api_.Services
{
    public interface ICountryService
    {
        void Add(CountryDTO countryDTO);
        void Delete(int id);
        CountryDTO Load(int id);
        List<CountryDTO> LoadAll();
        void Update(CountryDTO countryDTO);
    }
}