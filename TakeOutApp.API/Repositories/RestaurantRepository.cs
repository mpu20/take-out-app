using TakeOutApp.API.Models;

namespace TakeOutApp.API.Repositories
{
    public class RestaurantRepository : BaseRepository<Restaurant>
    {
        public RestaurantRepository(TakeOutAppDbContext context) : base(context)
        {
        }
    }
}
