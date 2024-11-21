using AutoMapper;
using RepositoryApp_Api_.Data;
using System.ComponentModel.DataAnnotations;

namespace RepositoryApp_Api_.DTOs
{
    [AutoMap(typeof(Item), ReverseMap = true)]
    public class ItemDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string KU_Code { get; set; }
        [Required]
        public int Qty { get; set; }
        [Required]
        public double CostPrice { get; set; }
        [Required]
        public double MSRP_Price { get; set; }
        [Required]
        public int Warehouse_Id { get; set; }

    }
}
