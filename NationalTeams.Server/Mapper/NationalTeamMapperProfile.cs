namespace NationalTeams.Server
{
    public class NationalTeamMapperProfile : Profile
    {
        public NationalTeamMapperProfile()
        {
            CreateMap<NationalTeam, NationalTeamViewModel>().ReverseMap();
        }
    }
}
