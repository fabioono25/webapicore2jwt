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
using rest.Repository.Interface;

namespace rest.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AuthContext _context = null;

        public AuthRepository()
        {
        }

        public AuthRepository(IOptions<Settings> settings)
        {
            _context = new AuthContext(settings);
        }

        public async Task<List<User>> GetUsers()
        {
            var builder = Builders<User>.Filter;
                
            return await _context.Users.Find(_ => true).ToListAsync();;
        }

        public async Task<User> GetUser(string login, string password){

            var builder = Builders<User>.Filter;
            var filter = builder.Eq("Login", login) & builder.Eq("Password", password);

            return await _context.Users
                        .Find(filter)
                        .FirstOrDefaultAsync();
        }
    }
}