using AutoMapper;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using RepositoryApp_Api_.Data;
using RepositoryApp_Api_.DTOs;

namespace RepositoryApp_Api_.Services
{
    public class CityService : ICityService
    {
        Context context;
        IMapper mapper;

        public CityService(Context _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public void Add(CityDTO cityDTO)
        {
            City city = mapper.Map<City>(cityDTO);
            context.Cities.Add(city);
            context.SaveChanges();
        }

        public List<CityDTO> LoadAll()
        {
            List<City> cities = context.Cities.Include("country").ToList();
            List<CityDTO> cityDTOs = mapper.Map<List<CityDTO>>(cities);
            return cityDTOs;
        }

        public void Delete(int Id)
        {
            City city = context.Cities.Find(Id);
            context.Cities.Remove(city);
            context.SaveChanges();
        }

        public CityDTO Load(int Id)
        {
            City city = context.Cities.Find(Id);
            CityDTO cityDTO = mapper.Map<CityDTO>(city);
            return cityDTO;
        }

        public void Update(CityDTO cityDTO)
        {
            City city = mapper.Map<City>(cityDTO);
            context.Cities.Attach(city);
            context.Cities.Entry(city).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }



    }
}
