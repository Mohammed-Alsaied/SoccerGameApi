namespace Coaches.Server;
public class CoachRepository : BaseRepository<Coach>, ICoachRepository
{
    public CoachRepository(DbContext dbContext) : base(dbContext)
    {
    }
}