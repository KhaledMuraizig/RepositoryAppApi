using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RepositoryApp_Api_.Data
{
    [Table("Cities")]
    public class City
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [ForeignKey("country")]
        public int Country_Id { get; set; }

        public Country country { get; set; }

        public List<Warehouse> Warehouses { get; set; }
    }
}
