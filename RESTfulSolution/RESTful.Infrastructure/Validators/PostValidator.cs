using FluentValidation;
using RESTful.Core.DTOs;
using System;

namespace RESTful.Infrastructure.Validators
{
    public class PostValidator : AbstractValidator<PostDto>
    {
        public PostValidator()
        {
            RuleFor(p => p.Description)
                .NotNull()
                .Length(10, 15);

            RuleFor(p => p.Date)
                .NotNull()
                .LessThan(DateTime.Now);
        }

    }
}
