using System;
using System.Linq;
using Domain.Common;
using Domain.Common.Exceptions;

namespace Domain.Entities.Customer;

public class Customer:Entity
{
    public string Name { get; private set; }
    public string EmailAddress { get; private set; }
    public DateTime BirthDate { get; private set; }
    
    
    private Customer(Guid id, string name, string emailAddress, DateTime birthDate)
        : base(id) // Calls the base constructor that sets a specific ID
    {
        Name = name;
        EmailAddress = emailAddress;
        BirthDate = birthDate;
        Validate();
    }

    public static Customer Create(Guid id, string name, string emailAddress, DateTime birthDate)
    {
        return new Customer(id, name, emailAddress, birthDate);
    }

    public static Customer Create(string name, string emailAddress, DateTime birthDate)
    {
        Guid id = Guid.NewGuid();
        return new Customer(id, name, emailAddress, birthDate);
        
    }

    public sealed override void Validate()
    {
      var result =  new CustomerValidator().Validate(this);
      
      if (!result.IsValid)
      {
          // TODO: Return a custom exception
          throw new ValidationException(
              result.Errors.Select(e => e.ErrorMessage).ToList()
          );
      }
    }
}
