namespace Nationalities.Server;
public class NationalityConfigurations : BaseEntityConfiguration<Nationality>
{
    public override void Configure(EntityTypeBuilder<Nationality> builder)
    {
        base.Configure(builder);
        builder.Property(e => e.Name).IsRequired();

    }
}