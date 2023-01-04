namespace NationalTeams.Server;
public class NationalTeamRepository : BaseRepository<NationalTeam> , INationalTeamRepository
{
    public NationalTeamRepository(DbContext dbContext) : base(dbContext)
    {
    }

    public override async Task<List<NationalTeam>> GetAllAsync()
    {
        return await _table
            .Include(c => c.Players)
            .ToListAsync();
    }

    public override async Task<NationalTeam> GetByIdAsync(Guid id)
    {
        return await _table
            .Include(c => c.Players)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}