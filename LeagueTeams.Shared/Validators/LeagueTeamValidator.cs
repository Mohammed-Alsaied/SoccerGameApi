namespace LeagueTeams.Shared;
public class LeagueTeamValidator : AbstractValidator<LeagueTeamViewModel>
{
	public LeagueTeamValidator()
	{
		RuleFor(x => x.Name).NotEmpty().WithMessage("Name is Required");
		RuleFor(x => x.NickName).NotEmpty().WithMessage("NickName is Required");
		RuleFor(x => x.President).NotEmpty().WithMessage("President is Required");
		RuleFor(x => x.Founded).NotEmpty().WithMessage("Founded Date is Required");
		RuleFor(x => x.Capacity).NotEmpty().WithMessage("Capacity is Required");
		RuleFor(x => x.LeagueName).NotEmpty().WithMessage("League Name is Required");
		RuleFor(x => x.HomeStadium).NotEmpty().WithMessage("Home Stadium is Required");
	}
}