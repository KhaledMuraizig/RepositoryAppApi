using AutoMapper;
using RepositoryApp_Api_.Data;
using System.ComponentModel.DataAnnotations;

namespace RepositoryApp_Api_.DTOs
{
    [AutoMap(typeof(Warehouse), ReverseMap = true)]
    public class WarehouseDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        [Required]
        public int Country_Id { get; set; }
        [Required]
        public int City_Id { get; set; }

        public CountryDTO Country { get; set; }

        public CityDTO City { get; set; }

    }
}
