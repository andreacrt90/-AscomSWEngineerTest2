using AscomSWEngineerTest2.Models;
using System.Collections.Generic;

namespace AscomSWEngineerTest2.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> Authenticate(string username, string password);
    }
}
