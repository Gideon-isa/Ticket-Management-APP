using GlobalTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTicket.TicketManagement.Persistence.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        /// <summary>
        /// configuring the event entity to have some constraint on the property name
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
