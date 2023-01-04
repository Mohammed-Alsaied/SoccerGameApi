namespace Common
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T>
        where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            //builder.Property<Guid>(e => e.Id).HasValueGenerator<GuidValueGenerator>();

            builder.Property(e => e.CreationDate).HasDefaultValueSql("GETDATE()");
            //builder.Property(e => e.ConcurrencyStamp).IsRowVersion().ValueGeneratedOnAdd();
        }
    }
}