namespace SupplierMicroservice.Models
{
    public class SupplierPart
    {
        public string SID { get; set; }
        public string PID { get; set; }
        public Supplier Supplier { get; set; }
        public Supplier_Part Supplier_Part { get; set; }
    }
}
