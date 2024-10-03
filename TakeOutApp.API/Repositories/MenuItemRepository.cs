using TakeOutApp.API.Models;

namespace TakeOutApp.API.Repositories
{
    public class MenuItemRepository : BaseRepository<MenuItem>
    {
        public MenuItemRepository(TakeOutAppDbContext context) : base(context)
        {
        }
    }
}
