using Microsoft.EntityFrameworkCore;
using TakeOutApp.API.Models;

namespace TakeOutApp.API.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(TakeOutAppDbContext context) : base(context)
        {
        }

        public async Task<User?> GetUserByPhoneNumberAndPassword(string phoneNumber, string password)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber && u.Password == password);

            return user;
        }

        public async Task<bool> IsUserExist(string phoneNumber)
        {
            return await context.Users.AnyAsync(u => u.PhoneNumber == phoneNumber);
        }
    }
}
