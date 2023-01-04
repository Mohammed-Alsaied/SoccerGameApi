namespace Coaches.Server;
public class CoachConfigurations : PersonConfiguration<Coach>
{
    public override void Configure(EntityTypeBuilder<Coach> builder)
    {
        //builder.HasCheckConstraint("ck_NationalTeamIdOrLeagueTeamId", $"(NationalTeamId is not null and LeagueTeamId is null) or (LeagueTeamId is not null and NationalTeamId is null)");
        base.Configure(builder);
    }
}