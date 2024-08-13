using Domain.Common;

namespace Domain.Entities.Ticket;

public class Ticket:Entity
{
    public string Code { get; private set; }
    public DateTime CreateDate { get; private set; }
    public Guid CustomerId { get; private set; }
    public Guid EventId { get; private set; }


    public Ticket(string code, DateTime createDate, Guid customerId, Guid eventId)
        : base() 
    {
        Code = code;
        CreateDate = createDate;
        CustomerId = customerId;
        EventId = eventId;
    }


    public Ticket(Guid id, string code, DateTime createDate, Guid customerId, Guid eventId)
        : base(id) 
    {
        Code = code;
        CreateDate = createDate;
        CustomerId = customerId;
        EventId = eventId;
    }

    public override void Validate()
    {
        new TicketValidator().Validate(this); 
    }
}
