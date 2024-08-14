using System.Collections.Generic;
using System.Linq;

namespace Domain.Common.Exceptions;

public class ValidationException(IReadOnlyList<string> errors) : DomainException(errors.Aggregate("", (acc, x) => acc + "," + x));
