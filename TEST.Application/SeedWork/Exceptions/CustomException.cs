namespace TEST.Application.SeedWork.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException(string errorMessage) : base(errorMessage)
        { }
    }
}
