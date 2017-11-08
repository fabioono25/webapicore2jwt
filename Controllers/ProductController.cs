using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using rest.Infra;
using rest.Model;
using rest.Repository.Interface;

namespace rest.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _ProductRepository;

        public ProductsController(IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }

        [NoCache]
        [HttpGet]
        public Task<IEnumerable<Product>> Get()
        {
            return GetProductInternal();
        }

        private async Task<IEnumerable<Product>> GetProductInternal()
        {
            return await _ProductRepository.GetAllProducts();
        }

        // GET api/Products/5
        [HttpGet("{id}")]
        public Task<Product> Get(string id)
        {
            return GetProductByIdInternal(id);
        }

        private async Task<Product> GetProductByIdInternal(string id)
        {
            return await _ProductRepository.GetProduct(id) ?? new Product();
        }

        // POST api/Products
        [HttpPost]
        public void Post([FromBody]string value)
        {
            _ProductRepository.AddProduct(new Product() { Name = value, CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now });
        }

        // PUT api/Products/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]string value)
        {
            _ProductRepository.UpdateProductDocument(id, value);
        }

        // DELETE api/Products/23243423
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _ProductRepository.RemoveProduct(id);
        }
    }
}
