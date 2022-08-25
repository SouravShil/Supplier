using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SupplierMicroservice.Models
{
    public class Supplier
    {
        [Key, MaxLength(10, ErrorMessage ="Supplier cannot be longer than 10 character.")]
        public string SID { get; set; }
        [Required,MaxLength(20, ErrorMessage = "SName cannot be longer than 20 characters.")]
        public string SName { get; set; }
        
        [Required,MaxLength(20,ErrorMessage ="Email cannot be longer than 20 Characters.")]
        public string SEmail { get; set; }
        [Required]
        public long SMobile {  get; set; }
        [Required,MaxLength(100, ErrorMessage = "Address cannot be longer than 100 characters.")]
        public string SAddress { get; set; }
        [Range(0,10),DefaultValue(0)]
        public int? Feedback { get; set; }
        public ICollection<SupplierPart> PartsLink { get; set; }
    }
}
