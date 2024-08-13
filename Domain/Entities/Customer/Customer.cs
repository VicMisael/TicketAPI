using Domain.Common;

namespace Domain.Entities.Customer;

public class Customer:Entity
{
    public string Name { get; private set; }
    public string EmailAddress { get; private set; }
    public DateTime BirthDate { get; private set; }

    // Constructor for Customer with automatic ID generation
    public Customer(string name, string emailAddress, DateTime birthDate)
        : base() // Calls the base constructor that generates a new ID
    {
        Name = name;
        EmailAddress = emailAddress;
        BirthDate = birthDate;
    }

    // Constructor for Customer with a provided ID
    public Customer(Guid id, string name, string emailAddress, DateTime birthDate)
        : base(id) // Calls the base constructor that sets a specific ID
    {
        Name = name;
        EmailAddress = emailAddress;
        BirthDate = birthDate;
    }

    public override void Validate()
    {
        new CustomerValidator().Validate(this); // Assuming CustomerValidator is implemented elsewhere
    }
}
