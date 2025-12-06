namespace OnionVb02.WebApi.ExceptionModels
{
    public class ExceptionResponse
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; }
        public string ExceptionType { get; set; }
        public List<string> Errors { get; set; }
    }
}
