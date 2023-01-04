namespace NationalTeams.Shared;
public class NationalTeamValidator : AbstractValidator<NationalTeamViewModel>
{
	public NationalTeamValidator()
	{
		RuleFor(x => x.Name).NotEmpty().WithMessage("Name is Required");
		RuleFor(x => x.NickName).NotEmpty().WithMessage("NickName is Required");
		RuleFor(x => x.MostCaps).NotEmpty().WithMessage("MostCaps is Required");
		RuleFor(x => x.FifaCode).NotEmpty().WithMessage("FifaCode is Required");
		RuleFor(x => x.Association).NotEmpty().WithMessage("Association is Required");
		RuleFor(x => x.Confedration).NotEmpty().WithMessage("Confedration is Required");
	}
}