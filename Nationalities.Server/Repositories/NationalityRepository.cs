namespace Nationalities.Server;
public class NationalityRepository : BaseRepository<Nationality>, INationalityRepository
{
    public NationalityRepository(DbContext dbContext) : base(dbContext)
    {
    }
}