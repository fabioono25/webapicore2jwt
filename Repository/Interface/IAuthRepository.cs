using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using rest.Model;

namespace rest.Repository.Interface
{
    public interface IAuthRepository
    {
        Task<List<User>> GetUsers();

        Task<User> GetUser(string login, string password);
    }
}