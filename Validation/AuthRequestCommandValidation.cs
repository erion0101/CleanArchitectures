using FluentValidation;
using q.Commands;

namespace q.Validation
{
    public class AuthRequestCommandValidation : AbstractValidator<AuthRequestCommand>
    {
        public AuthRequestCommandValidation()
        {
            RuleFor(x => x.Email).EmailAddress().NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
