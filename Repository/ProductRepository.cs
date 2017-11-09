using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using rest.Context;
using rest.Model;

namespace rest.Repository.Interface
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context = null;

        public ProductRepository()
        {
        }

        public ProductRepository(IOptions<Settings> settings)
        {
            _context = new ProductContext(settings);
        }

        public async Task AddProduct(Product item)
        {
            await _context.Products.InsertOneAsync(item);
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products.Find(_ => true).ToListAsync();
        }

        public async Task<Product> GetProduct(string id)
        {
            var filter = Builders<Product>.Filter.Eq("Id", id);
            return await _context.Products
                                .Find(filter)
                                .FirstOrDefaultAsync();
        }

        public async Task<DeleteResult> RemoveAllProducts()
        {
            return await _context.Products.DeleteManyAsync(new BsonDocument());
        }

        public async Task<DeleteResult> RemoveProduct(string id)
        {
            return await _context.Products.DeleteOneAsync(
                        Builders<Product>.Filter.Eq("Id", id));
        }

        public async Task<ReplaceOneResult> UpdateProduct(string id, Product item)
        {
            try
            {
                return await _context.Products
                            .ReplaceOneAsync(n => n.Id.Equals(id)
                                            , item
                                            , new UpdateOptions { IsUpsert = true });
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<ReplaceOneResult> UpdateProductDocument(string id, Product product)
        {
            var item = await GetProduct(id) ?? new Product();
            item.Active = product.Active;
            item.Code = product.Code;
            item.Name = product.Name;
            item.UpdatedOn = DateTime.Now;

            return await UpdateProduct(id, item);
        }
    }
}