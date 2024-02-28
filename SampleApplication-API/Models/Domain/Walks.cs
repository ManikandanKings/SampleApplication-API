namespace SampleApplication_API.Models.Domain
{
    public class Walks
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid RegionId { get; set; }


        //Navigation
        public Region Region { get; set; }
    }
}
