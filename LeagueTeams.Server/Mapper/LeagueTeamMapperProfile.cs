namespace LeagueTeams.Server
{
    public class LeagueTeamMapperProfile : Profile
    {
        public LeagueTeamMapperProfile()
        {
            CreateMap<LeagueTeam, LeagueTeamViewModel>().ReverseMap();
        }
    }
}
