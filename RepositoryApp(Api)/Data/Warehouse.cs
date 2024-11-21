using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RepositoryApp_Api_.Data
{
    [Table("Warehouses")]
    public class Warehouse
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        [ForeignKey("Country")]
        public int Country_Id { get; set; }


        [ForeignKey("City")]
        public int City_Id { get; set; }

        public Country Country { get; set; }

        public City City { get; set; }

        public List<Item> Items { get; set; }
    }
}
