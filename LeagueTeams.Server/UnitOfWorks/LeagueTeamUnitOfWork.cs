namespace LeagueTeams.Server
{
    public class LeagueTeamUnitOfWork : BaseUnitOfWork<LeagueTeam>, ILeagueTeamUnitOfWork
    {
        public LeagueTeamUnitOfWork(ILeagueTeamRepository repsitory) : base(repsitory)
        {
        }
    }
}
