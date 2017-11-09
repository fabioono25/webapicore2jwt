using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using rest.Model;

namespace rest.Repository.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProduct(string id);
        Task AddProduct(Product item);
        Task<DeleteResult> RemoveProduct(string id);
        Task<ReplaceOneResult> UpdateProduct(string id, Product product);
        Task<ReplaceOneResult> UpdateProductDocument(string id, Product product);
        Task<DeleteResult> RemoveAllProducts();
    }
}