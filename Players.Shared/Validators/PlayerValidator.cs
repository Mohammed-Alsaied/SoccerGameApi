namespace Players.Shared;
public class PlayerValidator : PersonValidator<PlayerViewModel>
{
    public PlayerValidator()
    {
        RuleFor(e => e.Weight).NotEmpty().GreaterThan(0);
        RuleFor(e => e.CurrentNumber).NotEmpty().GreaterThan(0);
        RuleFor(e => e.Foot).NotEmpty();
        RuleFor(e => e.Position).NotEmpty();
    }
}