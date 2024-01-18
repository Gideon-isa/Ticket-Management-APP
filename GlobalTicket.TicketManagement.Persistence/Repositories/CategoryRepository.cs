using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using GlobalTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTicket.TicketManagement.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(GlobalTicketDbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<List<Category>> GetCategoriesWithEvents(bool includePassedHistory)
        {
            var allCategories = await _dbcontext.Categories.Include(x => x.Events).ToListAsync();
            if(!includePassedHistory)
            {
                allCategories.ForEach(p => p.Events.ToList().RemoveAll(c => c.Date < DateTime.Today));
            }
            return allCategories;
        }
    }
}
