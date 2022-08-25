using SupplierMicroservice.Models;
namespace SupplierMicroservice.Services
{
    public interface IServices
    {
        IList<Supplier>? SupplierOfPart(string PartId);
        bool AddSupplier(SupplierPart supplierPart);
        bool EditSupplier(SupplierPart supplierPart);
        bool UpdateFeedback(int feedback, string sid);
    }
}
