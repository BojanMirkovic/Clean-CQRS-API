using FluentValidation; // Importing FluentValidation namespace
using Newtonsoft.Json; // Importing Newtonsoft.Json namespace

namespace API.Middleware
{
    // Middleware to handle exceptions globally
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next; // Reference to the next middleware in the pipeline
        private readonly ILogger<ExceptionMiddleware> _logger; // Logger for logging exceptions

        // Constructor for ExceptionMiddleware
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next; // Assigning the next middleware
            _logger = logger; // Assigning the logger
        }

        // Method invoked to handle HTTP requests
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext); // Invoking the next middleware in the pipeline
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception."); // Logging the exception
                await HandleExceptionAsync(httpContext, ex); // Handling the exception
            }
        }

        // Method to handle exceptions and generate appropriate HTTP responses
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json"; // Setting response content type to JSON

            // Setting the appropriate HTTP status code based on the type of exception
            context.Response.StatusCode = exception switch
            {
                UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                KeyNotFoundException => StatusCodes.Status404NotFound,
                ValidationException => StatusCodes.Status400BadRequest,
                // Additional exception types can be added here
                _ => StatusCodes.Status500InternalServerError // Default status code for unhandled exceptions
            };

            // Creating an ErrorDetails object with status code and exception message
            var errorDetails = new ErrorDetails
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message // Setting the exception message
                // You could have logic here to determine a more generic message based on the type of exception
            };

            // Writing the serialized ErrorDetails object to the response
            return context.Response.WriteAsync(errorDetails.ToString());
        }
    }

    // Class representing the structure of error details
    public class ErrorDetails
    {
        public int StatusCode { get; set; } // HTTP status code
        public string Message { get; set; } // Error message

        // Method to serialize the ErrorDetails object to JSON
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
