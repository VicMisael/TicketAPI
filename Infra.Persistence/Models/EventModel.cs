using System;

namespace Infra.Persistence.Models;

public record EventModel(
    Guid Id,
    string Name,
    string Type,
    DateTime Date)
{
    
}
