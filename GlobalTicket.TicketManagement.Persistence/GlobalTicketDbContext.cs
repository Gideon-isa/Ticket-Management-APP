using GlobalTicket.TicketManagement.Domain.Common;
using GlobalTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTicket.TicketManagement.Persistence
{
    public class GlobalTicketDbContext :DbContext
    {
        public GlobalTicketDbContext(DbContextOptions<GlobalTicketDbContext> options) : base(options)
        {
            
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configuring the entity to be model from this assembly instead from the Domain
            // using this applyConfigurationsFromAssembly, it will scan for all model config. in this assembly and apply them to the model builder
            // entity modification can be seen in the configuration folder
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GlobalTicketDbContext).Assembly);

            //seed data, added through migrations
            var concertGuid = Guid.Parse("9299ede7-7918-42d3-80bd-c7c9c9d677a3");
            var musicalGuid = Guid.Parse("25381df8-c432-4593-bfa8-c567e8434913");
            var playGuid = Guid.Parse("73d07064-d7fa-42a0-a118-29934d368ec4");
            var conferenceGuid = Guid.Parse("eb45ad73-5854-4976-b310-bd4e865afef2");

            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = concertGuid,
                Name = "Concerts"
            });

            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = musicalGuid,
                Name = "Musicals"
            });

            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = playGuid,
                Name = "Plays"
            });

            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = conferenceGuid,
                Name = "Conferences"
            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventId = Guid.Parse("7f3711a8-b788-437f-84a8-7f827dc30f03"),
                Name = "John Egbert Live",
                Price = 65,
                Artist = "John Egbert",
                Date = DateTime.Now.AddMonths(6),
                Description = "Join John for his farwell tour across 15 continents. John really needs no introduction since he has already mesmerized the world with his banjo.",
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/banjo.jpg",
                CategoryId = concertGuid
            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventId = Guid.Parse("467172f5-25aa-44ad-a0cf-c496e11a8f5c"),
                Name = "The State of Affairs: Michael Live!",
                Price = 85,
                Artist = "Michael Johnson",
                Date = DateTime.Now.AddMonths(9),
                Description = "Michael Johnson doesn't need an introduction. His 25 concert across the globe last year were seen by thousands. Can we add you to the list?",
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/michael.jpg",
                CategoryId = concertGuid
            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventId = Guid.Parse("75149ce3-20bf-4045-9ee6-96b86e285906"),
                Name = "Clash of the DJs",
                Price = 85,
                Artist = "DJ 'The Mike'",
                Date = DateTime.Now.AddMonths(4),
                Description = "DJs from all over the world will compete in this epic battle for eternal fame.",
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/dj.jpg",
                CategoryId = concertGuid
            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventId = Guid.Parse("a34ee542-e804-40bd-aabd-e52e9459c861"),
                Name = "Spanish guitar hits with Manuel",
                Price = 25,
                Artist = "Manuel Santinonisi",
                Date = DateTime.Now.AddMonths(4),
                Description = "Get on the hype of Spanish Guitar concerts with Manuel.",
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/guitar.jpg",
                CategoryId = concertGuid
            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventId = Guid.Parse("0ff6e70d-7518-476c-9394-6d63fdef4491"),
                Name = "Techorama 2021",
                Price = 400,
                Artist = "Many",
                Date = DateTime.Now.AddMonths(10),
                Description = "The best tech conference in the world",
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/conf.jpg",
                CategoryId = conferenceGuid
            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventId = Guid.Parse("c8599a5d-8d5c-447c-aed0-a3cf037c2201"),
                Name = "To the Moon and Back",
                Price = 135,
                Artist = "Nick Sailor",
                Date = DateTime.Now.AddMonths(8),
                Description = "The critics are over the moon and so will you after you've watched this sing and dance extravaganza written by Nick Sailor, the man from 'My dad and sister'.",
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/musical.jpg",
                CategoryId = musicalGuid
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = Guid.Parse("4e7d040c-bbfd-475c-bae5-5bb10d4d8feb"),
                OrderTotal = 400,
                OrderPaid = true,
                OrderPlaced = DateTime.Now,
                UserId = Guid.Parse("a72c71fd-f736-49cc-997f-a9f55a09edf9")
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = Guid.Parse("4901a19c-c9cd-4cf5-ba00-2f99113f1b69"),
                OrderTotal = 135,
                OrderPaid = true,
                OrderPlaced = DateTime.Now,
                UserId = Guid.Parse("af8d4964-cda6-4ffd-9259-fdc4a41fb279")
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = Guid.Parse("2447f156-f484-48e1-a5aa-f35f457345ff"),
                OrderTotal = 85,
                OrderPaid = true,
                OrderPlaced = DateTime.Now,
                UserId = Guid.Parse("c070d80c-eb47-4748-8a34-b89a2320554a")
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = Guid.Parse("c6448885-4618-499b-970a-144a3d04039d"),
                OrderTotal = 245,
                OrderPaid = true,
                OrderPlaced = DateTime.Now,
                UserId = Guid.Parse("7532362f-2f22-49e9-8919-22a210dd4c09")
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = Guid.Parse("e24e71c6-2f23-4840-ba95-9a7da54443aa"),
                OrderTotal = 142,
                OrderPaid = true,
                OrderPlaced = DateTime.Now,
                UserId = Guid.Parse("858811aa-dbe8-40f8-ba31-2724b0093147")
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = Guid.Parse("288d0da0-b1d0-422e-a205-de110989c893"),
                OrderTotal = 40,
                OrderPaid = true,
                OrderPlaced = DateTime.Now,
                UserId = Guid.Parse("326564e5-efa8-4824-aba4-f600cba4ae4c")
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = Guid.Parse("f44cc385-d7ea-4071-ac21-bf8c4f13eb52"),
                OrderTotal = 116,
                OrderPaid = true,
                OrderPlaced = DateTime.Now,
                UserId = Guid.Parse("a6f12d87-bc5c-4fb0-906b-4c5b99415aa1")
            });

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Deleted:
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
