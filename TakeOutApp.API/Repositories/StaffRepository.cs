using TakeOutApp.API.Models;

namespace TakeOutApp.API.Repositories
{
    public class StaffRepository : BaseRepository<Staff>
    {
        public StaffRepository(TakeOutAppDbContext context) : base(context)
        {
        }
    }
}
