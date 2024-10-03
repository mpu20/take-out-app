using Microsoft.EntityFrameworkCore;
using TakeOutApp.API.Models;

namespace TakeOutApp.API.Repositories
{
    public class CategoryRepository : BaseRepository<Category>
    {
        public CategoryRepository(TakeOutAppDbContext context) : base(context)
        {
        }

        public async new Task Create(Category category)
        {
            var existCategory = await context.Categories.FirstOrDefaultAsync(c => c.Id == category.Id || c.Name.Equals(category.Name, StringComparison.OrdinalIgnoreCase);

            if (existCategory != null)
            {
                throw new ArgumentException();
            }

            context.Add(category);
            await context.SaveChangesAsync();
        }
    }
}
