namespace Players.Server;
public class PlayerRepository : BaseRepository<Player> , IPlayerRepository
{
    public PlayerRepository(DbContext dbContext) : base(dbContext)
    {
    }
}