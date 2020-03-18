using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiTest.Models;
using WebApiTest.Services;
using WebApiTest.Services.Validators;

namespace WebApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _ProductService;
        private readonly ILogger<ProductController> logger;


        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            this._ProductService = productService;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var products = _ProductService.GetAll();
                return Ok(products);
            }
            catch (Exception ex)
            {
                logger.LogError("Something went wrong, message description:" + ex.Message);
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }

            var product = _ProductService.Get(id);

            if (product == null)
            {

                return NotFound();
            }

            return Ok(product);
        }



        [HttpPut("{id}")]
        public IActionResult PutProduct([FromRoute] int id, [FromBody] Product product)
        {
            if (id != product.Id)
            {
                BadRequest();
            }
            try
            {
                _ProductService.Put<ProductValidator>(product);
                return Ok(product);
            }
            catch (ArgumentNullException)
            {
                return NotFound("product Not Found");
            }
            catch (Exception ex)
            {
                logger.LogError("Something went wrong, message description:" + ex.Message);
                return BadRequest(ex);
            }
        }


        [HttpPost]
        public IActionResult Postproduct([FromBody] Product product)
        {
            try
            {
                var p = _ProductService.post<ProductValidator>(product);
                logger.LogInformation("Record added " + product.Id.ToString());
                return Ok(p);
            }
            catch (ArgumentNullException)
            {
                return NotFound("product Not Found  ");
            }
            catch (FluentValidation.ValidationException ex)
            {
                return BadRequest(ex.Errors);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Deleteproduct([FromRoute] int id)
        {
            try
            {
                _ProductService.Delete(id);
                return Ok("Record Deleted");
            }
            catch (ArgumentException)
            {
                return NotFound("product does not exist");
            }
            catch (Exception ex)
            {
                logger.LogError("Something went wrong,  message description: " + ex.Message);
                return BadRequest(ex);
            }
        }

    }
     
}
