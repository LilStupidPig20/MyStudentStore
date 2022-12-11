using RTF.Mobile.Infrastructure.Abstractions.Exceptions;
using RTF.Mobile.Infrastructure.Abstractions.Models;
using System.Net;
using System.Text;
using System.Text.Json;

namespace RTF.Mobile.Infrasturcture.Implementations
{
    public static class RestHelper
    {
        private const int NoResponseStatusCode = 0;

        /// <summary>
        /// Create an exception based on HTTP response status code.
        /// </summary>
        /// <param name="responseStatusCode">Response status code.</param>
        /// <param name="responseContent">Response content.</param>
        /// <param name="logger">Logger.</param>
        /// <returns>Exception.</returns>
        public static Exception CreateException(
            HttpStatusCode responseStatusCode,
            string responseContent)
        {
            if (responseStatusCode == NoResponseStatusCode)
            {
                return new NetworkException();
            }

            var errorMessage = TryToParseError(responseContent);

            Exception exception;
            switch (responseStatusCode)
            {
                case HttpStatusCode.NotFound:
                    exception = new NotFoundException(errorMessage);
                    break;
                default:
                    exception = new ValidationException(errorMessage);
                    break;
            }

            return exception;
        }

        private static string TryToParseError(string responseContent)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            ProblemsDto problemsContent;
            try
            {
                problemsContent = JsonSerializer.Deserialize<ProblemsDto>(responseContent, options);
            }
            catch (JsonException)
            {
                return string.Empty;
            }

            var stringBuilder = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(problemsContent.Title))
            {
                stringBuilder.AppendLine(problemsContent.Title);
            }

            if (problemsContent?.Errors?.Any() == true)
            {
                stringBuilder.AppendLine(string.Join("\n", problemsContent?.Errors.SelectMany(error => error.Messages)));
            }

            var errorMessage = stringBuilder.ToString().Trim();
            return errorMessage;
        }
    }
}
