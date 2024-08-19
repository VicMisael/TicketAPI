using Application.UseCases.Event.Query;
using Domain.Common.Utils;

namespace Application.UseCases.Customer.QueryCustomer;

public record CostumerOut(
    string Name,
    string Email,
    DateTime BirthDate);

public record QueryCustomerOut(
    int CurrentPage,
    int PerPage,
    int Total,
    IReadOnlyList<CostumerOut> Items)
{
    public static QueryCustomerOut FromQueryOut(QueryOut<Domain.Entities.Customer.Customer> queryOut)
    {
        return new QueryCustomerOut(queryOut.CurrentPage, queryOut.PerPage, queryOut.Total,
            queryOut.Items.Select(x => new CostumerOut(x.Name, x.EmailAddress, x.BirthDate)).ToList());
    }
};
