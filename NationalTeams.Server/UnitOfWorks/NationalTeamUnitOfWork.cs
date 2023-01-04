namespace NationalTeams.Server
{
    public class NationalTeamUnitOfWork : BaseUnitOfWork<NationalTeam>, INationalTeamUnitOfWork
    {
        public NationalTeamUnitOfWork(INationalTeamRepository repsitory) : base(repsitory)
        {
        }
    }
}
