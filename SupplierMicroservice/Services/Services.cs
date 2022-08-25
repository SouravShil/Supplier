using Microsoft.EntityFrameworkCore;
using SupplierMicroservice.Models;
using System.Collections.ObjectModel;

namespace SupplierMicroservice.Services
{
    public class Services : IServices
    {
        private readonly SPContext _context;
        public Services(SPContext context) 
        { 
            _context = context; 
        }

        public bool AddSupplier(SupplierPart supplierPart)
        {
            if (supplierPart == null) return false;
            Supplier? supplier = _context.Suppliers.Where(x=>x.SID==supplierPart.SID).FirstOrDefault();
            Supplier_Part? part= _context.Parts.Where(p=>p.PID==supplierPart.PID).FirstOrDefault();
            if (supplier == null && part == null)
            {
                Supplier supplier1=supplierPart.Supplier;
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
                return true;
            }
            if(supplier != null && part==null)
            {
                supplier.PartsLink = new Collection<SupplierPart>
                {new SupplierPart
                {
                    Supplier = supplier,
                    Supplier_Part = supplierPart.Supplier_Part
                } };
                _context.SaveChanges();
                return true;
            }
            if(supplier==null && part!=null)
            {
                Supplier supplier1 = supplierPart.Supplier;
                part.SuppliersLink = new Collection<SupplierPart>(){new SupplierPart
                { Supplier = supplier1, Supplier_Part = part } };
                _context.SaveChanges();
                return true;
            }
            if(supplier!=null && part!=null)
            {
                supplier.PartsLink=new Collection<SupplierPart> { new SupplierPart { Supplier = supplier, Supplier_Part = part } };
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool EditSupplier(SupplierPart supplierPart)
        {
            var supplier=_context.Suppliers.Find(supplierPart.SID);
            //var part = _context.Parts.Find(supplierPart.PID);
            if(supplier==null) return false;

            supplier.SName=supplierPart.Supplier.SName;
            supplier.SEmail=supplierPart.Supplier.SEmail;
            supplier.SMobile=supplierPart.Supplier.SMobile;
            supplier.SAddress=supplierPart.Supplier.SAddress;
            _context.Entry(supplier).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }


        public IList<Supplier>? SupplierOfPart(string PartId)
        {
            IList<Supplier>? supplier = new List<Supplier>();
            foreach(var s in _context.SupplierParts.Where(x => x.PID == PartId).ToList())
            {
                var sup = _context.Suppliers.Where(x => x.SID == s.SID).Select(x=>
                                                   new Supplier
                                                   {
                                                       SID=x.SID,
                                                       SName=x.SName,
                                                       SEmail=x.SEmail,
                                                       SMobile=x.SMobile,
                                                       SAddress=x.SAddress,
                                                       Feedback=x.Feedback
                                                   } ).Single();
                supplier.Add(sup);
             }
            return supplier;
        }

        public bool UpdateFeedback(int feedback, string sid)
        {
            Supplier? supplier = _context.Suppliers.Where(x => x.SID == sid).FirstOrDefault();
            if(supplier==null) return false;
            supplier.Feedback = feedback;
            _context.Entry(supplier).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }
    }
}
