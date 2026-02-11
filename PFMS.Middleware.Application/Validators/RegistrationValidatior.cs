using FluentValidation;
using PFMS.Middleware.Application.DTO;

namespace PFMS.Middleware.Application.Validators
{
    public class RegistrationValidatior : AbstractValidator<RegisterUserRequest>
    {
        //validations for user Registerations
        public RegistrationValidatior()
        {
            RuleFor(tmp => tmp.UserTypeId).NotEmpty().WithMessage("User TypeID is Required");
            RuleFor(tmp => tmp.PdCode).NotEmpty().WithMessage("PD code is Required");
            RuleFor(tmp => tmp.FromDate).NotEmpty().WithMessage("From Date is Required");
            RuleFor(tmp => tmp.ToDate).NotEmpty().WithMessage("To Date is Required");
            RuleFor(tmp => tmp.Email).NotEmpty().WithMessage("Email Id is Required").
                EmailAddress().WithMessage("Enter Valid Email Format");
            RuleFor(tmp => tmp.ToDate).NotEmpty().WithMessage("User TypeID is Required");
            RuleFor(tmp => tmp.CreatedBy).NotEmpty().WithMessage("CreatedBy is Required");
        }
    }
}
