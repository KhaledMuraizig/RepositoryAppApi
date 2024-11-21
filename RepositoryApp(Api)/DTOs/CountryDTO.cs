using AutoMapper;
using RepositoryApp_Api_.Data;
using System.ComponentModel.DataAnnotations;

namespace RepositoryApp_Api_.DTOs
{
    [AutoMap(typeof(Country), ReverseMap = true)]
    public class CountryDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
