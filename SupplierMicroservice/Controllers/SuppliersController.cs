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
        private readonly IConfiguration _config;
        public SuppliersController(IServices services, IConfiguration config) 
        { 
            _services = services;
            _config = config;
        }
        
        [HttpGet, Route("/getSupplierOfPart")]
        public IActionResult GetSupplierOfPart(string id)
        {
            var supplier=_services.SupplierOfPart(id);
            if(supplier == null)
                return NotFound();
            else
            return Ok(supplier);
        }
        [Route("/addSupplier")]
        [HttpPost]
        public IActionResult Post(SupplierPart supplierPart)
        {
            bool res = _services.AddSupplier(supplierPart);
            if(res)
               return Ok();
            return Conflict();

        }
        //[Route("/editSupplier")]
        [HttpPost, Route("/editSupplier")]
        public IActionResult EditSupplier([FromBody] SupplierPart supplierPart)
        {
            bool res = _services.EditSupplier(supplierPart);
            if (res)
                return Ok();
            return BadRequest();
        }
        [HttpPost, Route("/updateFeedback")]
        public IActionResult UpdateFeedback(int feedback, [FromBody] string sid)
        {
            bool res= _services.UpdateFeedback(feedback, sid);
            if(res)
               return Ok();
            return BadRequest();
        }
        
    }
}
