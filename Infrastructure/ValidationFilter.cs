﻿using System;
using FluentValidation;

namespace NotesApi.Infrastructure
{
	public class ValidationFilter<T> : IEndpointFilter where T : class
	{
        private readonly IValidator<T> _validator;

		public ValidationFilter(IValidator<T> validator)
		{
            _validator = validator;
		}

        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var validatable = context.Arguments.SingleOrDefault(x => x.GetType() == typeof(T)) as T;

            if (validatable is null)
                return Results.BadRequest();

            var validationResult = await _validator.ValidateAsync(validatable);

            if (!validationResult.IsValid)
                return Results.BadRequest(validationResult.Errors.Select(x => x.ErrorMessage)
                    .ToList()
                    .Aggregate((i, j) => $"{i}, {j}"));

            return await next(context);
        }
    }
}

