using Domain.Common;

namespace Domain.Entities;

public class Event:Entity
{
    public string Name;
    public string Type;
    public DateTime Date;
    public int MaxTickets;
}
