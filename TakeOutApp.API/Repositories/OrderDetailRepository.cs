using TakeOutApp.API.Models;

namespace TakeOutApp.API.Repositories
{
    public class OrderDetailRepository : BaseRepository<OrderDetail>
    {
        public OrderDetailRepository(TakeOutAppDbContext context) : base(context)
        {
        }
    }
}
