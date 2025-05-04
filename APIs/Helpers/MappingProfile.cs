using APIs.DTOs;
using APIs.Models.FTA.Hierarchy;
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

            CreateMap<NetworkElement, NetworkElementDto>()
                .ForMember(d=>d.NetworkElementType, opt=>opt.MapFrom(s=>s.NetworkElementType.NetworkElementTypeName))
                .ForMember(d => d.ParentKey, opt => opt.MapFrom(s => s.ParentNetworkElement.NetworkElementKey));

            CreateMap<CuttingDownDetail, DetailsDto>()
                .ForMember(d=>d.IncidentKey, opt=>opt.MapFrom(s=>s.CuttingDownHeader.CuttingDownIncidentId));
        }
    }
}
