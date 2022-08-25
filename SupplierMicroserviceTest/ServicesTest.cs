using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = NUnit.Framework.Assert;
using Moq;
using NUnit.Framework;
using SupplierMicroservice.Models;
using SupplierMicroservice.Services;

namespace SupplierMicroserviceTest
{
    [TestFixture]
    internal class ServicesTest
    {
        //Supplier supplier1 = new Supplier();
        //[Test]
        //public void AddSupplierTestForValidInput()
        //{
        //    Supplier supplier = new Supplier();
        //    Mock<IServices> mock=new Mock<IServices>();
        //    mock.Setup(x=>x.addSupplier(supplier)).Returns(true);
        //    Assert.AreEqual(true, mock.Object.addSupplier(supplier));
        //}
        //[Test]
        //public void AddSupplierTestForInvalidInput()
        //{
        //    Mock<IServices> mock = new Mock<IServices>();
        //    mock.Setup(x => x.addSupplier(null)).Returns(false);
        //    Assert.AreEqual(false, mock.Object.addSupplier(null));
        //}
        //[Test]
        //public void SupplierOfPartTestForValidInput()
        //{
        //    Supplier supplier = new Supplier();
        //    Mock<IServices> mock = new Mock<IServices>();
        //    mock.Setup(x => x.SupplierOfPart("p1")).Returns(supplier);
        //    Assert.AreEqual(supplier, mock.Object.SupplierOfPart("p1"));
        //}
        //[Test]
        //public void SupplierOfPartTestForInvalidInput()
        //{
        //    Supplier supplier = null;
        //    Mock<IServices> mock = new Mock<IServices>();
        //    mock.Setup(x => x.SupplierOfPart(null)).Returns(supplier);
        //    Assert.AreEqual(supplier, mock.Object.SupplierOfPart(null));
        //}
    }
}
