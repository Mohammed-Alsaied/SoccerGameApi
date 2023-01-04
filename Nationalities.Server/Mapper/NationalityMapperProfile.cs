namespace Nationalities.Server
{
    public class NationalityMapperProfile : Profile
    {
        public NationalityMapperProfile()
        {
            CreateMap<Nationality, NationalityViewModel>().ReverseMap();
        }
    }
}
