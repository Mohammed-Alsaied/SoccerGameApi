namespace Players.Server;
public class PlayerMapperProfile : Profile
{
	public PlayerMapperProfile()
	{
		CreateMap<Player, PlayerViewModel>().ReverseMap();
	}
}