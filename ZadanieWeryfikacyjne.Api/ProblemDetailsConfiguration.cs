using FluentValidation;
using Hellang.Middleware.ProblemDetails;
using ZadanieWeryfikacyjne.Exceptions;

namespace ZadanieWeryfikacyjne
{
    public static class ProblemDetailsConfiguration
    {
        public static void ConfigureProblemDetails(ProblemDetailsOptions options)
        {
            options.MapFluentValidationException();
            options.Map<HttpResponseException>((ctx, ex) =>
            {
                var problemDetails = new Microsoft.AspNetCore.Mvc.ProblemDetails
                {
                    Detail = ex.Details,
                    Status = ex.StatusCode,
                    Title = ex.Message,
                    Type = ex.GetType().FullName
                };

                return problemDetails;
            });
            options.MapToStatusCode<NotImplementedException>(StatusCodes.Status501NotImplemented);
            options.MapToStatusCode<Exception>(StatusCodes.Status500InternalServerError);
        }

        private static void MapFluentValidationException(this ProblemDetailsOptions options)
        {
            options.Map<ValidationException>((ctx, ex) =>
            {
                var factory = ctx.RequestServices.GetRequiredService<ProblemDetailsFactory>();

                var errors = ex.Errors
                    .GroupBy(x => x.PropertyName)
                    .ToDictionary(
                        x => x.Key,
                        x => x.Select(x => x.ErrorMessage)
                    .Distinct().ToArray());

                return factory.CreateValidationProblemDetails(ctx, errors);
            });
        }
    }
}
