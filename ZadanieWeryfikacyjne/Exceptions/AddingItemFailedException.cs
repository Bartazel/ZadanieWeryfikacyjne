namespace ZadanieWeryfikacyjne.Exceptions
{
    public class AddingItemFailedException : HttpResponseException
    {
        public AddingItemFailedException(string error, int statusCode)
        : base("Could not add the item.", statusCode, whyFailed: error)
        {

        }
    }
}
