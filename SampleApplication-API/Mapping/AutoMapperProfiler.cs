using AutoMapper;
using SampleApplication_API.Models.Domain;
using SampleApplication_API.Models.DTO;

namespace SampleApplication_API.Mapping
{
    public class AutoMapperProfiler:Profile
    {
        public AutoMapperProfiler()
        {
            CreateMap<Region,RegionResponseDto>().ReverseMap();
        }
    }
}
