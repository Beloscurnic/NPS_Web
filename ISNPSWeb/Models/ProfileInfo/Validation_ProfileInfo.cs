using FluentValidation;

namespace ISNPSWeb.Models.ProfileInfo
{
    public class Validation_ProfileInfo : AbstractValidator<ChangePassword_DTO>
    {
        public Validation_ProfileInfo()
        {
            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("Новый пароль не должен быть пустым")
                .MinimumLength(8).WithMessage("Минимальная длина пароля - 8 символов")
                .Must(password => password.Any(char.IsLetter) && password.Any(char.IsDigit))
                .WithMessage("Пароль должен содержать как буквы, так и цифры");


            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.NewPassword).WithMessage("Подтверждение пароля не совпадает с новым паролем");

            RuleFor(x => x.OldPassword)
                .NotEmpty().WithMessage("Старый пароль не должен быть пустым");
        }
    }  
}
