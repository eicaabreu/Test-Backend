using FluentValidation.Results;

namespace TEST.Application.SeedWork.Exceptions
{
    public class ValidationException : Exception
    {
        public IEnumerable<string> Errors { get; } = new HashSet<string>();

        public ValidationException()
            : base("One or more validation failures have occurred.")
        { }

        public ValidationException(IEnumerable<ValidationFailure> failures)
            : base("One or more validation failures have occurred.")
        {
            Errors = failures
                .Select(x => x.ErrorMessage)
                .Distinct();
        }
    }
}
