namespace Players.Server;
public class PlayerUnitOfWork : BaseUnitOfWork<Player>, IPlayerUnitOfWork
{
    public PlayerUnitOfWork(IPlayerRepository repsitory) : base(repsitory)
    {
    }
}