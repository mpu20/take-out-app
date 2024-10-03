using TakeOutApp.API.Models;

namespace TakeOutApp.API.Repositories
{
    public class OrderRepository : BaseRepository<Order>
    {
        public OrderRepository(TakeOutAppDbContext context) : base(context)
        {
        }
    }
}
