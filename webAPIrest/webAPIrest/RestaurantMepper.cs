using AutoMapper;
using webAPIrest.Entieties;
using webAPIrest.MApperData;

namespace webAPIrest
{
    public class RestaurantMepper : Profile
    {
        public RestaurantMepper()
        {
            CreateMap<Restaurant, RestaurantMapp>()
                .ForMember(a => a.City ,b => b.MapFrom(s => s.Address.City))
                .ForMember(a => a.Street, b => b.MapFrom(s => s.Address.Street))
                .ForMember(a => a.PostalCode, b => b.MapFrom(s => s.Address.PostalCode));

            CreateMap<Dish, DishMapp>();
                
        }
    }
}
