using System;
using System.Linq;
using Domain.Common;
using Domain.Common.Exceptions;

namespace Domain.Entities.Ticket;

public class Ticket:Entity
{
    public string Code { get; private set; }

    public Guid CustomerId { get; private set; }
    public Guid EventId { get; private set; }
    public DateTime CreateDate { get; private set; }

    


    private Ticket(Guid id, string code, Guid customerId, Guid eventId,DateTime createDate)
        : base(id) 
    {
        Code = code;
        CreateDate = createDate;
        CustomerId = customerId;
        EventId = eventId;
        Validate();
    }

    public static Ticket Create(Guid customerId,Guid eventId)
    {
        var id = Guid.NewGuid();
        return new Ticket(id, CombineGuidsSimple(id, customerId, eventId), customerId, eventId, DateTime.UtcNow);
    }
    
    public static Ticket Create(Guid id,string code,Guid customerId,Guid eventId,DateTime createDate)
    {
        return new Ticket(id,code,customerId,eventId,createDate );
    }

    public sealed override void Validate()
    {
        var result = new TicketValidator().Validate(this); 
        if (!result.IsValid)
        {
            // TODO: Return a custom exception
            throw new ValidationException(
                result.Errors.Select(e => e.ErrorMessage).ToList()
            );
        }
    }

    private static string CombineGuidsSimple(Guid guid1, Guid guid2, Guid guid3) { 
        return $"{guid1}{guid2}{guid3}";
    }
    
}
