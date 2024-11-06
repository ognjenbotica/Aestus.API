using AutoMapper;
using Aestus.API.Data;
using Aestus.API.Models;

namespace Aestus.API.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Setting, SettingDto>().ReverseMap();
            CreateMap<SettingVersion, SettingVersionDto>().ReverseMap();
        }
    }
}

