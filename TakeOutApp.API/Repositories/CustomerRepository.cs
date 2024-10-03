using TakeOutApp.API.Models;

namespace TakeOutApp.API.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>
    {
        public CustomerRepository(TakeOutAppDbContext context) : base(context)
        {
        }
    }
}
