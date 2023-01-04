namespace Coaches.Server;
public class CoachUnitOfWork : BaseUnitOfWork<Coach>, ICoachUnitOfWork
{
    public CoachUnitOfWork(ICoachRepository repsitory) : base(repsitory)
    {
    }
}