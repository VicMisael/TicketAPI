using Domain.Common;

namespace Domain.Entities.Event;

public class Event:Entity
{
    public string Name { get; private set; }
    public string Type { get; private set; }
    public DateTime Date { get; private set; }


    public Event(string name, string type, DateTime date, int maxTickets)
    {
        Name = name;
        Type = type;
        Date = date;
        Validate();
    }


    public Event(Guid id, string name, string type, DateTime date, int maxTickets)
        : base(id) 
    {
        Name = name;
        Type = type;
        Date = date;
        Validate();
    }

    public sealed override void Validate()
    {
        new EventValidator().Validate(this);
    }
}
