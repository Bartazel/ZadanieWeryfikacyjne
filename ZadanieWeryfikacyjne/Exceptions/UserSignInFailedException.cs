using Microsoft.AspNetCore.Http;

namespace ZadanieWeryfikacyjne.Exceptions
{
    public class UserSignInFailedException : HttpResponseException
    {
        public UserSignInFailedException(string whyFailed)
            : base("Could not sign user in.", StatusCodes.Status401Unauthorized, whyFailed: whyFailed)
        {
        }
    }
}
