using SampleApplication_API.Models.Domain;

namespace SampleApplication_API.Models.DTO
{
    public class WalksDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid RegionId { get; set; }


        //Navigation
        public RegionResponseDto Region { get; set; }
    }
}
