namespace Nationalities.Shared;
public class NationalityValidator : AbstractValidator<NationalityViewModel>
{
	public NationalityValidator()
	{
		RuleFor(x => x.Name).NotEmpty().WithMessage("Name is Required");
	}
}