using APIs.Models.FTA.IncidentData;
using APIs.Models.STA.IncidentsAndProblems;

namespace APIs.Specifications
{
    public class IncidentSpecifications : BaseSpecification<CuttingDownHeader>
    {
        public IncidentSpecifications(SpecificationParams incParams):
            base(h=>
                (!incParams.SourceId.HasValue || h.ChannelKey == incParams.SourceId) &&
                (!incParams.ProblemTypeId.HasValue || h.CuttingDownProblemTypeKey == incParams.ProblemTypeId) &&
                (!incParams.Status.HasValue ||
                (incParams.Status == true && h.ActualEndDate != null) ||
                (incParams.Status == false && h.ActualEndDate == null))

            )
        {
            
        }
    }
}
