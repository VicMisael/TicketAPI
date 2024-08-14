namespace Domain.Common.Utils;

public record QueryOut<T>(
    int CurrentPage,
    int PerPage,
    int Total,
    IReadOnlyList<T> Items);
