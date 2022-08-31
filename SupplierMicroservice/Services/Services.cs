using Microsoft.EntityFrameworkCore;
using SupplierMicroservice.Models;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace SupplierMicroservice.Services
{
    public class Services : IServices
    {
        private readonly SPContext _context;
        private readonly log4net.ILog _log4net;
        public Services(SPContext context) 
        { 
            _context = context;
            _log4net = log4net.LogManager.GetLogger(typeof(Services));
        }

        public bool AddSupplier(SupplierPart supplierPart)
        {
            _log4net.Info(" Add Aupplier Method in " + nameof(Services));
            try
            {
                Supplier? supplier = _context.Suppliers.Find(supplierPart.SID);
                if (supplier != null) return false;
                if (ValidateSupplierDetails(supplierPart.Supplier))
                {
                    
                    Supplier_Part? part = _context.Parts.Where(p => p.PID == supplierPart.PID).FirstOrDefault();
                    if (part == null)
                    {
                        Supplier supplier1 = supplierPart.Supplier;
                        Supplier_Part part1 = supplierPart.Supplier_Part;
                        supplier1.PartsLink = new Collection<SupplierPart>
                {
                new SupplierPart(){
                    Supplier=supplier1,
                    Supplier_Part = part1
                    }
                 };
                        _context.Suppliers.Add(supplier1);
                        _context.SaveChanges();
                    }
                    if (part != null)
                    {
                        Supplier supplier1 = supplierPart.Supplier;
                        part.SuppliersLink = new Collection<SupplierPart>()
                                             {new SupplierPart{ Supplier = supplier1, Supplier_Part = part } };
                        _context.SaveChanges();        
                    }
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                _log4net.Error(" Exception Here "+ ex.Message + " in " + nameof(Services));
                return false;
            }
        }

        public bool EditSupplier(Supplier supplier)
        {
            _log4net.Info(" Edit Supplier Method in " + nameof(Services));
            try
            {
                var supplier1 = _context.Suppliers.Find(supplier.SID);
                if (ValidateSupplierDetails(supplier) && supplier1!=null)
                {
                    supplier1.SName = supplier.SName;
                    supplier1.SEmail = supplier.SEmail;
                    supplier1.SMobile = supplier.SMobile;
                    supplier1.SAddress = supplier.SAddress;
                    _context.Entry(supplier1).State = EntityState.Modified;
                    _context.SaveChanges();
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                _log4net.Error(" Exception Here " + ex.Message + " in " + nameof(Services));
                return false;
            }
        }


        public IEnumerable<Supplier>? SupplierOfPart(string Pname)
        {
            _log4net.Info(" Supplier Of Part Method in " + nameof(Services));
            IList<Supplier>? supplier = new List<Supplier>();
            try
            {
                Supplier_Part part = _context.Parts.Where(x => EF.Functions.Like(x.PName, $"%{Pname}%")).Single();
                foreach (var s in _context.SupplierParts.Where(x => x.PID == part.PID).ToList())
                {
                    var sup = _context.Suppliers.Where(x => x.SID == s.SID).Select(x =>
                                                       new Supplier
                                                       {
                                                           SID = x.SID,
                                                           SName = x.SName,
                                                           SEmail = x.SEmail,
                                                           SMobile = x.SMobile,
                                                           SAddress = x.SAddress,
                                                           Feedback = x.Feedback
                                                       }).Single();
                    supplier.Add(sup);
                }
                return supplier;
            }
            catch (Exception ex)
            {
                _log4net.Error(" Exception Here " + ex.Message + " in " + nameof(Services));
                return supplier;
            }
        }

        public bool UpdateFeedback(int feedback, string sid)
        {
            _log4net.Info(" Update Feedback Method in " + nameof(Services));
            try
            {
                Supplier? supplier = _context.Suppliers.Where(x => x.SID == sid).Single();
                supplier.Feedback = feedback;
                _context.Entry(supplier).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _log4net.Error(" Exception Here " + ex.Message + " in " + nameof(Services));
                return false;
            }
        }

        public bool ValidateSupplierDetails(Supplier supplier)
        {
            _log4net.Info(" Supplier Details Validation method in " + nameof(Services));
            try
            {
                Regex emailPattern = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
             @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
             @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
                if (emailPattern.IsMatch(supplier.SEmail))
                {
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                _log4net.Error(" Exception Here " + ex.Message + " in " + nameof(Services));
                return false;
            }
        }
    }
}
