using AscomSWEngineerTest2.Helpers;
using AscomSWEngineerTest2.Interfaces;

namespace AscomSWEngineerTest2.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> Authenticate(string username, string password)
        {
            var context = new DataContext(_configuration);
            IQueryable<User> usersList = context.Users;

            if (await Task.FromResult(usersList.SingleOrDefault(x => x.Username == username && x.Password == password)) != null)
            {
                return true;
            }
            return false;
        }
    }
}
