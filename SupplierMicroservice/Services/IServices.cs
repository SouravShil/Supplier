using SupplierMicroservice.Models;
namespace SupplierMicroservice.Services
{
    public interface IServices
    {
        IEnumerable<Supplier>? SupplierOfPart(string Pname);
        int AddSupplier(SupplierPart supplierPart);
        bool EditSupplier(Supplier supplier);
        bool UpdateFeedback(int feedback, string sid);
        bool ValidateSupplierDetails(Supplier supplier);
    }
}
