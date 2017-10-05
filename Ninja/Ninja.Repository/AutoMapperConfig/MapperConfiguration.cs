using AutoMapper;
using Ninja.Domain;
using Ninja.View;

namespace Ninja.Repository.AutoMapperConfig
{
    //Author: josipba
    //Machine: P004794
    //Created: 10/2/2017 11:50:21 AM
    public static class MapperConfiguration
    {
        public static void RegisterMaps()
        {

            Mapper.Initialize(config =>
            {
                config.CreateMap<Ninja.Domain.Ninja, NinjaView>().ReverseMap();
                config.CreateMap<Clan, ClanView>().ReverseMap();
                config.CreateMap<Equipment, EquipmentView>().ReverseMap();

                config.CreateMap<Clan, ClanWithNinjasView>()
                    .ForMember(dest => dest.Ninjas, opt => opt.MapFrom( src => src.Ninjas ) );

                config.CreateMap<Ninja.Domain.Ninja, NinjaWithClan>()
                .ForMember(dest => dest.ClanId, opt => opt.MapFrom(src => src.Clan.Id))
                .ForMember(dest => dest.ClanName, opt => opt.MapFrom(src => src.Clan.Name));

            });

        }

    }
}
