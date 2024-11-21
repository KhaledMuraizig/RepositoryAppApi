using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RepositoryApp_Api_.Data
{
    [Table("Items")]
    public class Item
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string? KU_Code { get; set; }

        public int Qty { get; set; }

        [Column(TypeName = "decimal")]
        public double CostPrice { get; set; }

        [Column(TypeName = "decimal")]
        public double? MSRP_Price { get; set; }

        [ForeignKey("Warehouse")]
        public int Warehouse_Id { get; set; }

        public Warehouse Warehouse { get; set; }
    }
}
