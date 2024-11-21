using AutoMapper;
using RepositoryApp_Api_.Data;
using RepositoryApp_Api_.DTOs;

namespace RepositoryApp_Api_.Services
{
    public class CountryService : ICountryService
    {
        Context context;
        IMapper mapper;

        public CountryService(Context _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public void Add(CountryDTO countryDTO)
        {
            Country country = mapper.Map<Country>(countryDTO);
            context.Countries.Add(country);
            context.SaveChanges();
        }

        public List<CountryDTO> LoadAll()
        {
            List<Country> countries = context.Countries.ToList();
            List<CountryDTO> countryDTOs = mapper.Map<List<CountryDTO>>(countries);
            return countryDTOs;
        }

        public void Delete(int id)
        {
            Country country = context.Countries.Find(id);
            context.Countries.Remove(country);
            context.SaveChanges();
        }

        public CountryDTO Load(int id)
        {
            Country country = context.Countries.Find(id);
            CountryDTO countryDTO = mapper.Map<CountryDTO>(country);
            return countryDTO;
        }

        public void Update(CountryDTO countryDTO)
        {
            Country country = mapper.Map<Country>(countryDTO);
            context.Countries.Attach(country);
            context.Entry(country).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
