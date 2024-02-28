using Microsoft.AspNetCore.Mvc;
using SampleApplication_API.Models.Domain;
using SampleApplication_API.Models.DTO;

namespace SampleApplication_API.Repository
{
    public interface IRegion
    {
        Task<List<Region>> GetAllRegionsAsync();
        Task<Region?> GetRegionByIdAsync(Guid id);
        Task<Region?> UpdateRegionAsync(Guid id, RegionRequestDto regionRequestDto);

        Task<Region?> CreateRegionAsync(RegionRequestDto regionRequestDto);
        Task<string?> DeleteRegionAsync(Guid id);
    }
}
