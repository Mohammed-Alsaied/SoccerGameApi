namespace Coaches.Server;
public class CoachMapperProfile : Profile
{
	public CoachMapperProfile()
	{
		CreateMap<Coach, CoachViewModel>().ReverseMap();
	}
}