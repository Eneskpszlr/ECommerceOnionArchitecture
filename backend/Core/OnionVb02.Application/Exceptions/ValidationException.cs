namespace OnionVb02.Application.Exceptions
{
    public class ValidationException : BaseException
    {
        public List<string> Errors { get; }

        public ValidationException(List<string> errors)
            : base("Validation failed")
        {
            Errors = errors;
        }
    }
}
