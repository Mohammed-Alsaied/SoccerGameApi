namespace LeagueTeams.Server;
public class LeagueTeamConfigurations : BaseEntityConfiguration<LeagueTeam>
{
    public override void Configure(EntityTypeBuilder<LeagueTeam> builder)
    {
        base.Configure(builder);
        builder.Property(e => e.Name).IsRequired();
        builder.Property(e => e.NickName).IsRequired();
        builder.Property(e => e.LeagueName).IsRequired();
        builder.Property(e => e.Founded).IsRequired();
        builder.Property(e => e.President).IsRequired();
        builder.Property(e => e.HomeStadium).IsRequired();
        builder.Property(e => e.Capacity).IsRequired();
        builder.HasMany(e => e.Players).WithOne().HasForeignKey(e => e.LeagueTeamId);
        builder.HasOne(e => e.Coach).WithOne().HasForeignKey<Coach>(e => e.LeagueTeamId);

    }
}