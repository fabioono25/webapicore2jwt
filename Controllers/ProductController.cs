using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Newtonsoft.Json;
using rest.Infra;
using rest.Model;
using rest.Repository.Interface;

namespace rest.Controllers
{
    [Authorize(Policy = "Member")]
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
        public void Post([FromBody]Product product)
        {
            _ProductRepository.AddProduct(new Product() 
                {   Id = ObjectId.GenerateNewId().ToString(),
                    Name = product.Name, 
                    Code = product.Code,
                    Active = true,
                    ImageUrl = product.ImageUrl,
                    CreatedOn = DateTime.Now, 
                    UpdatedOn = DateTime.Now 
                });
        }

        // PUT api/Products/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]Product product)
        {
            _ProductRepository.UpdateProductDocument(id, product);
        }

        // DELETE api/Products/23243423
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _ProductRepository.RemoveProduct(id);
        }
    }
}
