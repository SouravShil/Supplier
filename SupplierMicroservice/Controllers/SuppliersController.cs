using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SupplierMicroservice.Models;
using SupplierMicroservice.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SupplierMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly IServices _services;
        //private readonly log4net.ILog _log4net;
        public SuppliersController(IServices services) 
        { 
            _services = services;
            //_log4net = log4net.LogManager.GetLogger(typeof(SuppliersController));
        }
        
        [HttpGet, Route("/getSupplierOfPart")]
        public IActionResult GetSupplierOfPart(string name)
        {
            //_log4net.Info(" Http GET request " + nameof(SuppliersController));
            var supplier = _services.SupplierOfPart(name);
            if (supplier.Count()==0 ||supplier==null)
                return NotFound("Supplier Not Found");
             else
                return Ok(supplier);
        }
        [Route("/addSupplier")]
        [HttpPost]
        public IActionResult Post(SupplierPart supplierPart)
        {
           // _log4net.Info(" Http POST request For Add Supplier " + nameof(SuppliersController));
            int res = _services.AddSupplier(supplierPart);
                if (res==1)
                    return Ok("Supplier Added Successfully");
                if(res==0)
                return Conflict("Already Supplier ID Present");
            //if (res == 2)
                return BadRequest("There is a error");
         }
        //[Route("/editSupplier")]
        [HttpPost, Route("/editSupplier")]
        public IActionResult EditSupplier([FromBody] Supplier supplier)
        {
           // _log4net.Info(" Http POST request For Edit Supplier " + nameof(SuppliersController));
            bool res = _services.EditSupplier(supplier);
            if (res)
                return Ok("Supplier Details Edited Successfully");
            return NotFound("Supplier Not Found");
         }
        [HttpPost, Route("/updateFeedback")]
        public IActionResult UpdateFeedback(int feedback, [FromBody] string sid)
        {
            //_log4net.Info(" Http POST request For Update Feedback " + nameof(SuppliersController));
            bool res = _services.UpdateFeedback(feedback, sid);
            if (res)
                 return Ok("Feedback Updated Succesfully");
             return NotFound("Supplier Not Found");
         }
        
    }
}
