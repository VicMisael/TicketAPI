namespace Domain.Common.Utils;

public record QueryIn(
    int Page,
    int PerPage,
    string Query,
    string OrderBy,
    QueryOrderDir Dir);
