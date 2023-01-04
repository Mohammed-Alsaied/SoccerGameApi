namespace LeagueTeams.Server;
public class LeagueTeamRepository : BaseRepository<LeagueTeam> , ILeagueTeamRepository
{
    public LeagueTeamRepository(DbContext dbContext) : base(dbContext)
    {

    }

    public override async Task<List<LeagueTeam>> GetAllAsync()
    {
        return await _table
            .Include(c => c.Players)
            .ToListAsync();
    }

    public override async Task<LeagueTeam> GetByIdAsync(Guid id)
    {
        return await _table
            .Include(c => c.Players)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}