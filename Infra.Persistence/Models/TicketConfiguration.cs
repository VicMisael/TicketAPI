using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Persistence.Models;

public class TicketConfiguration:IEntityTypeConfiguration<TicketModel>
{
    public void Configure(EntityTypeBuilder<TicketModel> builder)
    {
        builder.HasOne(ticket => ticket.EventModel).WithMany().HasForeignKey(ticket => ticket.EventModelId);
        builder.HasOne(ticket => ticket.CustomerModel).WithMany().HasForeignKey(ticket => ticket.CustomerModelId);
    }
}
