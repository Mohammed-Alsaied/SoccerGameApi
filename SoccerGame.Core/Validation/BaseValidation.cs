using FluentValidation;
using FluentValidation.Results;

namespace Common.Validation
{
    public class BaseValidation<TViewModel> : IBaseValidation<TViewModel>
        where TViewModel : BaseViewModel
    {
        protected readonly IValidator<TViewModel> _validator;

        public BaseValidation(IValidator<TViewModel> validator)
        {
            _validator = validator;
        }

        public async Task IsValid(TViewModel productViewModel)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(productViewModel);
            if (!validationResult.IsValid)
                Console.WriteLine($"{new { errors = validationResult.Errors }}");

        }
    }
}
