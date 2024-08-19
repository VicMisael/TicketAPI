using System;
using System.Linq;
using Domain.Common;
using Domain.Common.Exceptions;

namespace Domain.Entities.Event;

public class Event:Entity
{
    public string Name { get; private set; }
    public string Type { get; private set; }
    public DateTime Date { get; private set; }

    


    private Event(Guid id, string name, string type, DateTime date)
        : base(id) 
    {
        Name = name;
        Type = type;
        Date = date;

    }


    public static Event Create( string name, string type, DateTime date)
    {
      var @event= new Event(Guid.NewGuid(), name, type, date);
      @event.Validate();
      return @event;
    }
    
    public static Event Create(Guid id, string name, string type, DateTime date)
    {
        return new Event(id, name, type, date);
    }
    
    

    public sealed override void Validate()
    {
       var result = new EventValidator().Validate(this);
        
        if (!result.IsValid)
        {
            // TODO: Return a custom exception
            throw new ValidationException(
                result.Errors.Select(e => e.ErrorMessage).ToList()
            );
        }
    }
}
