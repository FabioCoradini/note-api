using System;
namespace NotesApi.Infrastructure
{
	internal class RequestLoggingMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<Program> _logger;

		public RequestLoggingMiddleware(RequestDelegate next, ILogger<Program> logger)
		{
			_next = next;
			_logger = logger;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			// Do something
			_logger.LogInformation("A request started");

			// Call the next middleware in the pipeline
			await _next(context);

            // Do something
            _logger.LogInformation("A request over");
        }
	}
}

