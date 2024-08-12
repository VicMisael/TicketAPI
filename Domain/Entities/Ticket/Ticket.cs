using Domain.Common;

namespace Domain.Entities.Ticket;

public class Ticket:Entity
{
    public string Code;
    public DateTime CreateDate;
    public Guid CostumerId;
    public Guid EventId;
}
