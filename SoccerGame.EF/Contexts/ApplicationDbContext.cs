namespace SoccerManager
{
    using Coaches.Server;
    using LeagueTeams.Server;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Nationalities.Server;
    using NationalTeams.Server;
    using Persons.Shared;
    using Players.Server;

    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        protected ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        //public ApplicationDbContext(DbContextOptionsBuilder<ApplicationDbContext> options)
        //{
        //    options.UseSqlServer(connection, b => b.MigrationsAssembly("SoccerGame.EF"));
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Player).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Person).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Coach).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Nationality).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NationalTeam).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LeagueTeam).Assembly);

        }
    }
}