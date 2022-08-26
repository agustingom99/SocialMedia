using FluentValidation;
using SocialMedia_Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Infrastructure.Validators
{
    public class PostValidator: AbstractValidator<PostDto>
    {
        public PostValidator()
        {
            RuleFor(post => post.Description)
                .NotNull().
                Length(10, 15);// dos validaciones para el campo descripcion
            RuleFor(post => post.Date)
                .NotNull()
                .LessThan(DateTime.Now);
        }


    }
}
