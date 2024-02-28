using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleApplication_API.Data;
using SampleApplication_API.Models.Domain;
using SampleApplication_API.Models.DTO;

namespace SampleApplication_API.Repository
{
    public class RegionRepository : IRegion
    {
        public SampleDBContext dbContext { get; }
        public RegionRepository(SampleDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Region>> GetAllRegionsAsync()
        {
            return await dbContext.Region.ToListAsync();
        }

        public async Task<Region?> GetRegionByIdAsync(Guid id)
        {
            return await dbContext.Region.FindAsync(id);
           
        }

        public async Task<Region?> UpdateRegionAsync(Guid id, RegionRequestDto regionRequestDto)
        {
            var region= await dbContext.Region.FirstOrDefaultAsync(x => x.Id == id);

            if(region == null)
            {
                return null;
            }

            region.Name = regionRequestDto.Name;

            dbContext.Region.Update(region);
            await dbContext.SaveChangesAsync();

            return region;
        }

        public async Task<Region?> CreateRegionAsync(RegionRequestDto regionRequestDto)
        {
            //Map DTO to Domain
            var regioModel = new Region
            {
                Name = regionRequestDto.Name
            };
            await dbContext.Region.AddAsync(regioModel);
            await dbContext.SaveChangesAsync();

            return regioModel;

        }

        public async  Task<string?> DeleteRegionAsync(Guid id)
        {
            var region = await dbContext.Region.FirstOrDefaultAsync(x => x.Id == id);
            if (region == null)
            {
                return null;
            }
            dbContext.Region.Remove(region);
            await dbContext.SaveChangesAsync();

            return region.Name;
        }
    }
}
