using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RepositoryApp_Api_.Data
{
    [Table("countries")]
    public class Country
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public List<City> Cities { get; set; }

        public List<Warehouse> Warehouses { get; set; }
    }
}
