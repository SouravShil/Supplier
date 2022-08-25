
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace SupplierMicroservice.Models
{
    public class Supplier_Part
    {
        [Key,MaxLength(10, ErrorMessage = "Part Id cannot be longer than 10 characters.")]
        public string PID { get; set; }
        [Required,MaxLength(20, ErrorMessage = "Part Name cannot be longer than 10 characters.")]
        public string PName { get; set; }
        [Required]
        [Range(0,10), DefaultValue(0)]
        public int PQuantity { get; set; }
        [Required]
        public DateTime PDate { get; set; }
        public ICollection<SupplierPart> SuppliersLink { get; set; }
        //public ICollection<Supplier> Supplier { get; set; }
    }
}
