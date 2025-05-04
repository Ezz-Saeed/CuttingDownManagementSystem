using APIs.DTOs;
using APIs.Models.FTA.IncidentData;
using AutoMapper;

namespace APIs.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CuttingDownHeader, GetHeaderDto>()
                .ForMember(d=>d.ChannelKey, opt=>opt.MapFrom(s=>s.Channel.ChannelKey))
                .ForMember(d => d.CuttingDownProblemTypeKey, opt => opt.MapFrom(s => s.CuttingDownProblemType.ProblemTypeKey));
        }
    }
}
