using AutoMapper;
using RepositoryApp_Api_.Data;
using System.ComponentModel.DataAnnotations;

namespace RepositoryApp_Api_.DTOs
{
    [AutoMap(typeof(City), ReverseMap = true)]
    public class CityDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Country_Id { get; set; }

        public CountryDTO Country { get; set; }

    }
}
