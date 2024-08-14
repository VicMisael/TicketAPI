using System;

namespace Infra.Persistence.Models;

public record CustomerModel(
    Guid Id,
    string Name,
    string Email,
    DateTime BirthDate)
{
    
}
